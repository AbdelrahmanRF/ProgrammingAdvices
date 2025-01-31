#include <iostream>
#include "MyLib.h"
using namespace std;
int main()
{
	int Mark = 90;
	int Num = -5;
	int Num2 = 0;
	int Array1[] = { 1,2,3,4,5 };
	string Result = MyLib::CheckPassFail(Mark);
	MyLib::Greeting("Abdelrahman");

	cout << "\nYour Result is: " << Result << endl;

	cout << "\n" << Num << " is " << MyLib::isZeroPositiveNegative(Num) << endl;

	for (int n : Array1) {
		cout << n << endl;
	}

	Num2 = MyLib::ReadNumber();
	cout << "\n" << Num2 << endl;

	cout << "Result is " << (12 & 25) << endl;
	cout << "Result is " << (12 | 25) << endl;
}
