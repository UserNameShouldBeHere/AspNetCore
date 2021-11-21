public class Product
{
    public string Type { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(string type, string name, decimal price)
    {
        Type = type;
        Name = name;
        Price = price;
    }
}