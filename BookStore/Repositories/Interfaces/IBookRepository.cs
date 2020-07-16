using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll(bool isDeleted);
        Book GetById(int id);
        Book GetByTitle(string title);
        void Add(Book dbBook);
        void Update(Book dbBook);
    }
}
