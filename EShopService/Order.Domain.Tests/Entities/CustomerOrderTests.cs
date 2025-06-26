using System;
using System.Collections.Generic;
using Order.Domain.Entities;
using Xunit;

namespace Order.Domain.Tests.Entities
{
    public class CustomerOrderTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var items = new List<OrderItem>
            {
                new OrderItem { ProductId = Guid.NewGuid(), Quantity = 2 }
            };

            // Act
            var order = new CustomerOrder(customerId, items);

            // Assert
            Assert.Equal(customerId, order.CustomerId);
            Assert.Single(order.Items);
            Assert.Equal("Pending", order.Status);
            Assert.True((DateTime.UtcNow - order.CreatedAt).TotalSeconds < 5);
            Assert.NotEqual(Guid.Empty, order.Id);
        }

        [Fact]
        public void Constructor_ShouldHandleNullItems()
        {
            // Arrange
            var customerId = Guid.NewGuid();

            // Act
            var order = new CustomerOrder(customerId, null);

            // Assert
            Assert.Empty(order.Items);
        }

        [Fact]
        public void UpdateStatus_ShouldChangeOrderStatus()
        {
            // Arrange
            var order = new CustomerOrder(Guid.NewGuid(), new List<OrderItem>());
            var newStatus = "Shipped";

            // Act
            order.UpdateStatus(newStatus);

            // Assert
            Assert.Equal("Shipped", order.Status);
        }
    }
}