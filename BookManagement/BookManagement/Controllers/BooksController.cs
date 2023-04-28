using BusinessLogic.Services;
using DataAccess.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService) 
        { 
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var result = _bookService.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.Add(book);

            return Ok();
        }
    }
}
