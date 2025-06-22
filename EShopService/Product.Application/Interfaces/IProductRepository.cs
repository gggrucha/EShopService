using Product.Domain.Entities;

namespace Product.Application.Interfaces
{
    public interface IProductRepository
    {
        void Add(ProductItem product);
        ProductItem? GetById(Guid id);
        IEnumerable<ProductItem> GetAll();
    }
}