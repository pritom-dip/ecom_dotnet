using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.PaymentDto;
using Models;

namespace AllServices.Services.PaymentContainer
{
    public interface IPaymentService
    {
        Task<Payment?> CreatePayment(CreatePaymentDto createPaymentDto);
    }
}