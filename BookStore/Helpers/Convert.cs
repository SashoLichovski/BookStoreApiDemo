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
                Quantity = x.Quantity,
                IsDeleted = x.IsDeleted
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
                Quantity = x.Quantity,
                IsDeleted = x.IsDeleted
            };
        }

        public static OrderDto ToOrderDto(this Order x)
        {
            return new OrderDto
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Adress = x.Adress,
                Email = x.Email,
                FullPrice = x.FullPrice,
                TrackingNumber = x.TrackingNumber,
                Status = x.Status.ToString()
            };
        }
    }
}
