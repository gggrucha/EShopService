using MediatR;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using ShoppingCart.Domain.Queries;

namespace ShoppingCart.Application.QueryHandlers
{
    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, List<Cart>>
    {
        private readonly ICartReader _cartReader;

        public GetAllCartsQueryHandler(ICartReader cartReader)
        {
            _cartReader = cartReader;
        }

        public Task<List<Cart>> Handle(GetAllCartsQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_cartReader.GetAllCarts());
        }
    }
}
