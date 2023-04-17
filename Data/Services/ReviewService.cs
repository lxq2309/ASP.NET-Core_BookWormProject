using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(Review review)
        {
            _reviewRepository.Add(review);
        }

        public void DeleteReview(int id)
        {
            _reviewRepository.Delete(GetById(id));
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepository.GetAll();
        }

        public Review GetById(int id)
        {
            return _reviewRepository.GetById(id);
        }

        public void UpdateReview(Review review)
        {
            _reviewRepository.Update(review);
        }
    }
}
