using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels;
using BookWormProject.ViewModels.Article;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookWormProject.ViewModels.Home;
using Microsoft.AspNetCore.Identity;

namespace BookWormProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var articles = _articleService.GetAllArticles();
            var hotArticles = articles.OrderByDescending(x => x.ViewCount)
                                      .Select(x => new ArticleDetailViewModel
                                      {
                                          ArticleId = x.ArticleId,
                                          Title = x.Title,
                                          IsCompleted = x.IsCompleted,
                                          CoverImage = x.CoverImage
                                      })
                                      .ToList();
            var newArticles = articles.OrderByDescending(x => x.UpdatedAt)
                                      .Select(x => new ArticleDetailViewModel
                                      {
                                          ArticleId = x.ArticleId,
                                          Title = x.Title,
                                          UpdatedAt = x.UpdatedAt,
                                          Genres = _articleService.GetGenresForArticle(x.ArticleId),
                                          IsCompleted = x.IsCompleted,
                                          Chapters = _articleService.GetChaptersForArticle(x.ArticleId)
                                      })
                                      .ToList();
            var completedArticles = articles.Where(x => x.IsCompleted)
                                            .OrderByDescending(x => x.ArticleId)
                                            .Select(x => new ArticleDetailViewModel
                                            {
                                                ArticleId = x.ArticleId,
                                                Title = x.Title,
                                                CoverImage = x.CoverImage,
                                                Chapters = _articleService.GetChaptersForArticle(x.ArticleId)
                                            })
                                            .ToList();

            var viewModels = new IndexViewModel(hotArticles, newArticles, completedArticles);
            return View(viewModels);
        }

        [Route("~/moi-cap-nhat")]
        public IActionResult NewArticles()
        {
            return View();
        }

        [Route("~/doc-nhieu-nhat")]
        public IActionResult HotArticles()
        {
            return View();
        }

        [Route("~/da-hoan-thanh")]
        public IActionResult CompletedArticles()
        {
            return View();
        }

        [Route("~/search")]
        public IActionResult Search(string? keyword)
        {
            var articles = _articleService.GetAllArticles().Where(x => x.Title.ToLower().Contains(keyword.ToLower())).ToList();
            ViewBag.Keyword = keyword;
            return View(articles);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}