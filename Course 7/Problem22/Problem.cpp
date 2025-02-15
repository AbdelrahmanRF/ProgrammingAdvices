#include <iostream>
using namespace std;

void PrintFibonacciUsingRecursion(int Number, int pre1, int pre2) {

	int FebNumber = 0;

	if (Number > 0) {
		FebNumber = pre2 + pre1;
		pre2 = pre1;
		pre1 = FebNumber;

		cout << FebNumber << " ";
		PrintFibonacciUsingRecursion(Number - 1, pre1, pre2);
	}
}

int main()
{
	PrintFibonacciUsingRecursion(10, 0, 1);
}
