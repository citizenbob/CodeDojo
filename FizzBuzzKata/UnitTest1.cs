namespace FizzBuzzTDD;

public class FizzBuzzTests
{
    [Fact]
    public void Given1_ReturnsOne()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(1);
        Assert.Equal("1", result);
    }
    
    [Fact]
    public void Given2_ReturnsTwo()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(2);
        Assert.Equal("2", result);
    }
    
    [Fact]
    public void Given3_ReturnsFizz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(3);
        Assert.Equal("Fizz", result);
    }
    
    [Fact]
    public void Given5_ReturnsBuzz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(5);
        Assert.Equal("Buzz", result);
    }
    
    [Fact]
    public void Given6_ReturnsFizz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(6);
        Assert.Equal("Fizz", result);
    }
    
    [Fact]
    public void Given9_ReturnsFizz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(9);
        Assert.Equal("Fizz", result);
    }
    [Fact]
    public void Given10_ReturnsBuzz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(10);
        Assert.Equal("Buzz", result);
    }
    [Fact]
    public void Given15_ReturnsFizzBuzz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(15);
        Assert.Equal("FizzBuzz", result);
    }
    [Fact]
    public void Given20_ReturnsBuzz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = fizzBuzz.Print(20);
        Assert.Equal("Buzz", result);
    }
}