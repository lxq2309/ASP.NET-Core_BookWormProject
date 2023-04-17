using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAllReviews();

        Review GetById(int id);

        void AddReview(Review review);

        void UpdateReview(Review review);

        void DeleteReview(int id);
    }
}