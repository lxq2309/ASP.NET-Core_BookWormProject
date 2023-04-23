using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();

        Article GetById(int id);

        void Add(Article article);

        void Update(Article article);

        void Delete(Article article);

        public IEnumerable<Genre>? GetGenresForArticle(int articleId);

        public IEnumerable<Chapter>? GetChaptersForArticle(int articleId);

        public Category? GetCategoryForArticle(int articleId);
        public IEnumerable<Author>? GetAuthorsForArticle(int articleId);
        public IEnumerable<Comment>? GetCommentsForArticle(int articleId);
    }
}