#include <iostream>
using namespace std;

short ReadPositiveNumber(string Message) {
	short Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

void PrintLettersPattern(short Num) {
	for (int i = 1; i <= Num; i++) {
		for (int j = 1; j <= i; j++) {
			cout << (char)(i + 64);
		}
		cout << endl;
	}
}

int main()
{
	PrintLettersPattern(ReadPositiveNumber("Please Enter a Number:"));
}
