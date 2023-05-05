using BookWormProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWormProject.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookWormDbContext _context;

        public CategoryRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            category.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Where(x => x.IsDeleted == null).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.SingleOrDefault(x => x.IsDeleted == null && x.CategoryId == id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public IEnumerable<Genre>? GetGenresForCategory(int categorizationId)
        {
            var category = _context.Categories.Include(x => x.Genres).FirstOrDefault(x => x.IsDeleted == null && x.CategoryId == categorizationId);
            if (category != null)
            {
                return category.Genres;
            }
            return null;
        }

        public IEnumerable<Article>? GetArticlesForCategory(int categorizationId)
        {
            var category = _context.Categories.Include(x => x.Articles)
                .FirstOrDefault(x => x.IsDeleted == null && x.CategoryId == categorizationId);
            if (category != null)
            {
                return category.Articles;
            }
            return null;
        }

    }
}