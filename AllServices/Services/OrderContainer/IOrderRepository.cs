using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using Models;

namespace AllServices.Services.OrderContainer
{
    public interface IOrderRepository
    {
        Task<Order> Create(Order order);

        Task<List<OrderItem>> CreateOrderItem(List<OrderItem> orderItems);

        Task<Order?> Get(int id);

    }
}