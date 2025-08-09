#include <iostream>
#include "clsInputValidate.h"
using namespace std;

int main()
{
    cout << (clsInputValidate::isNumberBetween(15, 10, 20) ? "Yes" : "No") << endl;
    cout << (clsInputValidate::isNumberBetween(15, 20, 10) ? "Yes" : "No") << endl;

    cout << (clsInputValidate::isNumberBetween(15.5, 21.5, 25.5) ? "Yes" : "No") << endl;

    cout << (clsInputValidate::isDateBetween(clsDate(15,8 ,2020), clsDate(1,8 ,2019), clsDate(15,8 ,2021)) ? "Yes" : "No") << endl;

    cout << (clsInputValidate::isDateBetween(clsDate(15,8 ,2020), clsDate(15,8 ,2021), clsDate(1,8 ,2019)) ? "Yes" : "No") << endl;

    cout << (clsInputValidate::isDateBetween(clsDate(15,8 ,2020), clsDate(15,8 ,2020), clsDate(1,8 ,2021)) ? "Yes" : "No") << endl;

    cout << (clsInputValidate::isDateBetween(clsDate(15,8 ,2020), clsDate(-1,8 ,2019), clsDate(15,8 ,2021)) ? "Yes" : "No") << endl;

    

    cout << "\nPlease Enter a Number:\n";
    double x = clsInputValidate::ReadNumber<double>("Number is Invalid, Enter again:\n") ;
    cout << "x= " << x << endl;
    //cout << "x type is " << typeid(x).name() << endl;

    cout << "\nPlease Enter a Number between 1 and 5:\n";
    int y = clsInputValidate::ReadNumberBetween<int>(1,5);
    cout << "y= " << y << endl;


    cout << (clsInputValidate::IsValidDate(clsDate(35,12,2025)) ? "Yes" : "No") << endl;

}
