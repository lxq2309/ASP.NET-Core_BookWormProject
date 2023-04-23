using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class ArticleService : IArticleService
    {
        public readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void AddArticle(Article article)
        {
            _articleRepository.Add(article);
        }

        public void DeleteArticle(int id)
        {
            _articleRepository.Delete(GetArticleById(id));
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articleRepository.GetAll();
        }

        public Article GetArticleById(int id)
        {
            return _articleRepository.GetById(id);
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.Update(article);
        }

        public IEnumerable<Genre>? GetGenresForArticle(int articleId)
        {
            return _articleRepository.GetGenresForArticle(articleId).OrderByDescending(x => x.Name);
        }

        public IEnumerable<Chapter>? GetChaptersForArticle(int articleId)
        {
            return _articleRepository.GetChaptersForArticle(articleId);
        }

        public Category? GetCategoryForArticle(int articleId)
        {
            return _articleRepository.GetCategoryForArticle(articleId);
        }

        public IEnumerable<Author>? GetAuthorsForArticle(int articleId)
        {
            return _articleRepository.GetAuthorsForArticle(articleId).OrderByDescending(x => x.Name);
        }

        public IEnumerable<Comment>? GetCommentsForArticle(int articleId)
        {
            return _articleRepository.GetCommentsForArticle(articleId);
        }

        public Chapter? GetNewestChapterForArticle(int articleId)
        {
            return GetChaptersForArticle(articleId).MaxBy(x => x.Index);
        }
    }
}