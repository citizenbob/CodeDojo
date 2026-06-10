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
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m} );
        
        var response = machine.Vend("A01", 1.00m);
        
        Assert.Equal("Vending Soda", response);
    }
    
    [Fact]
    public void A01_ExceedsPrice_VendSoda_ReturnChange()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m} );
        
        var response = machine.Vend("A01", 5.00m);
        
        Assert.Equal("Vending Soda: Change $4.00", response);
    }
    
    [Fact]
    public void A01_InsufficientFunds_VendSoda_RequestFunds()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda", Price = 1.00m} );
        
        var response = machine.Vend("A01", 0.50m);
        
        Assert.Equal("Feed me $0.50 more", response);
    }
}