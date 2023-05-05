using BookWormProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWormProject.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BookWormDbContext _context;

        public ArticleRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Article article)
        {
            _context.Add(article);
            _context.SaveChanges();
        }

        public void Delete(Article article)
        {
            article.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles.Where(x => x.IsDeleted == null).ToList();
        }

        public Article GetById(int id)
        {
            return _context.Articles.SingleOrDefault(x => x.IsDeleted == null && x.ArticleId == id);
        }

        public void Update(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public IEnumerable<Genre>? GetGenresForArticle(int articleId)
        {
            var article = _context.Articles.Include(x => x.Genres).FirstOrDefault(x => x.IsDeleted == null && x.ArticleId == articleId);
            if (article != null)
            {
                return article.Genres;
            }
            return null;
        }

        public IEnumerable<Chapter>? GetChaptersForArticle(int articleId)
        {
            var article = _context.Articles.Include(x => x.Chapters).FirstOrDefault(x => x.IsDeleted == null && x.ArticleId == articleId);
            if (article != null)
            {
                return article.Chapters;
            }
            return null;
        }

        public Category? GetCategoryForArticle(int articleId)
        {
            var article = _context.Articles.Include(x => x.Category).SingleOrDefault(x => x.IsDeleted == null && x.ArticleId == articleId);
            if (article != null)
            {
                return article.Category;
            }
            return null;
        }

        public IEnumerable<Author>? GetAuthorsForArticle(int articleId)
        {
            var article = _context.Articles.Include(x => x.Authors).SingleOrDefault(x => x.IsDeleted == null && x.ArticleId == articleId);
            if (article != null)
            {
                return article.Authors;
            }
            return null;
        }

        public IEnumerable<Comment>? GetCommentsForArticle(int articleId)
        {
            var article = _context.Articles.Include(x => x.Comments).SingleOrDefault(x => x.IsDeleted == null && x.ArticleId == articleId);
            if (article != null)
            {
                return article.Comments;
            }
            return null;
        }
    }
}