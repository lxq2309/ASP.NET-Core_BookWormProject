using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IReadHistoryRepository
    {
        IEnumerable<ReadHistory> GetAll();
        ReadHistory GetBy(int userId, int articleId);
        void Add(ReadHistory readHistory);
        void Update(ReadHistory readHistory);
        void Delete(ReadHistory readHistory);
    }
}
