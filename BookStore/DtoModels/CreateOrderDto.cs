﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DtoModels
{
    public class CreateOrderDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public List<int> BookIds { get; set; }
    }
}
