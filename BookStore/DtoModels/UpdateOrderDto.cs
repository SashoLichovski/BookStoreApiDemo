using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DtoModels
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public EnumStatus Status { get; set; }
    }
}
