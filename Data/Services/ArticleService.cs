using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserService _userService;

        public ArticleService(IArticleRepository articleRepository, IUserService userService)
        {
            _articleRepository = articleRepository;
            _userService = userService;
        }

        public void AddArticle(Article article)
        {
            if (article.Description == null)
            {
                article.Description = "Chưa có mô tả dành cho bài viết này";
            }
            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;
            article.UserId = _userService.GetCurrentUserId();
            article.ViewCount = 0;
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
            article.UpdatedAt = DateTime.Now;
            _articleRepository.Update(article);
        }

        public void IncreaseViewCount(Article article)
        {
            article.ViewCount++;
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
            var chapters = GetChaptersForArticle(articleId);
            if (chapters == null)
            {
                return null;
            }
            return chapters.MaxBy(x => x.ChapterId);
        }
    }
}