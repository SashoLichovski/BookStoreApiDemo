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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepo;
        private readonly IBookService bookService;

        public OrderService(IOrderRepository orderRepo, IBookService bookService)
        {
            this.orderRepo = orderRepo;
            this.bookService = bookService;
        }

        public string Create(CreateOrderDto model)
        {
            var order = new Order()
            {
                Name = model.Name,
                Adress = model.Adress,
                Email = model.Email,
                Phone = model.Phone,
                BookOrders = model.BookIds.Select(x => new BookOrders
                {
                    BookId = x
                }).ToList(),
                TrackingNumber = Generate.TrackingNumber(6),
                FullPrice = model.BookIds.Sum(x => bookService.GetById(x).Price)
            };

            orderRepo.Add(order);

            return order.TrackingNumber;
        }
    }
}
