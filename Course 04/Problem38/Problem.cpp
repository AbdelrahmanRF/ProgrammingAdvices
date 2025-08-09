#include <iostream>
#include <format>
using namespace std;


//int ReadNumber(string Message) {
//	int Num;
//	cout << Message << endl;
//	cin >> Num;
//
//	return Num;
//}


//bool isPrimeNumber(int Num) {
//	if (Num <= 1)
//		return false;
//
//	for (int i = 2; i <= floor(Num / 2); i++) {
//		if (Num % i == 0)
//			return false;
//	}
//	return true;
//}

enum enPrimeNotPrime {
	Prime = 1,
	NotPrime = 2
};

float ReadPositiveNumber(string Message) {
	float Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);


	return Num;
}

enPrimeNotPrime CheckPrime(int Num) {
	if (Num <= 1)
		return enPrimeNotPrime::NotPrime;

	for (int i = 2; i <= round(Num / 2); i++) {
		if (Num % i == 0)
			return enPrimeNotPrime::NotPrime;
	}
	return enPrimeNotPrime::Prime;
}

void PrintNumberType(int Num) {
	cout << format("{} Is {}", Num, CheckPrime(Num) == enPrimeNotPrime::Prime ?
		"Prime Number" : "Not Prime Number");
}
int main()
{
	//int Num = ReadNumber("Enter a Number");

	//cout << format("{} Is {}", Num, isPrimeNumber(Num) ? "Prime Number" : "Not Prime Number");

	PrintNumberType(ReadPositiveNumber("Please Enter a Positve Number"));

	return 0;
}
