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

void PrintSumDigits(int Num) {
	int Sum = 0;
	while (Num != 0) {
		Sum += Num % 10;
		Num /= 10;
	}
	cout << Sum;
}

int main()
{
	PrintSumDigits(ReadPositiveNumber("Please Enter a Number"));
}
