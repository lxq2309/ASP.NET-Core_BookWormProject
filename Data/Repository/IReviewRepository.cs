using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();

        Review GetById(int id);

        void Add(Review review);

        void Update(Review review);

        void Delete(Review review);
    }
}