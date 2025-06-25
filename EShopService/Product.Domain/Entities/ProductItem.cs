namespace Product.Domain.Entities
{
    public class ProductItem //gdyby klasa nazywa³a siê Product to by by³y konflikty z namespace
    {
        public Guid Id { get; set; } = Guid.NewGuid(); //private set wczesniej w tych properties tylko testy nie dzialaly
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public int Quantity { get;  set; }
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