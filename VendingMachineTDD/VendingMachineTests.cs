namespace VendingMachineTDD;

public class VendingMachineTests
{
    [Fact]
    public void InvalidCode_DisplayError()
    {
        var machine = new VendingMachine();

        var response = machine.Vend("A09");
        
        Assert.Equal("Invalid Selection: A09", response);
    }
    
    [Fact]
    public void A01_VendSoda()
    {
        var machine = new VendingMachine();
        machine.LoadProducts(new Product { Code = "A01", Name = "Soda"} );
        
        var response = machine.Vend("A01");
        
        Assert.Equal("Vending Soda", response);
    }
}