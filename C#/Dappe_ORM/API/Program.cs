using BLL.Services;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped(typeof(GenericRepository<,>));
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CategoryRepository>(provider => new CategoryRepository(connectionString));
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<CustomerRepository>(provider => new CustomerRepository(connectionString));
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmployeeRepository>(provider => new EmployeeRepository(connectionString));
builder.Services.AddScoped<Order_DetailService>();
builder.Services.AddScoped<Order_DetailRepository>(provider => new Order_DetailRepository(connectionString));
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderRepository>(provider => new OrderRepository(connectionString));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepository>(provider => new ProductRepository(connectionString));
builder.Services.AddScoped<ShipperService>();
builder.Services.AddScoped<ShipperRepository>(provider => new ShipperRepository(connectionString));
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<SupplierRepository>(provider => new SupplierRepository(connectionString));
builder.Services.AddScoped<TerritoryService>();
builder.Services.AddScoped<TerritoryRepository>(provider => new TerritoryRepository(connectionString));
builder.Services.AddScoped<TestDatumService>();
builder.Services.AddScoped<TestDatumRepository>(provider => new TestDatumRepository(connectionString));

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
