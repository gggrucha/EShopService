using System;
using System.Collections.Generic;

namespace Order.Domain.Commands
{
    public class CreateOrderCommand
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }

    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
