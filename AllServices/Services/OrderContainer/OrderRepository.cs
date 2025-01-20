using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AllServices.Services.OrderContainer
{
    public class ProductPriceAndQuantity
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
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
            return await _context.Orders.Include(o => o.OrderItems).Include(or => or.Payment).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<ProductPriceAndQuantity>> GetProductPrice(List<int> ids)
        {
            var products = await _context.Products.Where(p => ids.Contains(p.Id))
                                        .Select(p => new ProductPriceAndQuantity
                                        {
                                            ProductId = p.Id,
                                            Price = p.Price,
                                            Stock = p.StockQty
                                        }).ToListAsync();
            return products;
        }
    }
}