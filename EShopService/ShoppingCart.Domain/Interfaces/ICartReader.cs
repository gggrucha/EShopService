using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartReader
    {
        Cart GetCart(int cartId);
        List<Cart> GetAllCarts();
    }
}
