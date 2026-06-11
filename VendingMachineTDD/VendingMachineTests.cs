namespace VendingMachineTDD;

public class VendingMachineTests
{
    [Fact]
    public void InvalidCode_DisplayError()
    {
        var machine = new VendingMachine();

        var response = machine.Vend("A09", 0);
        
        Assert.Equal("Invalid Selection: A09", response);
    }
    
    [Fact]
    public void A01_WithExactChange_VendSoda()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m, Inventory = 1} );
        
        var response = machine.Vend("A01", 1.00m);
        
        Assert.Equal("Vending Soda", response);
    }
    
    [Fact]
    public void A01_ExceedsPrice_VendSoda_ReturnChange()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m, Inventory = 1} );
        
        var response = machine.Vend("A01", 5.00m);
        
        Assert.Equal("Vending Soda: Change $4.00", response);
    }
    
    [Fact]
    public void A01_InsufficientFunds_VendSoda_RequestFunds()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m, Inventory = 1} );
        
        var response = machine.Vend("A01", 0.50m);
        
        Assert.Equal("Feed me $0.50 more", response);
    }
    
    [Fact]
    public void A01_VendLastSoda_DisplaySoldOut()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m, Inventory = 10} );

        for (int i = 0; i < 10; i++)
        {
            machine.Vend("A01", 1.00m);
        }
        var response = machine.Vend("A01", 1.00m);
        
        Assert.Equal("Sold Out", response);
    }
    
    [Fact]
    public void A02_VendLastChips_DisplaySoldOut()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A02", Name = "Chips", Price = 0.65m, Inventory = 12} );
        
        for (int i = 0; i < 12; i++)
        {
            machine.Vend("A02", 0.65m);
        }
        var response = machine.Vend("A02", 0.65m);

        Assert.Equal("Sold Out", response);
    }
    
    [Fact]
    public void A03_VendLastCandy_DisplaySoldOut()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A03", Name = "Candy", Price = 0.85m, Inventory = 8} );
        
        for (int i = 0; i < 8; i++)
        {
            machine.Vend("A03", 0.85m);
        }
        var response = machine.Vend("A03", 0.85m);

        Assert.Equal("Sold Out", response);
    }
    
    [Fact]
    public void A04_VendLastGum_DisplaySoldOut()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A04", Name = "Gum", Price = 0.40m, Inventory = 3} );
        
        for (int i = 0; i < 3; i++)
        {
            machine.Vend("A04", 0.40m);
        }
        var response = machine.Vend("A04", 0.40m);

        Assert.Equal("Sold Out", response);
    }
}