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
        var selectedProduct = _products.FirstOrDefault(p => p.Code == code);
        if (selectedProduct is null)
            return "Invalid Selection: " + code;

        bool exactChange = funds == selectedProduct.Price;
        bool hasExcessFunds = funds > selectedProduct.Price;
        bool balanceDue = funds < selectedProduct.Price;
        bool validCode = code == selectedProduct.Code;
        bool inStock = selectedProduct.Inventory > 0;

        if (validCode && inStock)
        {
            if (exactChange || hasExcessFunds) return DispenseProduct(selectedProduct, funds, hasExcessFunds);
            if (balanceDue) return RequestFunds(selectedProduct, funds);
        }

        if (validCode && !inStock)
            return "Sold Out";

        return "Invalid Selection: " + code;

        static string DispenseProduct(Product selectedProduct, decimal funds, bool hasExcessFunds)
        {
            selectedProduct.Inventory--;
            
            if (hasExcessFunds)
                return $"Vending {selectedProduct.Name}: Change ${funds - selectedProduct.Price}";
            
            return "Vending " + selectedProduct.Name;
        }
        
        static string RequestFunds(Product selectedProduct, decimal funds) => "Feed me $" + (selectedProduct.Price - funds) + " more";
    }
}
