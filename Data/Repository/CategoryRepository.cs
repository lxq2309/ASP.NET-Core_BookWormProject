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
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.SingleOrDefault(x =>  x.CategoryId == id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }


    }
}