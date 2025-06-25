using System;
using System.Threading.Tasks;
using Product.Application.Commands;
using Product.Application.Handlers;
using Product.Infrastructure.Repositories;
using Xunit;

namespace Product.Application.Tests.Handlers
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateProductAndReturnId()
        {
            // Arrange
            var repo = new InMemoryProductRepository();
            var handler = new CreateProductCommandHandler(repo);
            var command = new CreateProductCommand
            {
                Name = "Test",
                Description = "Opis",
                Price = 100.0m,
                Quantity = 3
            };


            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            var created = await repo.GetByIdAsync(result); //GetByIdAsync
            Assert.NotNull(created);
            Assert.Equal("Test", created.Name);
        }
    }
}