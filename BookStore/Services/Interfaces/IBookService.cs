using BookStore.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Gets all books from Db
        /// </summary>
        /// <returns>List<BookDto></returns>
        List<BookDto> GetAll(bool isDeleted);

        /// <summary>
        /// Gets a specific book for the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookDto</returns>
        BookDto GetById(int id);

        /// <summary>
        /// Gets a specific book for the given title,
        /// If not found returns empty instance of a book
        /// </summary>
        /// <param name="title"></param>
        /// <returns>BookDto</returns>
        BookDto GetByTitle(string title);

        /// <summary>
        /// Creates new instace of a Book entity and passes to repository
        /// </summary>
        /// <param name="dtoBook"></param>
        void Create(BookDto dtoBook);

        /// <summary>
        /// Updates an existing book
        /// </summary>
        /// <param name="dtoBook"></param>
        void Update(BookDto dtoBook);
    }
}
