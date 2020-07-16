using BookStore.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Creates new instace of Order and OrderBooks realtion for the order and the books in same order
        /// </summary>
        /// <param name="model"></param>
        string Create(CreateOrderDto model);

        /// <summary>
        /// Checks if order exists
        /// </summary>
        /// <param name="email"></param>
        /// <param name="trackingNumber"></param>
        /// <returns>Bool</returns>
        bool CheckOrder(string email, string trackingNumber);
        bool CheckBookQuantity(List<int> bookIds);

        /// <summary>
        /// Gets specific order for the given email and tracking number
        /// </summary>
        /// <param name="email"></param>
        /// <param name="trackingNumber"></param>
        /// <returns>OrderDto</returns>
        OrderDto GetOrder(string email, string trackingNumber);

        /// <summary>
        /// Gets a list of book titles which are included in a specific order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>List<string></returns>
        List<string> GetOrderBooks(int orderId);
    }
}
