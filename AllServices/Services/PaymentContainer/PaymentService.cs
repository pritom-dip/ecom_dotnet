using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.PaymentDto;
using DataAccess.Mappers;
using Models;

namespace AllServices.Services.PaymentContainer
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        public PaymentService(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        public async Task<Payment?> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = createPaymentDto.ToCreatePaymentDto();
            var order = await _paymentRepo.GetOrder(payment.OrderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            Console.WriteLine(order.OrderStatus);

            if (order.Total != payment.Amount)
            {
                throw new Exception("Payment amount does not match order total");
            }

            var createdPayment = await _paymentRepo.Create(payment);
            if (createdPayment == null)
            {
                throw new Exception("Payment not created");
            }
            var updatePayment = await _paymentRepo.UpdateOrder(order);
            return createdPayment;
        }
    }
}