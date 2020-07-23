using BookStore.Data;
using BookStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public Order FindOrder(string email, string trackingNumber)
        {
            return context.Orders.FirstOrDefault(x => x.Email == email && x.TrackingNumber == trackingNumber);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int orderId)
        {
            return context.Orders.FirstOrDefault(x => x.Id == orderId);
        }

        public List<BookOrders> GetOrderBooks(int orderId)
        {
            return context.BookOrders.Where(x => x.OrderId == orderId).ToList();
        }

        public void Update(Order dbOrder)
        {
            context.Orders.Update(dbOrder);
            context.SaveChanges();
        }
    }
}
