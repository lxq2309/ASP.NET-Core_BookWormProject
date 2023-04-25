using BookWormProject.Models;
using BookWormProject.ViewModels.Article;
using BookWormProject.ViewModels.Bookmark;
using BookWormProject.ViewModels.Comment;

namespace BookWormProject.ViewModels.User
{
    public class UserGeneralInfoViewModel
    {
        public UserGeneralInfoViewModel(Models.User currentUser, List<BookmarkDetailViewModel> bookmarks, List<CommentDetailViewModel> commentsForCurrentUser)
        {
            CurrentUser = currentUser;
            Bookmarks = bookmarks;
            CommentsForCurrentUser = commentsForCurrentUser;
        }

        public Models.User CurrentUser { get; set; }
        public List<BookmarkDetailViewModel> Bookmarks { get; set; }
        public List<CommentDetailViewModel> CommentsForCurrentUser { get; set; }
        public bool IsMyAccount { get; set; }
    }
}
