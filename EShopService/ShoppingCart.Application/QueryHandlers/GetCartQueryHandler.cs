using MediatR;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using ShoppingCart.Domain.Queries;

namespace ShoppingCart.Application.QueryHandlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Cart>
    {
        private readonly ICartReader _cartReader;

        public GetCartQueryHandler(ICartReader cartReader)
        {
            _cartReader = cartReader;
        }

        public Task<Cart> Handle(GetCartQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_cartReader.GetCart(query.CartId));
        }
    }
}