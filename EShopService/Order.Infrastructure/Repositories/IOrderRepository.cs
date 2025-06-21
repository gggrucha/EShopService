using System;
using System.Collections.Generic;
using Order.Domain.Commands;
using Order.Domain.Entities;

namespace Order.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        void Save(CustomerOrder order);
        CustomerOrder? GetById(Guid id);
        List<CustomerOrder> GetAll();
        void UpdateStatus(Guid id, string newStatus);
        void Delete(Guid id);
        void Save(CreateOrderCommand command);
    }
}