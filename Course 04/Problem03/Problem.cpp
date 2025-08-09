#include <iostream>
#include <format>
#include <string>
using namespace std;

enum enNumberType {
	Odd = 0,
	Even = 1
};

int ReadUserNumber() {
	int Num;
	cout << "Please Enter A number?" << endl;
	cin >> Num;

	return Num;
}

enNumberType CheckNumberType(int Num) {

	if (Num % 2 == 0)
		return enNumberType::Even;
	else
		return enNumberType::Odd;
}

void PrintNumberType(enNumberType NumberType) {
	if (NumberType == enNumberType::Even)
		cout << "\nEven\n";
	else
		cout << "\nOdd\n";
}
//void CheckEven(int Num) {
//	if (Num % 2 == 0) {
//		cout << "\nEven\n";
//	}
//	else {
//		cout << "\nOdd\n";
//	}
//}

int main()
{
	int Num = ReadUserNumber();
	PrintNumberType(CheckNumberType(Num));

	return 0;
}
