using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace AllServices.Services.PaymentContainer
{
    public interface IPaymentRepository
    {
        Task<Payment> Create(Payment payment);
        Task<Order?> GetOrder(int orderId);
        Task<Order?> UpdateOrder(Order order);
    }
}