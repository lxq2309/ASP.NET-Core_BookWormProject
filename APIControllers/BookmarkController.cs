using BookWormProject.Data.Services;
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
    }
}
