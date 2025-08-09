#include <iostream>
#include <format>
using namespace std;


void ReadNumbers(int& Num1, int& Num2) {
	cout << "Please Enter The First Number?\n";
	cin >> Num1;
	cout << "Please Enter The Second Number?\n";
	cin >> Num2;
}

void Swap2Numbers(int& Num1, int& Num2) {
	Num1 = Num1 + Num2;
	Num2 = Num1 - Num2;
	Num1 = Num1 - Num2;
}

void PrintNumbers(int Num1, int Num2, string Message) {
	cout << format("\n{}: {} {}\n", Message, Num1, Num2);
}

int main()
{
	int Num1, Num2;

	ReadNumbers(Num1, Num2);
	PrintNumbers(Num1, Num2, "Numbers Before Swap");

	Swap2Numbers(Num1, Num2);
	PrintNumbers(Num1, Num2, "Numbers After Swap");
	return 0;
}
