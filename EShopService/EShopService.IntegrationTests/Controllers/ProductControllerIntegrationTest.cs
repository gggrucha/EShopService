using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using EShopDomain.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Threading.Tasks;

namespace EShopService.IntegrationTests.Controllers
{
    public class ProductControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        public ProductControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // pobranie dotychczasowej konfiguracji bazy danych
                        var dbContextOptions = services
                            .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DataContext>));

                        //// usunięcie dotychczasowej konfiguracji bazy danych
                        services.Remove(dbContextOptions);

                        // Stworzenie nowej bazy danych
                        services
                            .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("MyDBForTest"));

                    });
                });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsAllProducts_ExceptedTwoProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                // Pobranie kontekstu bazy danych
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);

                // Stworzenie obiektu
                dbContext.Products.AddRange(
                    new Product { Name = "Product1" },
                    new Product { Name = "Product2" }
                );
                // Zapisanie obiektu
                await dbContext.SaveChangesAsync();
            }

            // Act
            var response = await _client.GetAsync("/api/product");

            // Assert
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(2, products?.Count);
        }


        [Fact]
        public async Task Post_AddThousandsProducts_ExceptedThousandsProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                // Pobranie kontekstu bazy danych
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.SaveChanges();

                var tasks = new List<Task>();

                for (int i = 0; i < 10000; i++)
                {
                    int index = i;
                    tasks.Add(Task.Run(async () =>
                    {
                        using (var scope = _factory.Services.CreateScope())
                        {
                            // Pobranie kontekstu bazy danych
                            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                            {
                                dbContext.Products.Add(new Product { Name = "Product" + index });
                                dbContext.SaveChanges();
                            }
                        }
                    }));
                }
                await Task.WhenAll(tasks);
            }

            // Act
            var response = await _client.GetAsync("/api/product");

            // Assert
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(10000, products?.Count);
        }

        [Fact]
        public async Task Post_AddThousandsProductsAsync_ExceptedThousandsProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                // Pobranie kontekstu bazy danych
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);
                await dbContext.SaveChangesAsync();

            }

            var tasks = new List<Task>();

            for (int i = 0; i < 10000; i++)
            {
                int index = i;
                tasks.Add(Task.Run(async () =>
                {
                    using (var scope = _factory.Services.CreateScope())
                    {
                        // Pobranie kontekstu bazy danych
                        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                        {
                            dbContext.Products.Add(new Product { Name = "Product" + index });
                            await dbContext.SaveChangesAsync();
                        }
                    }
                }));
            }
            await Task.WhenAll(tasks);


            // Act
            var response = await _client.GetAsync("/api/product");

            // Assert
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(10000, products?.Count);
        }



        [Fact]
        public async Task Add_AddProduct_ExceptedOneProduct()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                // Pobranie kontekstu bazy danych
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.SaveChanges();

                // Act
                var category = new Category
                {
                    Name = "test"
                };

                var product = new Product
                {
                    Name = "Product",
                    Category = category
                };

                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PatchAsync("/api/Product", content);

                var result = await dbContext.Products.ToListAsync();

                // Assert
                Assert.Equal(1, result?.Count);
            }
        }
    }
}
