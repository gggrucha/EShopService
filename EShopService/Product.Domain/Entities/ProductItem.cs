namespace Product.Domain.Entities
{
    public class ProductItem //gdyby klasa nazywa�a si� Product to by by�y konflikty z namespace
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public bool IsAvailable => Quantity > 0;

        public ProductItem(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public void UpdatePrice(decimal newPrice) => Price = newPrice;
        public void AdjustStock(int change) => Quantity += change;
    }
}