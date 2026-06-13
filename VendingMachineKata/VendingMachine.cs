namespace VendingMachineKata;

public class VendingMachine
{
    private readonly Dictionary<string, (string Name, int Inventory, decimal Price)> _remap = new()
    {
        ["A01"] = ("Soda", 10, 1.00m),
        ["A02"] = ("Chips", 12, 0.65m),
        ["A03"] = ("Candy", 8, 0.85m),
        ["A04"] = ("Gum", 3, 0.40m),
    };
    
    private decimal _balance = 0;
    public void Insert(decimal funds) => _balance += funds;

    public string EnterCode(string code)
    {
        if (!_remap.TryGetValue(code, out var product))
            return "Invalid Selection: " + code;
        
        if (product.Inventory == 0)
            return "Sold Out: " + product.Name;
        
        if (_balance < product.Price)
            return $"Feed me ${product.Price - _balance:F2} more";

        if (_balance > product.Price)
            return $"Vending {product.Name}: Change ${_balance - product.Price:F2}";
        
        _remap[code] = product with { Inventory = product.Inventory - 1 };
        _balance -= product.Price;
        return "Vending " + product.Name;
        
    }
    
}
