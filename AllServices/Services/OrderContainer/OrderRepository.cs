using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Models;

namespace AllServices.Services.OrderContainer
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<OrderItem>> CreateOrderItem(List<OrderItem> orderItems)
        {
            await _context.OrderItems.AddRangeAsync(orderItems);
            await _context.SaveChangesAsync();
            return orderItems;
        }

        public async Task<Order?> Get(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
    }
}