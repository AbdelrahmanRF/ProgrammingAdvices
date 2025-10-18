using System;

class clsCalculator
{
    private enum enOperations
    {
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4,
        Clear = 5,
    }

    private double _Result = 0;
    private double _UserValue = 0;
    private enOperations _LastOperation;

    private string _GetLastOperation()
    {
        switch (_LastOperation)
        {
            case enOperations.Add:
                return "Adding";
            case enOperations.Subtract:
                return "Subtracting";
            case enOperations.Multiply:
                return "Multiplying";
            case enOperations.Divide:
                return "Dividing";
            case enOperations.Clear:
                return "Clear";
            default:
                return "Null";
        }
    }

    public void Clear()
    {
        _LastOperation = enOperations.Clear;
        _Result = 0;
        _UserValue = 0;
    }

    public void Add(double Value)
    {
        _LastOperation = enOperations.Add;
        _UserValue = Value;
        _Result += Value;
    }

    public void Subtract(double Value)
    {
        _LastOperation = enOperations.Subtract;
        _UserValue = Value;
        _Result -= Value;
    }

    public void Multiply(double Value)
    {
        _LastOperation = enOperations.Multiply;
        _UserValue = Value;
        _Result *= Value;
    }

    public bool Divide(double Value)
    {
        bool Succeeded = true;

        _LastOperation = enOperations.Divide;
        _UserValue = Value;

        if (Value == 0)
        {
            _Result /= 1;
            Succeeded = false;
        }
        else
        {
            _Result /= Value;
        }

        return Succeeded;
    }

    public double GetFinalResult()
    {
        return _Result;
    }

    public void PrintResult()
    {
        Console.WriteLine($"Result after {_GetLastOperation()} {_UserValue} is : {_Result}");
    }
}

namespace Calculator_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsCalculator Calculator = new clsCalculator();

            Calculator.Clear();

            Calculator.Add(110);
            Calculator.PrintResult();

            Calculator.Subtract(5);
            Calculator.PrintResult();

            Calculator.Multiply(2);
            Calculator.PrintResult();

            Calculator.Divide(4);
            Calculator.PrintResult();

            Calculator.Divide(0);
            Calculator.PrintResult();

            Calculator.Clear();
            Calculator.PrintResult();

            Console.WriteLine(Calculator.GetFinalResult());
        }
    }
}
