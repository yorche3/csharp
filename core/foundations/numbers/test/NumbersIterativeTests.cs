using Numbers;

namespace Numbers.Test;

public class NumbersIterativeTests
{
    [Fact]
    public void TestSumOfFirstNIter()
    {
        Assert.Equal(0, NumbersImpl.SumOfFirstNIter(0));
        Assert.Equal(6, NumbersImpl.SumOfFirstNIter(3));
    }

    [Fact]
    public void TestFactorialIter()
    {
        Assert.Equal(1, NumbersImpl.FactorialIter(0));
        Assert.Equal(24, NumbersImpl.FactorialIter(4));
    }

    [Fact]
    public void TestFibonacciIter()
    {
        Assert.Equal(0, NumbersImpl.FibonacciIter(0));
        Assert.Equal(1, NumbersImpl.FibonacciIter(1));
        Assert.Equal(8, NumbersImpl.FibonacciIter(6));
    }

    [Fact]
    public void TestGreatestCommonDivisorIter()
    {
        Assert.Equal(4, NumbersImpl.LargestCommonDivisorIter(12, 8));
        Assert.Equal(1, NumbersImpl.LargestCommonDivisorIter(7, 5));
    }

    [Fact]
    public void TestLeastCommonMultipleIter()
    {
        Assert.Equal(12, NumbersImpl.LeastCommonMultipleIter(4, 6));
        Assert.Equal(24, NumbersImpl.LeastCommonMultipleIter(6, 8));
    }
}