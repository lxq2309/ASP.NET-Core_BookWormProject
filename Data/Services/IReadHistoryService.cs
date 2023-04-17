using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IReadHistoryService
    {
        IEnumerable<ReadHistory> GetAllReadHistories();

        ReadHistory GetBy(int userId, int articleId);

        void AddReadHistory(ReadHistory readHistory);

        void UpdateReadHistory(ReadHistory readHistory);

        void DeleteReadHistory(int userId, int articleId);
    }
}