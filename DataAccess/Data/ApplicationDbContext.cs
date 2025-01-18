using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder){
        //     base.OnModelCreating(builder);
        //     builder.Entity<User>().HasData(
        //         new User {
        //             Id = 1,
        //             Username = "Admin",
        //             Email = "pritom@gmail.com",
        //             Password = "123456",
        //             Role = "Admin"

        //         }, 
        //         new User {
        //             Id = 2,
        //             Username = "User",
        //             Email = "Shormi@gmail.com",
        //             Password = "123456",
        //             Role = "User"
        //         }
        //     );
        // }

    }
}