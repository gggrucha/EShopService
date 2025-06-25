using Product.Domain.Entities;

namespace Product.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Guid> Add(ProductItem product);
        Task<ProductItem?> GetByIdAsync(Guid id);
        //ProductItem? GetByIdAsync(Guid id); //jeszcze nie asynchroniczne
        //IEnumerable<ProductItem> GetAll();
        Task<List<ProductItem>> GetAllAsync();
    }
}