using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookWormDbContext _context;

        public ReviewRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews.SingleOrDefault(x => x.ReviewId == id);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
        }
    }
}
