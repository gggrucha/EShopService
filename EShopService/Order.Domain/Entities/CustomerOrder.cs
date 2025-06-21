using System;
using System.Collections.Generic;

namespace Order.Domain.Entities
{
    public class CustomerOrder //nazwa klasy Order powodowa³a konflikty dlatego jest CustomerOrder ¿eby siê nie myli³o z namespace
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; private set; }
        public List<OrderItem> Items { get; private set; } = new();
        public string Status { get; private set; } = "Pending";
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public CustomerOrder(Guid customerId, List<OrderItem> items)
        {
            CustomerId = customerId;
            Items = items ?? new List<OrderItem>();
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
    }

    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}