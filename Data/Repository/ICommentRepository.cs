using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();

        Comment GetById(int id);

        void Add(Comment comment);

        void Update(Comment comment);

        void Delete(Comment comment);
        public User GetUserForComment(int commentId);
    }
}