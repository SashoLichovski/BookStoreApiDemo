using BookStore.Data;
using BookStore.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BookStore.Helpers
{
    public static class Convert
    {
        public static BookDto ToBookDto(this Book x)
        {
            return new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Author = x.Author,
                Genre = x.Genre,
                Price = x.Price,
                Quantity = x.Quantity
            };
        }

        public static Book ToBookEntity(this BookDto x)
        {
            return new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Author = x.Author,
                Genre = x.Genre,
                Price = x.Price,
                Quantity = x.Quantity
            };
        }
    }
}
