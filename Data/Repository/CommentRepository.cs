using BookWormProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWormProject.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BookWormDbContext _context;

        public CommentRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.SingleOrDefault(x => x.CommentId == id);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public User GetUserForComment(int commentId)
        {
            var comment = _context.Comments.Include(x => x.User).FirstOrDefault(x => x.CommentId == commentId);
            if (comment != null)
            {
                return comment.User;
            }

            return null;
        }
    }
}