using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments();

        Comment GetById(int id);

        void AddComment(Comment comment);

        void UpdateComment(Comment comment);

        void DeleteComment(int id);
        public User GetUserForComment(int commentId);
    }
}