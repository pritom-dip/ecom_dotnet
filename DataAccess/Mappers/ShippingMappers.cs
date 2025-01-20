using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using DataAccess.Dtos.ShippingDto;
using Models;

namespace DataAccess.Mappers
{
    public static class ShippingMappers
    {
        public static ShippingDto ToShippingDto(this Shipping shipping)
        {
            return new ShippingDto
            {
                Id = shipping.Id,
                ShippingMethod = shipping.ShippingMethod,
                TrackingNumber = shipping.TrackingNumber,
                ShippingStatus = shipping.ShippingStatus,
                EstimatedArrival = shipping.EstimatedArrival,
                ShippingDate = shipping.ShippingDate,
                CreateAt = shipping.CreateAt,
                UpdatedAt = shipping.UpdatedAt
            };
        }

        public static Shipping ToCreateShippingDto(this CreateOrderDto createOrderDto, int id)
        {

            return new Shipping
            {
                OrderId = id,
                ShippingMethod = createOrderDto.Shipping.ShippingMethod,
                TrackingNumber = createOrderDto.Shipping.TrackingNumber,
                ShippingStatus = createOrderDto.Shipping.ShippingStatus,
                EstimatedArrival = createOrderDto.Shipping.EstimatedArrival
            };
        }
    }
}