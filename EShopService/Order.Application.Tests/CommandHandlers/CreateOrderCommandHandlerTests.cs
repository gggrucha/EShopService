using System;
using Moq;
using Order.Application.CommandHandlers;
using Order.Domain.Commands;
using Order.Infrastructure.Repositories;
using Xunit;

namespace Order.Application.Tests.CommandHandlers
{
    public class CreateOrderCommandHandlerTests
    {
        [Fact]
        public void Handle_ShouldCallRepositorySave_WithValidCommand()
        {
            // Arrange
            var mockRepo = new Mock<IOrderRepository>();
            var handler = new CreateOrderCommandHandler(mockRepo.Object);
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                Items = new System.Collections.Generic.List<OrderItem>
                {
                    new OrderItem { ProductId = Guid.NewGuid(), Quantity = 1 }
                }
            };

            // Act
            handler.Handle(command);

            // Assert
            mockRepo.Verify(r => r.Save(command), Times.Once);
        }

        [Fact]
        public void Handle_WithNullCommand_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockRepo = new Mock<IOrderRepository>();
            var handler = new CreateOrderCommandHandler(mockRepo.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handler.Handle(null));
        }
    }
}