using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartAdder
    {
        void AddProductToCart(int cartId, Product product);
    }
}
