using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DtoModels
{
    public class TrackOrderDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string TrackingNumber { get; set; }
    }
}
