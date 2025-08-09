#include <iostream>
#include <format>
using namespace std;


int ReadNumber() {
	int Num;
	cout << "Enter A Number To Print To?\n";
	cin >> Num;

	return Num;
}


void PrintNumbersToN(int To) {
	for (int i = 1; i <= To; i++)
		cout << i << '\n';
}



int main()
{
	PrintNumbersToN(ReadNumber());
	return 0;
}
