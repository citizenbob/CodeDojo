namespace VendingMachineTDD;

public class VendingMachineTests
{
    [Fact]
    public void Vend_InvalidCode_DisplayError()
    {
        var machine = new VendingMachine();

        var response = machine.Vend("A09");
        
        Assert.Equal("Invalid Code: A09", response);
    }
}