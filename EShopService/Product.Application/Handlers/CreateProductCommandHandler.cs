using Product.Application.Commands;
using Product.Application.Interfaces;
using Product.Domain.Entities;

namespace Product.Application.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateProductCommand command)
        {
            var product = new ProductItem(command.Name, command.Description, command.Price, command.Quantity);
            _repository.Add(product);
        }
    }
}