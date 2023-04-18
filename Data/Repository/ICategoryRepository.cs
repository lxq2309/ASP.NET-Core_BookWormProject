﻿using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category GetCategoryById(int id);

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);

        public IEnumerable<Genre>? GetGenresForCategory(int categorizationId);
        public IEnumerable<Article>? GetArticlesForCategory(int categorizationId);
    }
}