using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AllServices.Seeder
{
    public class Seeder
    {
        private readonly ApplicationDbContext _context;
        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Change name in here
            if (await _context.Products.AnyAsync())
            {
                Console.WriteLine("Data already exists");
                return;
            }

            var currentDirectory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDirectory, "../AllServices/Resources", "product-data.json");
            Console.WriteLine(filePath);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }

            try
            {
                var data = JsonConvert.DeserializeObject<List<Product>>(await File.ReadAllTextAsync(filePath));
                Console.WriteLine(data.Count);

                // Change name in here
                await _context.Products.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting customer data: {ex.Message}");
            }


        }
    }
}