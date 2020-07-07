using BookStore.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(int id);
        BookDto GetByTitle(string title);
        void Create(BookDto dtoBook);
        void Update(BookDto dtoBook);
    }
}
