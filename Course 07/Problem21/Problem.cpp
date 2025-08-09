#include <iostream>
using namespace std;

void PrintFibonacci(int Number) {
	int pre2 = 0;
	int pre1 = 1;
	int FebNumber = 0;
	cout << "1 ";
	for (int i = 2; i <= Number; i++) {
		FebNumber = pre2 + pre1;
		cout << FebNumber << " ";
		pre2 = pre1;
		pre1 = FebNumber;
	}
}

int main()
{
	PrintFibonacci(10);
}
