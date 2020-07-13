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

        [HttpPost]
        public ActionResult<CreateOrderDto> Create(CreateOrderDto model)
        {
            var trackingNo = orderService.Create(model);
            return Ok(trackingNo);
        }

        [HttpGet]
        [Route("track")]
        public IActionResult Get(string email, string trackingNumber)
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
