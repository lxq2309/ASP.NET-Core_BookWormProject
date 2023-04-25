using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserService _userService;

        public CommentService(ICommentRepository commentRepository, IUserService userService)
        {
            _commentRepository = commentRepository;
            _userService = userService;
        }

        public void AddComment(Comment comment)
        {
            comment.UserId = _userService.GetCurrentUserId();
            comment.CreatedAt = DateTime.Now;
            _commentRepository.Add(comment);
        }

        public void DeleteComment(int id)
        {
            _commentRepository.Delete(GetById(id));
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public void UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
        }

        public User GetUserForComment(int commentId)
        {
            return _commentRepository.GetUserForComment(commentId);
        }
    }
}