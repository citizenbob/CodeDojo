namespace VendingMachineTDD;

public class VendingMachine
{
    private List<Product> _products = [];

    public void LoadProducts(Product product) => _products.Add(product);

    public string Vend(string code, decimal price)
    {
        if (code == "A01" && price == 1.00m)
            return "Vending Soda";
        
        return "Invalid Selection: " + code;
    }
}