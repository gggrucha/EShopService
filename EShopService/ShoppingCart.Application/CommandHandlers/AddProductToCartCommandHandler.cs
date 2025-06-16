using MediatR;
using ShoppingCart.Domain.Commands;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Application.CommandHandlers
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand>
    {
        private readonly ICartAdder _cartAdder;

        public AddProductToCartCommandHandler(ICartAdder cartAdder)
        {
            _cartAdder = cartAdder;
        }

        public Task Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = command.ProductId
            };
            _cartAdder.AddProductToCart(command.CartId, product);
            return Task.CompletedTask;
        }
    }
}
