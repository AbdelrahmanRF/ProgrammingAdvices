#include <iostream>
#include <format>
using namespace std;

int ReadNumber() {
	int Num;
	cout << "Please Enter a Number?\n";
	cin >> Num;

	return Num;
}

float HalfNumber(int Num) {
	return (float)Num / 2;
}

void PrintHalfNumber(int Num) {
	cout << format("Half of {} is {}", Num, HalfNumber(Num));
}

int main()
{

	PrintHalfNumber(ReadNumber());

	return 0;
}
