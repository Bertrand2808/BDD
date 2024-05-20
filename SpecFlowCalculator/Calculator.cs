using System.Net.Sockets;

namespace SpecFlowCalculator;

public class Calculator
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public int Add()
    {
        return FirstNumber + SecondNumber;
    }
    
    public int Subtract()
    {
        return FirstNumber - SecondNumber;
    }
    
    public int Multiply()
    {
        return FirstNumber * SecondNumber;
    }
    
    public int Divide()
    {
        if (SecondNumber == 0)
        {
            throw new DivideByZeroException();
        }
        return FirstNumber / SecondNumber;
    }
    
    public int Add(IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }
    
    public int Subtract(IEnumerable<int> numbers)
    {
        return numbers.Aggregate((a, b) => a - b);
    }
    
    public int Multiply(IEnumerable<int> numbers)
    {
        return numbers.Aggregate((a, b) => a * b);
    }
    
    public int Divide(IEnumerable<int> numbers)
    {
        return numbers.Aggregate((a, b) =>
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        });
    }
}