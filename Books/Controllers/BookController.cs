using Books.BLL.Interfaces;
using Books.Common.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) 
        {
            _bookService = bookService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var books = await _bookService.GetAll();

                return Ok(books);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("GetById")]
        [HttpPost]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var bookDTO = await _bookService.GetById(id);

                return Ok(bookDTO);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("GetFiltred")]
        [HttpPost]
        public async Task<ActionResult> GetFiltred(BookFilter filter)
        {
            try
            {
                var bookDTO = await _bookService.GetFiltred(filter);

                return Ok(bookDTO);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
