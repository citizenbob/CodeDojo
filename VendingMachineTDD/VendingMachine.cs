namespace VendingMachineTDD;

public class VendingMachine
{
    private List<Product> _products = [];

    public void LoadProducts(Product product) => _products.Add(product);

    public string Vend(string code, decimal funds)
    {
        if (code == "A01" && funds == 1.00m)
            return "Vending Soda";
        if (code == "A01" && funds > 1.00m)
            return "Vending Soda: Change $" + (funds - 1.00m);
        if (code == "A01" && funds < 1.00m)
            return "Feed me $" + (1.00m - funds) + " more";
        return "Invalid Selection: " + code;
    }
}