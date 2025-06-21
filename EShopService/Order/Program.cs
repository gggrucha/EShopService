using Order.Application.Services;
//using Order.Domain.Interfaces;  //pki co nie potrzebne
using Order.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<Order.Infrastructure.Repositories.IOrderRepository, Order.Infrastructure.Repositories.InMemoryOrderRepository>();
builder.Services.AddScoped<Order.Application.CommandHandlers.CreateOrderCommandHandler>();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Order.Application.Services.CartService).Assembly));


//pod spodem pozostaoci z shopping cart, ktre nie s potrzebne w tym projekcie CustomerOrder
// Register dependencies (DIP) 
//builder.Services.AddSingleton<ICartRepository, InMemoryCartRepository>();
//builder.Services.AddSingleton<ICartAdder, CartService>();
//builder.Services.AddSingleton<ICartRemover, CartService>();
//builder.Services.AddSingleton<ICartReader, CartService>();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<Order.Infrastructure.Repositories.IOrderRepository, Order.Infrastructure.Repositories.InMemoryOrderRepository>();
builder.Services.AddScoped<Order.Application.CommandHandlers.CreateOrderCommandHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
