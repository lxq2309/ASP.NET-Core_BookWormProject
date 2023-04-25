using BookWormProject.ViewModels.Comment;
using X.PagedList;

namespace BookWormProject.ViewModels.User
{
    public class UserCommentsViewModel
    {
        public IPagedList<CommentDetailViewModel> PagedComments { get; set; }
        public bool IsMyAccount { get; set; }
    }
}
