using BookWormProject.Data.Services;
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

        [Route("~/p/{articleId}/{chapterIndex}")]
        public IActionResult Index(int articleId, int chapterIndex)
        {
            var parentArticle = _articleService.GetArticleById(articleId);
            var currentChapter = _chapterService.GetChapterByIndex(articleId, chapterIndex);
            if (currentChapter == null)
            {
                return RedirectToAction("Index", "Home");
            }

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



        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}