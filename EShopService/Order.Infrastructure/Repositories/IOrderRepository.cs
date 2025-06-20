
using Order.Domain.Commands;

namespace Order.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        void Save(CreateOrderCommand order);
    }
}
