namespace Calculator;

public class Class1
{
    public int Addition(int a, int b) => a + b;
    public int Subtraction(int a, int b) => a - b;
    public int Multiplication(int a, int b)
    {
        int result = 0;
        for (int i = 0; i < b; i++)
        {
            result = Addition(result, a); // Add 'a' to result 'b' times
        }
        return result;
    }

    public int Division(int a, int b)
    {
        int quotient = 0;
        while (a >= b)
        {
            a = Subtraction(a, b); // Subtract divisor from dividend
            quotient = Addition(quotient, 1); // Increment quotient
        }
        return quotient;
    }

    public int Modulus(int a, int b)
    {
        int quotient = Division(a, b);
        return Subtraction(a, Multiplication(quotient, b)); // Subtract (divisor * quotient) from dividend to get remainder
    }
}