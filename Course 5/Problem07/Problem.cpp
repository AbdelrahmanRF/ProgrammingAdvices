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

void PrintReversedDigits(int Num) {
	int ReversedNum = 0;
	while (Num != 0) {
		ReversedNum = ReversedNum * 10 + Num % 10;
		Num /= 10;
	}
	cout << ReversedNum;
}

int main()
{
	PrintReversedDigits(ReadPositiveNumber("Please Enter a Number"));
}
