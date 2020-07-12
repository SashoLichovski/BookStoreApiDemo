using BookStore.DtoModels;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bookList = bookService.GetAll();
            return Ok(bookList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var book = bookService.GetById(id);
            return Ok(book);
        }

        [HttpGet]
        [Route("title")]
        public IActionResult Get(string title)
        {
            var book = bookService.GetByTitle(title);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(BookDto dtoBook)
        {
            bookService.Create(dtoBook);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(BookDto dtoBook)
        {
            bookService.Update(dtoBook);
            return Ok();
        }
    }
}
