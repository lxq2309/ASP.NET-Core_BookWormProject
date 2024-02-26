using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWormProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;
        private readonly IGithubService _githubService;
        private readonly IUserService _userService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IGenreService genreService, IAuthorService authorService, IGithubService githubService, IUserService userService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _genreService = genreService;
            _authorService = authorService;
            _githubService = githubService;
            _userService = userService;
        }


        [Route("~/p/{id}")]
        public IActionResult Details(int id)
        {
            var article = _articleService.GetArticleById(id);
            _articleService.IncreaseViewCount(article);
            var viewModels = new ArticleDetailViewModel()
            {
                ArticleId = article.ArticleId,
                User = _userService.GetById(article.UserId),
                Title = article.Title,
                CoverImage = article.CoverImage,
                Description = article.Description,
                ViewCount = article.ViewCount,
                CreatedAt = article.CreatedAt,
                UpdatedAt = article.UpdatedAt,
                IsCompleted = article.IsCompleted,
                Genres = _articleService.GetGenresForArticle(id),
                Chapters = _articleService.GetChaptersForArticle(id).OrderByDescending(x => x.ChapterId),
                Authors = _articleService.GetAuthorsForArticle(id)
            };
            return View(viewModels);
        }



        public IActionResult Create()
        {

            // Lấy danh sách Genre
            var genres = _genreService.GetAllGenres();
            // Lấy danh sách authors
            var authors = _authorService.GetAllAuthors();

            return View(new ArticleCreateEditViewModel()
            {
                ListAuthor = authors,
                ListGenre = genres
            });
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var article = new Article
            {
                Title = model.Title,
                Description = model.Description,
                Genres = new List<Genre>(),
                Authors = new List<Author>(),
                IsCompleted = model.IsCompleted,
                CoverImage = model.AvatarLink
            };

            if (model.AvatarFile != null && model.AvatarFile.Length > 0)
            {
                var linkImage = _githubService.UploadImage(model.AvatarFile);
                article.CoverImage = linkImage;
            }


            // Lấy danh sách các thể loại được chọn từ form và thêm vào bài viết.
            if (model.Genres != null)
            {
                foreach (var genreId in model.Genres)
                {
                    var genre = _genreService.GetGenreById(genreId);
                    if (genre != null)
                    {
                        article.Genres.Add(genre);
                    }
                }
            }

            // Lấy danh sách các tác giả được chọn từ form và thêm vào bài viết.
            if (model.Authors != null)
            {
                foreach (var authorId in model.Authors)
                {
                    var author = _authorService.GetAuthorById(authorId);
                    if (author != null)
                    {
                        article.Authors.Add(author);
                    }
                }
            }

            // Lưu bài viết vào cơ sở dữ liệu.
            _articleService.AddArticle(article);

            // Chuyển hướng đến trang chi tiết của bài viết vừa được tạo mới.
            return RedirectToAction("Details", new { id = article.ArticleId });
        }


        public IActionResult Edit(int id)
        {
            // Lấy thông tin bài viết
            var article = _articleService.GetArticleById(id);

            // Lấy danh sách Genre
            var genres = _genreService.GetAllGenres();
            // Lấy danh sách authors
            var authors = _authorService.GetAllAuthors();

            return View(new ArticleCreateEditViewModel()
            {
                ListAuthor = authors,
                ListGenre = genres,
                Title = article.Title,
                Description = article.Description,
                SelectedGenres = _articleService.GetGenresForArticle(id),
                SelectedAuthors = _articleService.GetAuthorsForArticle(id),
                IsCompleted = article.IsCompleted,
                AvatarLink = article.CoverImage,
                ArticleId = article.ArticleId
            });
        }

        [HttpPost]
        public IActionResult Edit(ArticleCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var article = _articleService.GetArticleById((int)model.ArticleId);
            article.Title = model.Title;
            article.Description = model.Description;
            article.CoverImage = model.AvatarLink;

            // Cập nhật ảnh
            if (model.AvatarFile != null && model.AvatarFile.Length > 0)
            {
                var linkImage = _githubService.UploadImage(model.AvatarFile);
                article.CoverImage = linkImage;
            }

            // Cập nhật thể loại
            // 1. Xoá các thể loại cũ
            var genres = _articleService.GetGenresForArticle(article.ArticleId);
            foreach (var genre in genres)
            {
                article.Genres.Remove(genre);
            }
            // 2. Thêm các thể loại đã chọn
            if (model.Genres != null)
            {
                foreach (var genreId in model.Genres)
                {
                    var genre = _genreService.GetGenreById(genreId);
                    if (genre != null)
                    {
                        article.Genres.Add(genre);
                    }
                }
            }


            // Cập nhật tác giả
            // 1. Xoá các tác giả cũ
            var authors = _articleService.GetAuthorsForArticle(article.ArticleId);
            foreach (var author in authors)
            {
                article.Authors.Remove(author);
            }
            // 2. Thêm các tác giả đã chọn
            if (model.Authors != null)
            {
                foreach (var authorId in model.Authors)
                {
                    var author = _authorService.GetAuthorById(authorId);
                    if (author != null)
                    {
                        article.Authors.Add(author);
                    }
                }
            }


            // Lưu bài viết vào cơ sở dữ liệu.
            _articleService.UpdateArticle(article);

            return RedirectToAction("Article", "Admin");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _articleService.DeleteArticle(id);
            return RedirectToAction("Article", "Admin");
        }


    }
}