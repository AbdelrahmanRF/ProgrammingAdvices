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

void PrintInvertedPattern(short Num) {
	for (int i = Num; i > 0; i--) {
		for (int j = i; j > 0; j--) {
			cout << i;
		}
		cout << endl;
	}
}

int main()
{
	PrintInvertedPattern(ReadPositiveNumber("Please Enter a Number:"));
}
