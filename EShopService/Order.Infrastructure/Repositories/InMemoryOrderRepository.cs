
//using Order.Domain.Commands;

using Order.Domain.Commands;

namespace Order.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly List<CreateOrderCommand> _orders = new();

        public void Save(CreateOrderCommand order)
        {
            _orders.Add(order);
        }

        public List<CreateOrderCommand> GetAll()
        {
            return _orders;
        }

        
    }
}
