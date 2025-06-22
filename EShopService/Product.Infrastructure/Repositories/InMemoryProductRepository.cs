using Product.Application.Interfaces;
using Product.Domain.Entities;

namespace Product.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static readonly List<ProductItem> _products = new();

        public void Add(ProductItem product) => _products.Add(product);
        public ProductItem? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);
        public IEnumerable<ProductItem> GetAll() => _products;
    }
}