using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(GetCategoryById(id));
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public IEnumerable<Genre>? GetGenresForCategory(int categorizationId)
        {
            return _categoryRepository.GetGenresForCategory(categorizationId);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}