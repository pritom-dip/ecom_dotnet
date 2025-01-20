using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace AllServices.Services.PaymentContainer
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> Create(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Order?> GetOrder(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<Order?> UpdateOrder(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                return null;
            }
            existingOrder.OrderStatus = "completed";
            existingOrder.PaymentStatus = "paid";
            await _context.SaveChangesAsync();
            return existingOrder;
        }
    }
}