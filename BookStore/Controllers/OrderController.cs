using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DtoModels;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Creates new instace of Order and OrderBooks realtion for the order and the books in same order
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public IActionResult Create(CreateOrderDto model)
        {
            if (ModelState.IsValid)
            {
                if (orderService.CheckBookQuantity(model.BookIds))
                {
                    var trackingNo = orderService.Create(model);
                    return Ok(trackingNo);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }

        /// <summary>
        /// Returns a specific order for the given email and tracking number,
        /// BadRequest if one of the params is null or empty,
        /// NotFound if the order is not found for the given params
        /// </summary>
        /// <param name="email"></param>
        /// <param name="trackingNumber"></param>
        /// <returns>OrderDto</returns>
        [HttpGet]
        [Route("track")]
        public ActionResult<OrderDto> Get(string email, string trackingNumber)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(trackingNumber))
            {
                return BadRequest();
            }
            else if (!orderService.CheckOrder(email, trackingNumber))
            {
                return NotFound();
            }
            var order = orderService.GetOrder(email, trackingNumber);
            order.BookTitles = orderService.GetOrderBooks(order.Id);
            return Ok(order);
        }
    }
}
