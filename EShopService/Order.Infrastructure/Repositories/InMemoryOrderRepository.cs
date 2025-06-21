using System;
using System.Collections.Generic;
using System.Linq;
using Order.Domain.Commands;
using Order.Domain.Entities;

namespace Order.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly List<CustomerOrder> _orders = new();

        public void Save(CustomerOrder order)
        {
            _orders.Add(order);
        }

        public CustomerOrder? GetById(Guid id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public List<CustomerOrder> GetAll()
        {
            return _orders;
        }

        public void UpdateStatus(Guid id, string newStatus)
        {
            var order = GetById(id);
            order?.UpdateStatus(newStatus);
        }

        public void Delete(Guid id)
        {
            var order = GetById(id);
            if (order != null)
                _orders.Remove(order);
        }

        public void Save(CreateOrderCommand command)
        {
            throw new NotImplementedException();
        }
    }
}