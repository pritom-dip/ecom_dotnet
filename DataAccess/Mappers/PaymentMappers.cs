using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.PaymentDto;
using Models;

namespace DataAccess.Mappers
{
    public static class PaymentMappers
    {
        public static Payment ToCreatePayment(this CreatePaymentDto createPaymentDto)
        {
            return new Payment
            {
                OrderId = createPaymentDto.OrderId,
                PaymentMethod = createPaymentDto.PaymentMethod,
                PaymentStatus = "completed",
                Amount = createPaymentDto.Amount,
                PaymentDate = createPaymentDto.PaymentDate
            };
        }

        public static PaymentDto ToCreatePaymentDto(this Payment payment)
        {
            return new PaymentDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                CreateAt = payment.CreateAt,
                UpdatedAt = payment.UpdatedAt,
                Order = payment.Order.ToOrderDto()
            };
        }
    }
}