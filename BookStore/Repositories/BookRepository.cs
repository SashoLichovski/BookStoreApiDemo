using BookStore.Data;
using BookStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Book dbBook)
        {
            context.Books.Add(dbBook);
            context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

        public Book GetByTitle(string title)
        {
            return context.Books.FirstOrDefault(x => x.Title == title);
        }

        public void Update(Book dbBook)
        {
            context.Books.Update(dbBook);
            context.SaveChanges();
        }
    }
}
