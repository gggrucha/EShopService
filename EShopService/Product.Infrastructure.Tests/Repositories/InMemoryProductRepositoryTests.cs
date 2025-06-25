using System;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Product.Domain.Entities;
using Product.Infrastructure.Repositories;

namespace Product.Infrastructure.Tests.Repositories
{
    public class InMemoryProductRepositoryTests
    {
        [Fact]
        public async Task Add_ShouldAddProductAndReturnId()
        {
            var repo = new InMemoryProductRepository();
            var product = new ProductItem("Test", "Desc", 10, 5);

            var id = await repo.Add(product);
            var retrieved = await repo.GetByIdAsync(id);

            Assert.NotNull(retrieved);
            Assert.Equal("Test", retrieved.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNullIfNotFound()
        {
            var repo = new InMemoryProductRepository();
            var result = await repo.GetByIdAsync(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task RemoveAsync_ShouldRemoveProduct()
        {
            var repo = new InMemoryProductRepository();
            var product = new ProductItem("Test", "Desc", 10, 5);
            var id = await repo.Add(product);

            var removed = await repo.RemoveAsync(id);
            var check = await repo.GetByIdAsync(id);

            Assert.True(removed);
            Assert.Null(check);
        }

        [Fact]
        //public async Task UpdateAsync_ShouldUpdateProduct()
        //{
        //    var repo = new InMemoryProductRepository();
        //    var product = new ProductItem("Old", "Old", 10, 1);
        //    var id = await repo.Add(product);

        //    var updated = new ProductItem("New", "New", 20, 2);
        //    typeof(ProductItem).GetProperty("Id")?.SetValue(updated, Guid.NewGuid()); // wymuszenie Id tylko w testach
        //    var success = await repo.UpdateAsync(updated);
        //    var retrieved = await repo.GetByIdAsync(id);

        //    Assert.True(success);
        //    Assert.Equal("New", retrieved.Name);
        //    Assert.Equal(20, retrieved.Price);
        //}

        //[Fact]
        public async Task UpdateAsync_ShouldReturnFalseIfNotExists()
        {
            var repo = new InMemoryProductRepository();
            var updated = new ProductItem("New", "New", 20, 2);
            typeof(ProductItem).GetProperty("Id")?.SetValue(updated, Guid.NewGuid()); // wymuszenie Id tylko w testach

            var success = await repo.UpdateAsync(updated);

            Assert.False(success);
        }
    }
}