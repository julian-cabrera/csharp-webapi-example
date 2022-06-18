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
            _bookService.AddBook(book);
            return Ok();
        }
    }
}
