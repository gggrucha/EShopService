using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Product.Application.Interfaces;
using Product.Domain.Entities;

namespace Product.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, ProductItem> _products = new();
        //private static readonly List<ProductItem> _products = new(); //wczesniej jako lista teraz jako dictionary

        public Task<Guid> Add(ProductItem product) //=> _products.Add(product);
        {
            var id = Guid.NewGuid();
            product.Id = id;
            _products[id] = product;
            return Task.FromResult(id);
        }
        public Task<ProductItem?> GetByIdAsync(Guid id)
        {
            _products.TryGetValue(id, out var product);
            return Task.FromResult(product);
        }

        public Task<List<ProductItem>> GetAllAsync()
        {
            return Task.FromResult(_products.Values.ToList());
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            return Task.FromResult(_products.Remove(id));
        }

        public Task<bool> UpdateAsync(ProductItem updated)
        {
            if (!_products.ContainsKey(updated.Id))
                return Task.FromResult(false);

            _products[updated.Id] = updated;
            return Task.FromResult(true);
        }
        //public ProductItem? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);
        //public IEnumerable<ProductItem> GetAll() => _products;

        //Task<Guid> IProductRepository.Add(ProductItem product)
        //{
        //    throw new NotImplementedException();
        //}
    }
}