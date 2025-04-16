using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Repositories;
using BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(GenericRepository<,>));
builder.Services.AddScoped(typeof(CategoryService));
builder.Services.AddScoped(typeof(CategoryRepository));
builder.Services.AddScoped(typeof(CustomerService));
builder.Services.AddScoped(typeof(CustomerRepository));
builder.Services.AddScoped(typeof(EmployeeService));
builder.Services.AddScoped(typeof(EmployeeRepository));
builder.Services.AddScoped(typeof(Order_DetailService));
builder.Services.AddScoped(typeof(Order_DetailRepository));
builder.Services.AddScoped(typeof(OrderService));
builder.Services.AddScoped(typeof(OrderRepository));
builder.Services.AddScoped(typeof(ProductService));
builder.Services.AddScoped(typeof(ProductRepository));
builder.Services.AddScoped(typeof(ShipperService));
builder.Services.AddScoped(typeof(ShipperRepository));
builder.Services.AddScoped(typeof(SupplierService));
builder.Services.AddScoped(typeof(SupplierRepository));
builder.Services.AddScoped(typeof(TerritoryService));
builder.Services.AddScoped(typeof(TerritoryRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
