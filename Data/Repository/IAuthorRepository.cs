using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
