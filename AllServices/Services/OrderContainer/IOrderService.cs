using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using Models;

namespace AllServices.Services.OrderContainer
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(CreateOrderDto createOrderDto);

        Task<Order?> GetOrder(int id);
    }
}