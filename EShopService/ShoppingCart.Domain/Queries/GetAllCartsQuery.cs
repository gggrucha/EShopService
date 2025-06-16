using MediatR;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Queries
{
    public class GetAllCartsQuery : IRequest<List<Cart>>
    {
    }
}
