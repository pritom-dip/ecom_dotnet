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
            var orderItems = createOrderDto.OrderItems;

            // Calculate total
            decimal total = orderItems.Sum(x => x.Quantity * x.Price);

            if (total != createOrderDto.Total)
            {
                throw new Exception("Total is not correct");
            }

            // Checking for the product and its prices
            List<int> productIds = orderItems.Select(x => x.ProductId).ToList();
            var productPrices = await _orderRepo.GetProductPrice(productIds);

            foreach (var orderItem in orderItems)
            {
                var productPrice = productPrices.FirstOrDefault(x => x.ProductId == orderItem.ProductId);
                if (productPrice == null)
                {
                    throw new Exception("Product not found");
                }
                if (productPrice.Price != orderItem.Price)
                {
                    throw new Exception("Price is not correct");
                }
            }

            // Check if all the total are correct
            decimal productPricesTotal = productPrices.Select(x => x.Price).ToList().Sum();
            if (total != productPricesTotal)
            {
                throw new Exception("No cheating");
            }

            var order = createOrderDto.ToCreateOrder();
            var createdOrder = await _orderRepo.Create(order);
            var createOrderItems = createOrderDto.ToCreateOrderItem(createdOrder.Id);
            await _orderRepo.CreateOrderItem(createOrderItems);
            return createdOrder;
        }

        public async Task<Order?> GetOrder(int id)
        {
            var order = await _orderRepo.Get(id);
            return order;
        }
    }
}