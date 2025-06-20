
using Order.Domain.Commands;
using Order.Infrastructure.Repositories;

namespace Order.Application.CommandHandlers
{
    public class CreateOrderCommandHandler
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateOrderCommand command)
        {
            // Walidacja, logika biznesowa itp. tutaj
            _repository.Save(command);
        }
    }
}
