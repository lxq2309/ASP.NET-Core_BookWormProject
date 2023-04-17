using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public class ReadHistoryRepository : IReadHistoryRepository
    {
        private readonly BookWormDbContext _context;

        public ReadHistoryRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(ReadHistory readHistory)
        {
            _context.ReadHistories.Add(readHistory);
            _context.SaveChanges();
        }

        public void Delete(ReadHistory readHistory)
        {
            _context.ReadHistories.Remove(readHistory);
            _context.SaveChanges();
        }

        public IEnumerable<ReadHistory> GetAll()
        {
            return _context.ReadHistories.ToList();
        }

        public ReadHistory GetBy(int userId, int articleId)
        {
            return _context.ReadHistories.SingleOrDefault(x => x.UserId == userId&& x.ArticleId == articleId);
        }

        public void Update(ReadHistory readHistory)
        {
            _context.ReadHistories.Update(readHistory);
            _context.SaveChanges();
        }
    }
}
