namespace VendingMachineTDD;

public class VendingMachine
{
    private List<Product> _products = new()
    {
        new Product { Code = "A01", Name = "Soda", Price = 1.00m, Inventory = 10 },
        new Product { Code = "A02", Name = "Chips", Price = 0.65m, Inventory = 12 },
        new Product { Code = "A03", Name = "Candy", Price = 0.85m, Inventory = 8 },
        new Product { Code = "A04", Name = "Gum", Price = 0.40m, Inventory = 3 }
    };

    public void LoadProducts(Product product) => _products.Add(product);

    public string Vend(string code, decimal funds)
    {
        var product = _products.FirstOrDefault(p => p.Code == code);
        if (product is null)
            return "Invalid Selection: " + code;

        if (code == product.Code && funds == product.Price && product.Inventory > 0)
        {
            product.Inventory--;
            return "Vending " + product.Name;
        }

        if (code == product.Code && funds > product.Price && product.Inventory > 0)
        {
            product.Inventory--;
            return $"Vending {product.Name}: Change ${funds - product.Price}";
        }
        if (code == product.Code && funds < product.Price && product.Inventory > 0)
            return "Feed me $" + (product.Price - funds) + " more";
        if (code == product.Code && product.Inventory == 0)
            return "Sold Out";
        return "Invalid Selection: " + code;
    }
}