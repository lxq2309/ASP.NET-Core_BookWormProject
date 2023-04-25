using BookWormProject.ViewModels.Bookmark;
using X.PagedList;

namespace BookWormProject.ViewModels.User
{
    public class UserBookmarksViewModel
    {
        public IPagedList<BookmarkDetailViewModel> PagedBookmarks { get; set; }
        public bool IsMyAccount { get; set; } 
    }
}
