using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using Models;

namespace DataAccess.Mappers
{
    public static class OrderMappers
    {

        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Total = order.Total,
                ShippingAddress = order.ShippingAddress,
                PaymentStatus = order.PaymentStatus,
                OrderStatus = order.OrderStatus,
                CreateAt = order.CreateAt,
                UpdatedAt = order.UpdatedAt,
                Customer = order.Customer,
                OrderItems = order.OrderItems.Select(oi => oi.ToOrderItemDto()).ToList(),
            };
        }

        public static Order ToCreateOrder(this CreateOrderDto createOrderDto)
        {
            return new Order
            {
                CustomerId = createOrderDto.CustomerId,
                OrderDate = createOrderDto.OrderDate,
                Total = createOrderDto.Total,
                ShippingAddress = createOrderDto.ShippingAddress,
                PaymentStatus = "pending",
                OrderStatus = "pending",
            };
        }
    }
}