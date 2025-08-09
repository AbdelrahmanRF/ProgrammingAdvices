#include <iostream>
using namespace std;

// Function declaration 
void Add(int, int);
//void Add(int = 40, int = 60);

void Greeting(string GreetWord = "Hello", string Name = "User") {
	cout << GreetWord << " " << Name << endl;
}

double MySum(double a, double b) {
	return (a + b);
}

int MySum(int a, int b) {
	return (a + b);
}

int MySum(int a, int b, int c) {
	return (a + b + c);
}

int SumFromTo(int From, int To) {
	if (From > To) return 0;
	return From + SumFromTo(From + 1, To);
}

void PrintNumbers(int From, int To) {
	if (From <= To) {
		cout << From << endl;
		PrintNumbers(From + 1, To);
	}
}

void PrintNumbersDec(int From, int To) {
	if (From >= To) {
		cout << From << endl;
		PrintNumbersDec(From - 1, To);
	}
}

int CalcPow(int Num, int PowTo) {
	if (PowTo == 0) return 1;

	return Num * CalcPow(Num, PowTo - 1);
}

int main()
{
	Add(4, 6);
	cout << endl;
	Greeting();


	cout << MySum(1, 2) << endl;
	cout << MySum(1.5, 2.1) << endl;
	cout << MySum(1, 2, 3) << endl;

	cout << SumFromTo(5, 10);
	cout << endl;

	PrintNumbers(1, 4);
	cout << endl;

	PrintNumbersDec(4, 2);
	cout << endl;

	cout << CalcPow(4, 4) << endl;

	return 0;
}

// Function definition 
void Add(int a, int b) {
	cout << a + b;
}