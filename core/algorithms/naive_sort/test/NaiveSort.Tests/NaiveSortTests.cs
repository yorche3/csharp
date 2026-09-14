namespace NaiveSort.Tests;

public class NaiveSortTests
{
    private static readonly int[] StandardInput = new int[] { 5, 2, 9, 1, 5, 6 };
    private static readonly int[] StandardOutput = new int[] { 1, 2, 5, 5, 6, 9 };

    private static readonly int[] SortedInput = new int[] { 1, 2, 3, 4, 5 };
    private static readonly int[] SortedOutput = new int[] { 1, 2, 3, 4, 5 };

    private static readonly int[] ReverseInput = new int[] { 5, 4, 3, 2, 1 };
    private static readonly int[] ReverseOutput = new int[] { 1, 2, 3, 4, 5 };

    private static readonly int[] IdenticalInput = new int[] { 7, 7, 7, 7 };
    private static readonly int[] IdenticalOutput = new int[] { 7, 7, 7, 7 };

    private static readonly int[] NegativeInput = new int[] { 3, -1, 4, -5, 0 };
    private static readonly int[] NegativeOutput = new int[] { -5, -1, 0, 3, 4 };

    private static readonly int[] SingleInput = new int[] { 42 };
    private static readonly int[] SingleOutput = new int[] { 42 };

    private static readonly int[] EmptyInput = new int[] { };
    private static readonly int[] EmptyOutput = new int[] { };

    private static readonly int[]? NullInput = null;
    private static readonly int[]? NullOutput = null;

    private static bool ArraysMatch(int[]? expected, int[]? actual) => (expected, actual) switch
    {
        (null, null) => true,
        (null, not null) or (not null, null) => false,
        _ => expected.SequenceEqual(actual),
    };

    private static void AssertSortsAllCases(Func<int[]?, int[]?> sort, string algorithmName)
    {
        Assert.True(ArraysMatch(StandardOutput, sort(StandardInput)), $"{algorithmName} should sort an unsorted array");
        Assert.True(ArraysMatch(SortedOutput, sort(SortedInput)), $"{algorithmName} should keep an already sorted array sorted");
        Assert.True(ArraysMatch(ReverseOutput, sort(ReverseInput)), $"{algorithmName} should sort a reverse ordered array");
        Assert.True(ArraysMatch(IdenticalOutput, sort(IdenticalInput)), $"{algorithmName} should sort identical elements");
        Assert.True(ArraysMatch(NegativeOutput, sort(NegativeInput)), $"{algorithmName} should sort an array with negative numbers");
        Assert.True(ArraysMatch(SingleOutput, sort(SingleInput)), $"{algorithmName} should sort a single element array");
        Assert.True(ArraysMatch(EmptyOutput, sort(EmptyInput)), $"{algorithmName} should sort an empty array");
        Assert.True(ArraysMatch(NullOutput, sort(NullInput)), $"{algorithmName} should return the failure indicator for a null array");
    }

    [Fact]
    public void TestSelectionSort()
    {
        AssertSortsAllCases(NaiveSortImpl.SelectionSort, nameof(NaiveSortImpl.SelectionSort));
    }

    [Fact]
    public void TestBubbleSort()
    {
        AssertSortsAllCases(NaiveSortImpl.BubbleSort, nameof(NaiveSortImpl.BubbleSort));
    }

    [Fact]
    public void TestInsertionSort()
    {
        AssertSortsAllCases(NaiveSortImpl.InsertionSort, nameof(NaiveSortImpl.InsertionSort));
    }
}
