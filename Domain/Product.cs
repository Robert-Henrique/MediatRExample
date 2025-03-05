namespace MediatRExample.Domain;

public class Product(string name, decimal price)
{
    public string Id { get; protected set; }
    public string Name { get; protected set; } = name;
    public decimal Price { get; protected set; } = price;
}