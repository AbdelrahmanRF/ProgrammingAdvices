#include <iostream>
#include <format>
using namespace std;


void Read3Numbers(int& Num1, int& Num2, int& Num3) {
	cout << "Please Enter The First Number?\n";
	cin >> Num1;
	cout << "Please Enter The Second Number?\n";
	cin >> Num2;
	cout << "Please Enter The Third Number?\n";
	cin >> Num3;
}


int MaxOf3Numbers(int Num1, int Num2, int Num3) {
	return Num1 > Num2 ?
		(Num1 > Num3 ? Num1 : Num3) :
		(Num2 > Num3 ? Num2 : Num3);
}

void PrintResult(int Result) {
	cout << format("\nThe max number is: {}\n", Result);
}

int main()
{
	int Num1, Num2, Num3;

	Read3Numbers(Num1, Num2, Num3);
	PrintResult(MaxOf3Numbers(Num1, Num2, Num3));

	return 0;
}
