#include <iostream>
using namespace std;

class clsA 
{

public:
    int Var = 0;
    static int Counter;

    clsA() {
        Counter++;
    }

    static int Function1() {
        return 10;
    }

    int Function2() {
        return 20;
    }

    void Print() {
        cout << "\nvar     = " << Var << endl;         
        cout << "counter = " << Counter << endl;
    }
};

int clsA::Counter = 0; //static variable initialization outside the class because it has to be before any function.

int main() {

    clsA A1, A2, A3;

    A1.Var = 10;
    A2.Var = 20;
    A3.Var = 30;

    A1.Print();     
    //A2.Print();     
    //A3.Print();

    //A1.Counter = 500;

    //cout << "\nafter changing the static member counter in one object:\n";     
    //A1.Print();     
    //A2.Print();     
    //A3.Print();


    cout << endl << clsA::Function1();
    cout << endl << A1.Function1();
    cout << endl << A1.Function2();

    return 0;
}
