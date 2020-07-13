using BookStore.DtoModels;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<BookDto>> Get()
        {
            var bookList = bookService.GetAll();
            return Ok(bookList);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<BookDto> Get(int id)
        {
            var book = bookService.GetById(id);
            return Ok(book);
        }

        [HttpGet]
        [Route("title")]
        public ActionResult<BookDto> Get(string title)
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
