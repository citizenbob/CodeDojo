namespace VendingMachineKata;

public class VendingMachineTests
{
   
    [Fact]
    public void InvalidCode_DisplayError()
    {
        var machine = new VendingMachine();

        var result = machine.EnterCode("A09");

        Assert.Equal("Invalid Selection: A09", result);
    }
    
    [Fact]
    public void NoInsert_EnterCode_AskForFunds()
    {
        var machine = new VendingMachine();
        
        var result = machine.EnterCode("A01");
        
        Assert.Equal("Feed me $1.00 more", result);
    }
    
    [Fact]
    public void InsertPenny_EnterCode_AskForFunds()
    {
        var machine = new VendingMachine();

        machine.Insert(0.01m);
        var result = machine.EnterCode("A01");
        
        Assert.Equal("Feed me $0.99 more", result);
    }
    
    [Fact]
    public void InsertDollar_EnterCode_VendSoda()
    {
        var machine = new VendingMachine();

        machine.Insert(1.00m);
        var result = machine.EnterCode("A01");
        
        Assert.Equal("Vending Soda", result);
    }
    
    [Fact]
    public void InsertDollar_EnterCode_VendChips_ReturnChange()
    {
        var machine = new VendingMachine();

        machine.Insert(1.00m);
        var result = machine.EnterCode("A02");
        
        Assert.Equal("Vending Chips: Change $0.35", result);
    }
    
    [Fact]
    public void ZeroInventory_DisplaySoldOut()
    {
        var machine = new VendingMachine();

        for (int inventory = 0; inventory < 3; inventory++)
        {
            machine.Insert(0.40m);
            var result = machine.EnterCode("A04");
            
            Assert.Equal("Vending Gum", result);
        }
        
        machine.Insert(0.40m);
        var depletedResult =  machine.EnterCode("A04");
        Assert.Equal("Sold Out: Gum", depletedResult);
    }
}

