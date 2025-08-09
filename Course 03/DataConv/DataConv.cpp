#include <iostream>
#include <string>
#include <format>
using namespace std;

int main()
{
    double Num1 = 18.99;
    int Num2;
    string str_num = "126.1234";

    // solve cin taking \n as input
    //cin.ignore(1, '\n');
    
    //Implecit  
    //Num2 = Num1;
    
    //Explecit
    //Num2 = (int)Num1;
    Num2 = int(Num1);

    int num_int = stoi(str_num);
    float num_float = stof(str_num);
    double num_double = stod(str_num);

    string str_num1, str_num2;
    str_num1 = to_string(num_int);
    str_num = to_string(num_double);

    cout << Num2 << "\n";
    cout << num_int << "\n";
    cout << num_float << "\n";
    cout << num_double << "\n";
    cout << str_num1 << "\n";
    cout << str_num2 << "\n";
}
