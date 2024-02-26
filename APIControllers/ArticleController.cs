using BookWormProject.Data.Services;
using BookWormProject.DTOs;
using BookWormProject.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BookWormProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IGenreService genreService, IAuthorService authorService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _genreService = genreService;
            _authorService = authorService;
        }

        [HttpGet("get_new_articles")]
        public IActionResult GetNewArticles(int? page, int pageSize = 10)
        {
            var articles = _articleService.GetAllArticles()
                                                                 .OrderByDescending(x => x.UpdatedAt);
            return ArticleListHelper.CreateArticleListResponse(this, _articleService, articles, page, pageSize, "GetNewArticles");
        }

        [HttpGet("get_hot_articles")]
        public IActionResult GetHotArticles(int? page, int pageSize = 10)
        {
            var articles = _articleService.GetAllArticles()
                                                                 .OrderByDescending(x => x.ViewCount);
            return ArticleListHelper.CreateArticleListResponse(this, _articleService, articles, page, pageSize, "GetHotArticles");
        }

        [HttpGet("get_completed_articles")]
        public IActionResult GetCompletedArticles(int? page, int pageSize = 10)
        {
            var articles = _articleService.GetAllArticles()
                                                                 .Where(x=>x.IsCompleted)
                                                                 .OrderByDescending(x => x.ArticleId);
            return ArticleListHelper.CreateArticleListResponse(this, _articleService, articles, page, pageSize, "GetCompletedArticles");
        }

        [HttpGet("get_articles_for_genre")]
        public IActionResult GetArticlesForGenre(int genreId, int? page, int pageSize = 10)
        {
            var articles = _genreService.GetArticlesForGenre(genreId).OrderByDescending(x => x.ArticleId);
            return ArticleListHelper.CreateArticleListResponse(this, _articleService, articles, page, pageSize, "GetArticlesForGenre");
        }

        [HttpGet("get_articles_for_author")]
        public IActionResult GetArticlesForAuthor(int authorId, int? page, int pageSize = 10)
        {
            var articles = _authorService.GetArticlesForAuthor(authorId).OrderByDescending(x => x.ArticleId);
            return ArticleListHelper.CreateArticleListResponse(this, _articleService, articles, page, pageSize, "GetArticlesForGenre");
        }
    }
}
