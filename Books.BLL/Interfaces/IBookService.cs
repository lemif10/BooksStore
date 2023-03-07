using Books.Common.Entities;
using Books.Common.Models.Books;

namespace Books.BLL.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();

        Task<BookDTO> GetById(int id);

        List<Book> GetByIds(List<int> ids);

        Task<List<BookDTO>> GetFiltred(BookFilter filter);      
    }
}
