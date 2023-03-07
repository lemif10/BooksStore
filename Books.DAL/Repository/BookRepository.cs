using Books.Common.Entities;
using Books.Common.Models.Books;
using Books.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Books.DAL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _applicationContext;

        public BookRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Book>> GetAll()
        {
            var books = await _applicationContext.Books.ToListAsync();

            return books;
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _applicationContext.Books.SingleOrDefaultAsync(book => book.Id == id) ?? new Book();

            return book;
        }

        public List<Book> GetByIds(List<int> ids)
        {
            var books =  _applicationContext.Books.Where(book => ids.Contains(book.Id)).ToList();

            return books;
        }

        public async Task<List<Book>> GetFiltredBooks(BookFilter filter)
        {
            var query = _applicationContext.Books.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(book => book.Name.ToLower().Contains(filter.Name));
            }

            if (!string.IsNullOrEmpty(filter.Author))
            {
                query = query.Where(book => book.Author.ToLower().Contains(filter.Author));
            }
            if (filter.Year is not 0)
            {
                query = query.Where(book => book.ReleaseDate.Year == filter.Year);
            }
            if (filter.Month is not 0)
            {
                query = query.Where(book => book.ReleaseDate.Month == filter.Month);
            }
            if (filter.Day is not 0)
            {
                query = query.Where(book => book.ReleaseDate.Day == filter.Day);
            }

            var books = await query.ToListAsync();

            return books;
        }
    }
}
