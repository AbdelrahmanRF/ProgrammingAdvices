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

int CountDigitFrequency(int Number, short DigitToCheck) {
	int Sum = 0;

	while (Number != 0) {
		if (Number % 10 == DigitToCheck)
			Sum++;
		Number /= 10;
	}

	return Sum;

}


int main()
{
	int Number = ReadPositiveNumber("Please Enter a Number");
	short DigitToCheck = ReadPositiveNumber("Please Enter the digit");

	cout << format("\n{} Frequency in {} = {}\n", DigitToCheck, Number, CountDigitFrequency(Number, DigitToCheck));

}
