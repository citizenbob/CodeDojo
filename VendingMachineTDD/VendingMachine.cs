namespace VendingMachineTDD;

public class VendingMachine
{
    private List<Product> _products = [];

    public void LoadProducts(Product product) => _products.Add(product);

    public string Vend(string code)
    {
        if (code == "A01")
            return "Vending Soda";
        
        return "Invalid Selection: " + code;
    }
}
public class Product
{
    public string Code { get; init; }
    public string Name { get; init; }
}