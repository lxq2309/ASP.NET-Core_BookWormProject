using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        public IEnumerable<Genre>? GetGenresForCategory(int categorizationId);
    }
}
