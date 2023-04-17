using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class ReadHistoryService : IReadHistoryService
    {
        private readonly IReadHistoryRepository _readHistoryRepository;

        public ReadHistoryService(IReadHistoryRepository readHistoryRepository)
        {
            _readHistoryRepository = readHistoryRepository;
        }

        public void AddReadHistory(ReadHistory readHistory)
        {
            _readHistoryRepository.Add(readHistory);
        }

        public void DeleteReadHistory(int userId, int articleId)
        {
            _readHistoryRepository.Delete(GetBy(userId, articleId));
        }

        public IEnumerable<ReadHistory> GetAllReadHistories()
        {
            return _readHistoryRepository.GetAll();
        }

        public ReadHistory GetBy(int userId, int articleId)
        {
            return _readHistoryRepository.GetBy(userId, articleId);
        }

        public void UpdateReadHistory(ReadHistory readHistory)
        {
            _readHistoryRepository.Update(readHistory);
        }
    }
}
