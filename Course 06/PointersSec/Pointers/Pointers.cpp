#include <iostream>
using namespace std;

int main()
{
	int a = 5;
	int* p = &a;

	cout << "a value		= " << a << endl;
	cout << "a address value  = " << &a << endl;
	cout << "p value		= " << p << endl;
	cout << "Value of the address that p is pointing to is	= " << *p << endl;

	*p = 10;
	cout << "a value = " << a << endl;

	a = 30;
	cout << "a value after = " << a << endl;
	cout << "Value of the address after	= " << *p << endl;

	int& x = a;
	cout << "x value		= " << x << endl;
	cout << "&x value  = " << &x << endl;

	x = 5;

	cout << "x value		= " << x << endl;
	cout << "a value		= " << a << endl;

	int b = 20;
	p = &b;
	//x = b; //will only asign value b to x and a

}
