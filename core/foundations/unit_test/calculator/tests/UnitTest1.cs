using Xunit;
using Calculator;

namespace Calculator.Tests;

public class UnitTest1
{
    Class1 calculator = new Class1();

    [Fact]
    public void TestAddition()
    {
        Assert.Equal(5, calculator.Addition(2, 3));
    }

    [Fact]
    public void TestSubtraction()
    {
        Assert.Equal(2, calculator.Subtraction(5, 3));
    }

    [Fact]
    public void TestMultiplication()
    {
        Assert.Equal(12, calculator.Multiplication(3, 4));
    }

    [Fact]
    public void TestDivision()
    {
        Assert.Equal(3, calculator.Division(10, 3));
    }

    [Fact]
    public void TestModulus()
    {
        Assert.Equal(1, calculator.Modulus(10, 3));
    }
}
