using csharp_webapi_example.Services;
using csharp_webapi_example.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace csharp_webapi_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }
        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody]BookVM book)
        {
            var _book = _bookService.UpdateBookById(id, book);
            return Ok(_book);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            _bookService.Delete(id);
            return Ok();
        }
    }
}
