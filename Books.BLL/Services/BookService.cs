using AutoMapper;
using Books.BLL.Interfaces;
using Books.Common.Entities;
using Books.Common.Models.Books;
using Books.DAL.Interfaces;

namespace Books.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;           
        }

        public Task<List<Book>> GetAll()
        {
            var books = _bookRepository.GetAll();

            return books;
        }

        public async Task<BookDTO> GetById(int id)
        {
            var book = await _bookRepository.GetById(id);

            var bookDTO = _mapper.Map<Book, BookDTO>(book);

            return bookDTO;
        }

        public List<Book> GetByIds(List<int> ids)
        {
            var books = _bookRepository.GetByIds(ids);

            return books;
        }

        public async Task<List<BookDTO>> GetFiltred(BookFilter filter)
        {
            filter.Name = filter.Name.ToLower();
            filter.Author = filter.Author.ToLower();
            
            var books = await _bookRepository.GetFiltredBooks(filter);

            var booksDTO = books.Select(_mapper.Map<Book, BookDTO>).ToList();

            return booksDTO;
        }
    }
}
