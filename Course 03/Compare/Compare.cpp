#include <iostream>
#include <format>
using namespace std;

int main()
{
	int Num1, Num2;
	cout << "Please Enter The First Number?\n";
	cin >> Num1;
	cout << "Please Enter The Second Number?\n";
	cin >> Num2;

	cout << '\n';


	cout << format("{}{}{} is {}", Num1, "==", Num2, Num1 == Num2) << endl;
	cout << format("{}{}{} is {}", Num1, "!=", Num2, Num1 != Num2) << endl;
	cout << format("{}{}{} is {}", Num1, ">", Num2, Num1 > Num2) << endl;
	cout << format("{}{}{} is {}", Num1, "<", Num2, Num1 < Num2) << endl;
	cout << format("{}{}{} is {}", Num1, ">=", Num2, Num1 >= Num2) << endl;
	cout << format("{}{}{} is {}", Num1, "<=", Num2, Num1 <= Num2) << endl;

	return 0;
}
