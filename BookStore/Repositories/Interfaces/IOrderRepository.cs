using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order FindOrder(string email, string trackingNumber);
        List<BookOrders> GetOrderBooks(int orderId);
    }
}
