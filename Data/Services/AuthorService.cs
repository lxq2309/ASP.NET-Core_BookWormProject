using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.Add(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(GetAuthorById(id));
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public IEnumerable<Article>? GetArticlesForAuthor(int id)
        {
            return _authorRepository.GetArticlesForAuthor(id);
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
