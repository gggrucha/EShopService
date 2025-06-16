using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.Application.Services
{
    public class CartService : ICartAdder, ICartRemover, ICartReader
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public void AddProductToCart(int cartId, Product product)
        {
            var cart = _repository.FindById(cartId) ?? new Cart { Id = cartId };
            cart.Products.Add(product);
            _repository.Add(cart);
        }

        public void RemoveProductFromCart(int cartId, int productId)
        {
            var cart = _repository.FindById(cartId);
            if (cart != null)
            {
                var product = cart.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    cart.Products.Remove(product);
                    _repository.Update(cart);
                }
            }
        }

        public Cart GetCart(int cartId)
        {
            var cart = _repository.FindById(cartId);
            if (cart == null) return null;

            return new Cart
            {
                Id = cart.Id,
                Products = cart.Products.Select(p => new Product
                {
                    Id = p.Id
                }).ToList()
            };
        }

        public List<Cart> GetAllCarts()
        {
            return _repository.GetAll().Select(c => new Cart
            {
                Id = c.Id,
                Products = c.Products.Select(p => new Product
                {
                    Id = p.Id
                }).ToList()
            }).ToList();
        }
    }

}
