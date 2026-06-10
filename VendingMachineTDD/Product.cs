namespace VendingMachineTDD;

public class Product
{
    public string Code { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Inventory { get; set; }
}