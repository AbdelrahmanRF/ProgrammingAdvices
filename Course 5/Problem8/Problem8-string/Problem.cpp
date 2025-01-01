#include <iostream>
#include <string>
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

int DigitFrequency(string Number, int Digit) {
	int Sum = 0;
	int NumberToSearch = Number[Digit - 1];
	int Length = Number.length();

	for (int i = 0; i < Length; i++) {
		if (Number[i] == NumberToSearch)
			Sum++;
	}
	return Sum;

}


int main()
{
	string Number = to_string(ReadPositiveNumber("Please Enter a Number"));
	int Digit = ReadPositiveNumber("Please Enter the digit");

	cout << format("\n{} Frequency in {} = {}\n", Number[Digit - 1], Number, DigitFrequency(Number, Digit));

}
