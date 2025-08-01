#include <iostream>
#include <vector>
using namespace std;

class clsA
{ 
public: 
    int x; 

    clsA() {}

    clsA(int x) {
        this->x = x;
    }

    void Print() 
    {
        cout << "The value of x=" << x << endl; 
    } 
};

// object sent by value, any updated will not b reflected
// on the original object
void Fun1(clsA A)
{
    A.x = 100;
}

// object sent by reference, any updated will be reflected
// on the original object
void Fun2(clsA &A)
{
    A.x = 200;
}

int main()
{
    clsA A1(50);    

    cout << "\nA.x before calling function1: \n";    
    A1.Print(); //Pass by value, object will not be affected. 

    Fun1(A1);    
    cout <<"\nA.x after calling function1 byval: \n";    
    A1.Print(); //Pass by value, object will be affected.

    Fun2(A1);    
    cout <<"\nA.x after calling function2 byref: \n";  
    A1.Print();

    cout << endl;

    vector <clsA> v1; 
    short NumberOfObjects = 5;

    for (int i = 0; i < NumberOfObjects; i++) 
    {
        v1.push_back(clsA(i));
    }

    for (int i = 0; i < NumberOfObjects; i++)
    {
        v1[i].Print();
    }

    cout << endl;

    clsA* arrA = new clsA[NumberOfObjects];

    for (int i = 0; i < NumberOfObjects; i++)
    {
        arrA[i] = clsA(i);
    }

    for (int i = 0; i < NumberOfObjects; i++)
    {
        arrA[i].Print();
    }

    delete[] arrA;

    cout << endl;

    clsA obj[] = { clsA(1) , clsA(2) , clsA(3) };

    for (int i = 0; i < 3; i++)
    {
        obj[i].Print();
    }

}
