#include <iostream>
#include <format>
using namespace std;


void Read2Numbers(int& Num1, int& Num2) {
	cout << "Please Enter The First Number?\n";
	cin >> Num1;
	cout << "Please Enter The Second Number?\n";
	cin >> Num2;
}

int MaxOf2Numbers(int Num1, int Num2) {
	//return max(Num1, Num2);
	return Num1 > Num2 ? Num1 : Num2;
}

void PrintResult(int Result) {
	cout << format("\nThe max number is: {}\n", Result);
}

int main()
{
	int Num1, Num2;

	Read2Numbers(Num1, Num2);
	PrintResult(MaxOf2Numbers(Num1, Num2));

	return 0;
}
