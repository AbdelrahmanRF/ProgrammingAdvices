#include <iostream>
#include <format>
using namespace std;


int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num < 0);

	return Num;
}

int Factorial(int Num) {
	int Factorial = 1;
	for (int i = Num; i >= 1; i--)
		Factorial = Factorial * i;

	return Factorial;
}


int main()
{
	cout << Factorial(ReadPositiveNumber("Enter N"));
	return 0;
}
