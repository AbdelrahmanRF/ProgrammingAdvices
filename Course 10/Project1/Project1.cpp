#include <iostream>
using namespace std;

class clsCalculator 
{
    float _Result = 0;
    float _PreviousResult = 0;
    float _LastNumber = 0;
    string _LastOperation = "";

    bool _IsZero(float Num) {
        return Num == 0;
    }

public:

    void Clear() {
        _LastNumber = 0;
        _PreviousResult = _Result;
        _LastOperation = "Clear";
        _Result = 0;
    }

    void Add(float Num) {
        _LastNumber = Num;
        _PreviousResult = _Result;
        _LastOperation = "Adding";
        _Result += Num;
    }

    void Subtract(float Num) {
        _LastNumber = Num;
        _PreviousResult = _Result;
        _LastOperation = "Subtracting";
        _Result -= Num;
    }

    void Multiply(float Num) {
        _LastNumber = Num;
        _PreviousResult = _Result;
        _LastOperation = "Multiplying";
        _Result *= Num;
    }

    void Divide(float Num) {
        if (_IsZero(Num)) Num = 1;

        _LastNumber = Num;
        _PreviousResult = _Result;
        _LastOperation = "Dividing";
        _Result /= Num;
    }

    void CancelLastOperation() {
       /* _LastNumber = 0;*/
        _LastOperation = "Cancelling Last Operation (" + _LastOperation + ")";
        _Result = _PreviousResult;
    }

    void PrintResult() {
        cout << "Result After " << _LastOperation << " " << _LastNumber << " is: " << _Result << endl;
    }

    float GetFinalResult() {
        return _Result;
    }
};

int main()
{
    clsCalculator Calculator1;


    Calculator1.Add(50);
    Calculator1.PrintResult();

    Calculator1.Clear();
    Calculator1.PrintResult();

    Calculator1.Add(100);
    Calculator1.PrintResult();

    Calculator1.Subtract(80);
    Calculator1.PrintResult();

    Calculator1.Divide(0);
    Calculator1.PrintResult();

    Calculator1.Divide(5);
    Calculator1.PrintResult();

    Calculator1.CancelLastOperation();
    Calculator1.PrintResult();

    Calculator1.Multiply(2);
    Calculator1.PrintResult();


    return 0;
}

