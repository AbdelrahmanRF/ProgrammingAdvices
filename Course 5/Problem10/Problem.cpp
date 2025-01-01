#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

int ReverseNumber(int Number) {
	int Sum = 0;
	while (Number != 0) {
		Sum = Sum * 10 + Number % 10;
		Number /= 10;
	}
	return Sum;
}

void PrintNumberDigitsInOrder(int Number) {
	int ReversedNumber = ReverseNumber(Number);

	while (ReversedNumber != 0) {
		cout << ReversedNumber % 10 << endl;
		ReversedNumber /= 10;
	}
}

int main()
{
	PrintNumberDigitsInOrder(ReadPositiveNumber("Please Enter a Number"));
}
