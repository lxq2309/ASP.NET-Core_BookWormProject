using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAllArticles();

        Article GetArticleById(int id);

        void AddArticle(Article article);

        void UpdateArticle(Article article);

        void DeleteArticle(int id);

        IEnumerable<Genre> GetGenresForArticle(int articleId);

        IEnumerable<Chapter> GetChaptersForArticle(int articleId);

        IEnumerable<Author>? GetAuthorsForArticle(int articleId);
        IEnumerable<Comment>? GetCommentsForArticle(int articleId);
        Chapter? GetNewestChapterForArticle(int articleId);
        void IncreaseViewCount(Article article);
    }
}