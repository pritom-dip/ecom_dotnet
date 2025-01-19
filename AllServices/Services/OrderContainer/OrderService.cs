using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using DataAccess.Mappers;
using Models;

namespace AllServices.Services.OrderContainer
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }

        public async Task<Order> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = createOrderDto.ToCreateOrder();
            var createdOrder = await _orderRepo.Create(order);
            var orderItems = createOrderDto.ToCreateOrderItem(createdOrder.Id);
            await _orderRepo.CreateOrderItem(orderItems);
            Normal();
            return createdOrder;
        }

        public async Task<Order?> GetOrder(int id)
        {
            var order = await _orderRepo.Get(id);
            return order;
        }

        public void Normal()
        {
            Console.WriteLine("Normal");
        }
    }
}