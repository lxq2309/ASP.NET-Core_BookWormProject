using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels.Article;
using BookWormProject.ViewModels.Chapter;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;
        private readonly IArticleService _articleService;

        public ChapterController(IChapterService chapterService, IArticleService articleService)
        {
            _chapterService = chapterService;
            _articleService = articleService;
        }

        [Route("~/p/{articleId}/{index}")]
        public IActionResult Index(int articleId, int index)
        {
            var parentArticle = _articleService.GetArticleById(articleId);
            var currentChapter = _chapterService.GetChapterByIndex(articleId, index);
            if (currentChapter == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var chapterIndex = currentChapter.Index;

            var nextChapter = _chapterService.GetChapterByIndex(articleId, chapterIndex + 1);
            var previousChapter = _chapterService.GetChapterByIndex(articleId, chapterIndex - 1);
            var chapters = _articleService.GetChaptersForArticle(articleId);
            var viewModels = new ChapterIndexViewModel()
            {
                ParentArticle = parentArticle,
                CurrentChapter = currentChapter,
                NextChapter = nextChapter,
                PreviousChapter = previousChapter,
                Chapters = chapters
            };
            return View(viewModels);
        }



        public IActionResult Create(int articleId)
        {
            var article = _articleService.GetArticleById(articleId);
            ViewBag.Article = article;
            return View(new ChapterCreateEditViewModel()
            {
                Index = _chapterService.GetNewestChapterIndex(articleId) + 1
            });
        }

        [HttpPost]
        public IActionResult Create(ChapterCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newChapter = new Chapter()
            {
                Title = model.Title,
                Content = model.Content,
                Index = model.Index,
                ArticleId = model.ArticleId,
                CreatedAt = DateTime.Now
            };

            _chapterService.AddChapter(newChapter);
            // Cập nhật thời gian sửa của Bài viết chứa chapter này
            var article = _articleService.GetArticleById(newChapter.ArticleId);
            article.UpdatedAt = DateTime.Now;
            _articleService.UpdateArticle(article);

            return RedirectToAction("Chapter", "Admin", new { articleId = model.ArticleId });
        }


        public IActionResult Edit(int id)
        {
            var chapter = _chapterService.GetById(id);
            var article = _articleService.GetArticleById(chapter.ArticleId);
            ViewBag.Article = article;
            return View(new ChapterCreateEditViewModel()
            {
                Title = chapter.Title,
                Content = chapter.Content,
                Index = chapter.Index,
                ChapterId = chapter.ChapterId,
                ArticleId = chapter.ArticleId
            });
        }

        [HttpPost]
        public IActionResult Edit(ChapterCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var chapter = _chapterService.GetById(model.ChapterId);
            chapter.Title = model.Title;
            chapter.Content = model.Content;
            chapter.Index = model.Index;
            _chapterService.UpdateChapter(chapter);

            // Cập nhật thời gian sửa của Bài viết chứa chapter này
            var article = _articleService.GetArticleById(chapter.ArticleId);
            article.UpdatedAt = DateTime.Now;
            _articleService.UpdateArticle(article);
            return RedirectToAction("Chapter", "Admin", new { articleId = model.ArticleId });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _chapterService.DeleteChapter(id);
            return RedirectToAction("Article", "Admin");
        }
    }
}