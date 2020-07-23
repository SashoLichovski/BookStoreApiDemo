using BookStore.DtoModels;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Returns all books from Db
        /// </summary>
        /// <returns>List<BookDto></returns>
        [HttpGet]
        public ActionResult<List<BookDto>> Get()
        {
            var bookList = bookService.GetAll(false);
            return Ok(bookList);
        }

        [HttpGet]
        [Route("deleted")]
        public ActionResult<List<BookDto>> GetDeleted()
        {
            var bookList = bookService.GetAll(true);
            return Ok(bookList);
        }

        /// <summary>
        /// Returns a specific book for the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookDto</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<BookDto> Get(int id)
        {
            var book = bookService.GetById(id);
            return Ok(book);
        }

        /// <summary>
        /// Returns a specific book by the given title
        /// </summary>
        /// <param name="title"></param>
        /// <returns>BookDto</returns>
        [HttpGet]
        [Route("title")]
        public ActionResult<BookDto> Get(string title)
        {
            var book = bookService.GetByTitle(title);
            return Ok(book);
        }

        /// <summary>
        /// Creates new instance of a book
        /// </summary>
        /// <param name="dtoBook"></param>
        [HttpPost]
        [Authorize]
        public IActionResult Create(BookDto dtoBook)
        {
            bookService.Create(dtoBook);
            return Ok();
        }

        /// <summary>
        /// Updates an existing book
        /// </summary>
        /// <param name="dtoBook"></param>
        [HttpPut]
        [Authorize]
        public IActionResult Update(BookDto dtoBook)
        {
            bookService.Update(dtoBook);
            return Ok();
        }
    }
}
