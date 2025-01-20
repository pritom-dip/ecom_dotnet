using AllServices.Seeder;
using AllServices.Services.CategoryContainer;
using AllServices.Services.CustomerContainer;
using AllServices.Services.OrderContainer;
using AllServices.Services.PaymentContainer;
using AllServices.Services.ProductContainer;
using AllServices.Services.ReviewContainer;
using AllServices.Services.UserContainer;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Controller Services
builder.Services.AddControllers();

// Adding database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Api"));
});

// Adding services with Interfaces
// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// Customer
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
// Category
builder.Services.AddScoped<IcategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Review
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();

// Order & OrderItems
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Payment
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Build the container
var app = builder.Build();

// Seed Data
// using (var scope = app.Services.CreateScope())
// {
//     Console.WriteLine("Data Seeding");
//     var services = scope.ServiceProvider;
//     var dataSeeder = new Seeder(services.GetRequiredService<ApplicationDbContext>());
//     await dataSeeder.SeedAsync();
//     Console.WriteLine("Data Seeded");
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Mapping through Controllers
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


