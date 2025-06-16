using MediatR;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Queries
{
    public class GetCartQuery : IRequest<Cart>
    {
        public int CartId { get; set; }
    }
}
