using BookStore.Data;
using BookStore.DtoModels;
using BookStore.Helpers;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public void Create(BookDto dtoBook)
        {
            var dbBook = dtoBook.ToBookEntity();
            bookRepo.Add(dbBook);
        }

        public List<BookDto> GetAll(bool isDeleted)
        {
            var dbBooks = bookRepo.GetAll(isDeleted);
            var dtoModels = dbBooks.Select(x => x.ToBookDto()).ToList();
            return dtoModels;
        }

        public BookDto GetById(int id)
        {
            var dbBook = bookRepo.GetById(id);
            if (dbBook != null)
            {
                var dtoBook = dbBook.ToBookDto();
                return dtoBook;
            }
            return new BookDto();
        }

        public BookDto GetByTitle(string title)
        {
            var dbBook = bookRepo.GetByTitle(title);
            if (dbBook != null)
            {
                var dtoBook = dbBook.ToBookDto();
                return dtoBook;
            }
            return new BookDto();
        }

        public void Update(BookDto dtoBook)
        {
            var dbBook = bookRepo.GetById(dtoBook.Id);
            if (dbBook != null)
            {
                dbBook.Title = dtoBook.Title;
                dbBook.Description = dtoBook.Description;
                dbBook.Author = dtoBook.Author;
                dbBook.Price = dtoBook.Price;
                dbBook.Genre = dtoBook.Genre;
                dbBook.Quantity = dtoBook.Quantity;
                dbBook.IsDeleted = dtoBook.IsDeleted;
                bookRepo.Update(dbBook);
            }
        }
    }
}
