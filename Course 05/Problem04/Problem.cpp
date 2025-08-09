#include <iostream>
using namespace std;


int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}


bool isPerfect(int Num) {
	int Sum = 0;
	for (int i = 1; i < Num; i++) {
		if (Num % i == 0)
			Sum += i;
	}
	return Sum == Num;
}

void PrintPerfectNumbersToN(int N) {
	for (int i = 1; i <= N; i++) {
		if (isPerfect(i))
			cout << i << endl;
	}
}

int main()
{
	PrintPerfectNumbersToN(ReadPositiveNumber("Please Enter a Positive Number"));
}
