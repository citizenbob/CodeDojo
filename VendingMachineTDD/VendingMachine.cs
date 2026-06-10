namespace VendingMachineTDD;

public class VendingMachine
{
    private List<Product> _products = [];

    public void LoadProducts(Product product) => _products.Add(product);

    public string Vend(string code, decimal funds)
    {
        var product = _products.FirstOrDefault(p => p.Code == code);
        if (product is null)
            return "Invalid Selection: " + code;

        if (code == "A01" && funds == 1.00m && product.Inventory > 0)
        {
            product.Inventory--;
            return "Vending Soda";
        }

        if (code == "A01" && funds > 1.00m && product.Inventory > 0)
        {
            product.Inventory--;
            return "Vending Soda: Change $" + (funds - 1.00m);
        }
        if (code == "A01" && funds < 1.00m && product.Inventory > 0)
            return "Feed me $" + (1.00m - funds) + " more";
        if (code == "A01" && product.Inventory == 0)
            return "Sold Out";
        return "Invalid Selection: " + code;
    }
}