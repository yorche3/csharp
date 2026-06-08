using Numbers;

namespace Numbers.Test;

public class NumbersRecursiveTests
{
    [Fact]
    public void TestSumOfFirstNRec()
    {
        Assert.Equal(0, NumbersImpl.SumOfFirstNRec(0));
        Assert.Equal(6, NumbersImpl.SumOfFirstNRec(3));
    }

    [Fact]
    public void TestFactorialRec()
    {
        Assert.Equal(1, NumbersImpl.FactorialRec(0));
        Assert.Equal(24, NumbersImpl.FactorialRec(4));
    }

    [Fact]
    public void TestFibonacciRec()
    {
        Assert.Equal(0, NumbersImpl.FibonacciRec(0));
        Assert.Equal(1, NumbersImpl.FibonacciRec(1));
        Assert.Equal(8, NumbersImpl.FibonacciRec(6));
    }

    [Fact]
    public void TestGreatestCommonDivisorRec()
    {
        Assert.Equal(4, NumbersImpl.LargestCommonDivisorRec(12, 8));
        Assert.Equal(1, NumbersImpl.LargestCommonDivisorRec(7, 5));
    }

    [Fact]
    public void TestLeastCommonMultipleRec()
    {
        Assert.Equal(12, NumbersImpl.LeastCommonMultipleRec(4, 6));
        Assert.Equal(24, NumbersImpl.LeastCommonMultipleRec(6, 8));
    }
}
