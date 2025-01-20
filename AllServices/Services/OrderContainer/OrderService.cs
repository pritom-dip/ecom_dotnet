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
                    throw new Exception($"{orderItem.ProductId} not found");
                }
                if (productPrice.Price != orderItem.Price)
                {
                    throw new Exception($"Price of this product id ({orderItem.ProductId}) is incorrect");
                }

                if (productPrice.Stock < orderItem.Quantity)
                {
                    throw new Exception($"Stock of this product id ({orderItem.ProductId}) is not enough");
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

            var shipping = createOrderDto.Shipping;
            var shippingDto = createOrderDto.ToCreateShippingDto(createdOrder.Id);

            var createOrderItems = createOrderDto.ToCreateOrderItem(createdOrder.Id);
            await _orderRepo.CreateOrderItem(createOrderItems);
            await _orderRepo.CreateShipping(shippingDto);
            return createdOrder;
        }

        public async Task<Order?> GetOrder(int id)
        {
            try
            {
                var order = await _orderRepo.Get(id);
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}