using BookWormProject.Data.Services;
using BookWormProject.DTOs;
using BookWormProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpDelete("Delete")]
        public bool Delete(int bookmarkId)
        {
            var bookmark = _bookmarkService.GetById(bookmarkId);
            if (bookmark == null)
            {
                return false;
            }
            _bookmarkService.DeleteBookmark(bookmarkId);
            return true;
        }

        [HttpPost("Create")]
        public bool Create([FromBody] BookmarkDTO bookmark)
        {
            var check = _bookmarkService.GetByArticleId(bookmark.ArticleId);
            if (check != null)
            {
                return false;
            }
            var newBookmark = new Bookmark
            {
                Name = bookmark.Name,
                Description = bookmark.Description,
                IsPublic = bookmark.IsPublic,
                ArticleId = bookmark.ArticleId
            };
            _bookmarkService.AddBookmark(newBookmark);
            return true;
        }
    }
}
