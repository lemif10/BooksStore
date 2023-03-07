using Books.Common.Entities;
using Books.Common.Models.Books;

namespace Books.DAL.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book> GetById(int id);

        List<Book> GetByIds(List<int> ids);

        Task<List<Book>> GetFiltredBooks(BookFilter filter);
    }
}
