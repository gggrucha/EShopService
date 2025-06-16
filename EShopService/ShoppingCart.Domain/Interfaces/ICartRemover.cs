namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartRemover
    {
        void RemoveProductFromCart(int cartId, int productId);
    }
}
