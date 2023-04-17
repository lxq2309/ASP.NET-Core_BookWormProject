using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IChapterRepository
    {
        IEnumerable<Chapter> GetAll();
        Chapter GetById(int id);
        void Add(Chapter chapter);
        void Update(Chapter chapter);
        void Delete(Chapter chapter);
    }
}
