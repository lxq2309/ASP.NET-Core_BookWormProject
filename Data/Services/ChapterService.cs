using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;

        public ChapterService(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public void AddChapter(Chapter chapter)
        {
            _chapterRepository.Add(chapter);
        }

        public void DeleteChapter(int id)
        {
            _chapterRepository.Delete(GetById(id));
        }

        public IEnumerable<Chapter> GetAllChapters()
        {
            return _chapterRepository.GetAll();
        }

        public Chapter GetById(int id)
        {
            return _chapterRepository.GetById(id);
        }

        public void UpdateChapter(Chapter chapter)
        {
            _chapterRepository.Update(chapter);
        }
    }
}