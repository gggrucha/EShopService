using Microsoft.EntityFrameworkCore;
using ClientData.Domain;
using ClientData.Application.Services;
using ClientData.Domain.Repositories;
using ClientData.Domain.Seeders;
namespace ClientData
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ClientData.Domain.Repositories.DataContext>(x => x.UseInMemoryDatabase("TestDb"), ServiceLifetime.Transient);

            // Add services to the container.
            builder.Services.AddScoped<IClientDataService, ClientDataService>();
            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IClientSeeder, ClientSeeder>();

            builder.Services.AddControllers();
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

            // Seed the database
            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IClientSeeder>();
            await seeder.Seed();
            app.Run();
        }
    }
}

