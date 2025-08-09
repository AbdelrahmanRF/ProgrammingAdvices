#include <iostream>
using namespace std;

enum enPrimeNotPrime {
	Prime = 1,
	NotPrime = 2
};
int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

enPrimeNotPrime CheckPrime(int N) {
	for (int i = 2; i <= round(N / 2); i++) {
		if (N % i == 0)
			return enPrimeNotPrime::NotPrime;
	}
	return enPrimeNotPrime::Prime;
}

void PrintPrimeNumbersToN(int N) {
	for (int i = 1; i <= N; i++) {
		if (CheckPrime(i) == enPrimeNotPrime::Prime)
			cout << i << endl;
	}
}
int main()
{
	PrintPrimeNumbersToN(ReadPositiveNumber("Please Enter a Positive Number"));
}
