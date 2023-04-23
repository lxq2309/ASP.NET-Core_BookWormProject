using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        IEnumerable<Article>? GetArticlesForAuthor(int id);
    }
}
