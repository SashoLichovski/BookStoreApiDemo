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
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
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

        public List<BookOrders> GetOrderBooks(int orderId)
        {
            return context.BookOrders.Where(x => x.OrderId == orderId).ToList();
        }
    }
}
