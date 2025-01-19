using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using DataAccess.Dtos.OrderItemDto;
using Models;

namespace DataAccess.Mappers
{
    public static class OrderItemMappers
    {
        public static List<OrderItem> ToCreateOrderItem(this CreateOrderDto createOrderDto, int id)
        {
            var orderItems = new List<OrderItem>();
            foreach (var item in createOrderDto.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Total = item.Total
                };
                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public static OrderItemDto ToOrderItemDto(this OrderItem orderItem)
        {
            return new OrderItemDto
            {
                Id = orderItem.Id,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price,
                Total = orderItem.Total,
                OrderId = orderItem.OrderId,
                CreateAt = orderItem.CreateAt,
                UpdatedAt = orderItem.UpdatedAt
            };
        }
    }
}