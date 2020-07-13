﻿using BookStore.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IOrderService
    {
        string Create(CreateOrderDto model);
    }
}