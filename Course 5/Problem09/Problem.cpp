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

int CountDigitFrequency(short DigitToCheck, int Number) {
	int Sum = 0;

	while (Number != 0) {
		if (Number % 10 == DigitToCheck)
			Sum++;
		Number /= 10;
	}
	return Sum;
}

void PrintDigitsFrequency(int Number) {
	for (int i = 0; i < 10; i++) {
		if (CountDigitFrequency(i, Number))
			cout << format("\n{} frequecny is {}\n", i, CountDigitFrequency(i, Number));
	}

}

int main()
{
	PrintDigitsFrequency(ReadPositiveNumber("Please Enter a Number"));
}
