using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly BookWormDbContext _context;

        public ChapterRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
            _context.SaveChanges();
        }

        public void Delete(Chapter chapter)
        {
            _context.Chapters.Remove(chapter);
            _context.SaveChanges();
        }

        public IEnumerable<Chapter> GetAll()
        {
            return _context.Chapters.ToList();
        }

        public Chapter GetById(int id)
        {
            return _context.Chapters.SingleOrDefault(x => x.ChapterId == id);
        }

        public void Update(Chapter chapter)
        {
            _context.Chapters.Update(chapter);
            _context.SaveChanges();
        }
    }
}