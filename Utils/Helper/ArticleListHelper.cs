using BookWormProject.Data.Services;
using BookWormProject.DTOs;
using BookWormProject.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BookWormProject.Utils.Helper
{
    public static class ArticleListHelper
    {
        public static IActionResult CreateArticleListResponse(ControllerBase controller,
            IArticleService articleService, IEnumerable<Article>? articles, int? page, int pageSize, string actionName)
        {
            var pagedArticles = articles.ToPagedList(page ?? 1, pageSize);

            var articleDTOs = pagedArticles.Select(x => new ArticleDTO
            {
                ArticleId = x.ArticleId,
                Title = x.Title,
                CoverImage = x.CoverImage,
                UpdatedAt = x.UpdatedAt,
                Genres = articleService.GetGenresForArticle(x.ArticleId)
                    .Select(x => new GenreDTO { GenreId = x.GenreId, Name = x.Name }),
                IsCompleted = x.IsCompleted,
                Chapters = articleService.GetChaptersForArticle(x.ArticleId)
                    .Select(x => new ChapterDTO { ChapterId = x.ChapterId, Title = x.Title }),
                Authors = articleService.GetAuthorsForArticle(x.ArticleId)
                    .Select(x => new AuthorDTO { AuthorId = x.AuthorId, Name = x.Name })
            });

            var pageInfoDTO = new PageInfoDTO
            {
                PageNumber = pagedArticles.PageNumber,
                PageSize = pagedArticles.PageSize,
                TotalItems = pagedArticles.TotalItemCount,
                TotalPages = pagedArticles.PageCount,
                HasPreviousPage = pagedArticles.HasPreviousPage,
                HasNextPage = pagedArticles.HasNextPage,
                NextPageUrl = controller.Url.Action(actionName, new { page = pagedArticles.PageNumber + 1, pageSize }),
                PreviousPageUrl = controller.Url.Action(actionName, new { page = pagedArticles.PageNumber - 1, pageSize })
            };

            var articleListDTO = new ArticleListDTO(articleDTOs, pageInfoDTO);

            return controller.Ok(articleListDTO);
        }
    }
}
