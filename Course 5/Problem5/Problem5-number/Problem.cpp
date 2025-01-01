#include <iostream>
#include <format>
using namespace std;


int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

void PrintReverseInteger(int Num) {
	int Reminder = 0;

	while (Num != 0) {
		cout << Reminder * 10 + Num % 10 << endl;
		Num /= 10;
	}
}

int main()
{
	int Num = ReadPositiveNumber("Please Enter a Positive Number: ");
	PrintReverseInteger(Num);
}
