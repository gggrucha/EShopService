using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ClientData.Domain.Seeders;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using ClientData.Domain.Models; 
using ClientData.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace ClientData.IntegrationTests;

public class ClientDataControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private WebApplicationFactory<Program> _factory;
    public ClientDataControllerIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services
                    .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DbContext>));

                    services.Remove(dbContextOptions);
                    services
                        .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("MyDBForTest"));
                });
            });
        _client = _factory.CreateClient();
    }
    [Fact]
    public async Task Get_ReturnsClientById_ClientExists()
    {
        //Arrange
        using (var scope = _factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Clients.RemoveRange(dbContext.Clients);
            await dbContext.SaveChangesAsync();
            dbContext.Clients.Add(new Client() { Id = 12, Username = "client12", PasswordHash = "2##" });
            await dbContext.SaveChangesAsync();
        }
        //Act
        var response = await _client.GetAsync("api/ClientsData/12");
        //Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task Get_ReturnsAllClients_3ClientsReturned()
    {
        //Arrange
        using (var scope = _factory.Services.CreateScope())
        {
            //pobranie kontekstu bezy danych
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Clients.RemoveRange(dbContext.Clients);

            // stworzenie obiektu
            dbContext.Clients.AddRange(
                new Client() { Id = 12, Username = "client12", PasswordHash = "2##" },
                new Client() { Id = 13, Username = "client13", PasswordHash = "#3#" },
                new Client() { Id = 14, Username = "client14", PasswordHash = "##4" }
            );
            //zapisanie obiektu
            await dbContext.SaveChangesAsync();
        }
        //Act
        var response = await _client.GetAsync("/api/ClientsData");
        //Assert 
        var clients = await response.Content.ReadFromJsonAsync<List<Client>>();
        Assert.Equal(3, clients?.Count);
    }
    [Fact]
    public async Task Get_ReturnNotFound_ClientdoesntExist()
    {
        //Act
        var response = await _client.GetAsync("api/ClientsData/78878");
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

    }

    [Fact]
    public async Task Post_AddThreehundredClients_ReturnedThreehundredCLients()
    {
        //Arrange 
        using (var scope = _factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Clients.RemoveRange(dbContext.Clients);
            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 300; i++)
            {

                dbContext.Clients.Add(new Client()
                {
                    Username = $"client{i}",
                    PasswordHash = $"##{i}"
                });

            }
            await dbContext.SaveChangesAsync(); 
        }      

        //Act
        var response = await _client.GetAsync("/api/ClientsData");
        //Assert
        response.EnsureSuccessStatusCode();
        var postedClients = await response.Content.ReadFromJsonAsync<List<Client>>();
        Assert.Equal(300, postedClients?.Count);
    }
   
    [Fact]
    public async Task Delete_DeleteClient_ReturnsOkResult()
    {
        //Arrange
        using (var scope = _factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Clients.RemoveRange(dbContext.Clients);
            await dbContext.SaveChangesAsync();
            dbContext.Clients.Add(new Client() { Id = 12, Username = "client12", PasswordHash = "2##" });
            await dbContext.SaveChangesAsync();
        }
        //Act
        var response = await _client.DeleteAsync("api/ClientsData/12");
        //Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task Delete_DeleteClient_NotFound()
    {
        //Act
        var response = await _client.DeleteAsync("api/ClientsData/78878");
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    



}
    


