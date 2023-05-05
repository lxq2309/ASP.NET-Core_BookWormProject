using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IChapterService
    {
        IEnumerable<Chapter> GetAllChapters();

        Chapter GetById(int id);

        void AddChapter(Chapter chapter);

        void UpdateChapter(Chapter chapter);

        void DeleteChapter(int id);
        Chapter? GetChapterByIndex(int articleId, int index);
        IEnumerable<Chapter>? GetChapterByArticleId(int articleId);
        int GetNewestChapterIndex (int articleId);
    }
}