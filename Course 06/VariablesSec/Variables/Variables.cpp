#include <iostream>
using namespace std;

int Num = 10;
auto Name = "User";

void MyFunc() {
	//int Number = 1;
	static int Number = 1;

	cout << "Value of Number is: " << Number << endl;
	Number++;
}

int main()
{
	MyFunc();
	MyFunc();
	MyFunc();


	cout << "\n" << Name << endl;

	cout << endl;

	int a = 5;
	int& x = a;

	cout << &a << endl;
	cout << &x << endl;

	x = 20;

	cout << a << endl;
	cout << x << endl;

	return 0;
}
