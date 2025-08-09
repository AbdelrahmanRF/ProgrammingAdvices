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

void PrintInvertedLettersPattern(short Num) {
	for (int i = Num; i > 0; i--) {
		for (int j = i; j > 0; j--) {
			cout << (char)(i + 64);
		}
		cout << endl;
	}
}

int main()
{
	PrintInvertedLettersPattern(ReadPositiveNumber("Please Enter a Number:"));
}
