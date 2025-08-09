#include <iostream>
#include <format>
using namespace std;

enum enOddOrEven {
	Odd = 1,
	Even = 2,
};

int ReadNumber() {
	int Num;
	cout << "Enter A Number To Sum The Odd Numbers To?\n";
	cin >> Num;

	return Num;
}

enOddOrEven CheckOddOrEven(int Num) {
	return Num % 2 != 0 ? enOddOrEven::Odd : enOddOrEven::Even;
}

int SumOddNumbersToN(int To) {
	int Sum = 0;
	for (int i = 1; i <= To; i++)
		if (CheckOddOrEven(i) == enOddOrEven::Odd)
			Sum += i;

	return Sum;
}

void PrintResult(int Result) {
	cout << format("\nThe Total Sum of Odd Numbers: {}\n\n", Result);
}

int main()
{
	PrintResult(SumOddNumbersToN(ReadNumber()));
	return 0;
}
