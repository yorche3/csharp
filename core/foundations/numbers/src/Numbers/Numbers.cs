namespace Numbers;

public static class NumbersImpl
{
    public static int SumOfFirstNRec(int n)
    {
        if (n <= 0) return 0;
        else return n + SumOfFirstNRec(n - 1);
    }

    public static int FactorialRec(int n)
    {
        if (n <= 1) return 1;
        else return n * FactorialRec(n - 1);
    }

    public static int FibonacciRec(int n)
    {
        if (n <= 1) return n;
        else return FibonacciRec(n - 1) + FibonacciRec(n - 2);
    }

    public static int LargestCommonDivisorRec(int a, int b)
    {
        if (b == 0) return a;
        else return LargestCommonDivisorRec(b, a % b);
    }

    public static int LeastCommonMultipleRec(int a, int b)
    {
        return (a * b) / LargestCommonDivisorRec(a, b);
    }

    public static int SumOfFirstNAcc(int n)
    {
        return SumOfFirstNHelp(n, 0);
    }

    private static int SumOfFirstNHelp(int n, int sum)
    {
        if (n <= 0) return sum;
        else return SumOfFirstNHelp(n - 1, sum + n);
    }

    public static int FactorialAcc(int n)
    {
        return FactorialHelp(n, 1);
    }

    private static int FactorialHelp(int n, int product)
    {
        if (n <= 1) return product;
        else return FactorialHelp(n - 1, product * n);
    }

    public static int FibonacciAcc(int n)
    {
        return FibonacciHelp(n, 0, 1);
    }

    private static int FibonacciHelp(int n, int a, int b)
    {
        if (n <= 0) return a;
        else return FibonacciHelp(n - 1, b, a + b);
    }

    public static int LargestCommonDivisorAcc(int a, int b)
    {
        return LargestCommonDivisorHelp(a, b);
    }

    private static int LargestCommonDivisorHelp(int a, int b)
    {
        if (b == 0) return a;
        else return LargestCommonDivisorHelp(b, a % b);
    }

    public static int LeastCommonMultipleAcc(int a, int b)
    {
        return (a * b) / LargestCommonDivisorAcc(a, b);
    }

    public static int SumOfFirstNIter(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        return sum;
    }

    public static int FactorialIter(int n)
    {
        int product = 1;
        for (int i = 1; i <= n; i++)
        {
            product *= i;
        }
        return product;
    }

    public static int FibonacciIter(int n)
    {
        int acc1 = 0;
        int acc2 = 1;
        for (int i = 0; i < n; i++)
        {
            int temp = acc1;
            acc1 = acc2;
            acc2 = temp + acc2;
        }
        return acc1;
    }

    public static int LargestCommonDivisorIter(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static int LeastCommonMultipleIter(int a, int b)
    {
        return (a * b) / LargestCommonDivisorIter(a, b);
    }
}