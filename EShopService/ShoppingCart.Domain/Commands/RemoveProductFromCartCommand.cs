using MediatR;

namespace ShoppingCart.Domain.Commands
{
    public class RemoveProductFromCartCommand : IRequest
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
