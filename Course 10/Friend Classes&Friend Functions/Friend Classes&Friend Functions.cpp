#include <iostream>  
using namespace std;

//Abstract Class / Interface
class clsA
{
    int _Var1;

protected:
    int _Var2;
public:
    int Var3;

    clsA() {
        _Var1 = 10;
        _Var2 = 20;
        Var3 = 30;
    }

    friend class clsB;

    friend int MySum(clsA A1);
};


class clsB 
{
public:
    void Display(clsA A1) {
        cout << "The value of Var1= " << A1._Var1 << endl;
        cout << "The value of Var2= " << A1._Var2 << endl;
        cout << "The value of Var3= " << A1.Var3 << endl;
    }
};


int MySum(clsA A1) 
{
    return A1._Var1 + A1._Var2;
}

int main()
{
    clsA A1; 
    clsB B1;    

    B1.Display(A1);

    cout << "The value of Var1 + Var2 = " <<  MySum(A1);
}
