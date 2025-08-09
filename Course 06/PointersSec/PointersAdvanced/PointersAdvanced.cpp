#include <iostream>
using namespace std;

//void swap(int& a, int& b) {
//	a = a + b;
//	b = a - b;
//	a = a - b;
//}

void swap(int* n1, int* n2) {
	*n1 = *n1 + *n2;
	*n2 = *n1 - *n2;
	*n1 = *n1 - *n2;
}

struct stEmployee
{
	string Name;
	float Salary;
};

int main()
{
	int a = 10, b = 5, arr[4] = { 1,2,3,4 }, * ptr;
	cout << "a before swapping = " << a << endl;
	cout << "b before swapping = " << b << endl;
	//swap(a, b);
	swap(&a, &b);
	cout << "a after swapping = " << a << endl;
	cout << "b after swapping = " << b << endl;


	ptr = arr;

	cout << "addresses are:" << endl;
	cout << ptr << endl;
	cout << ptr + 1 << endl;
	cout << ptr + 2 << endl;
	cout << ptr + 3 << endl;

	cout << "\nvalues are:\n";
	cout << *(ptr) << endl;
	cout << *(ptr + 1) << endl;
	cout << *(ptr + 2) << endl;
	cout << *(ptr + 3) << endl;

	stEmployee Employee1 = { "Assad", 500 }, * p;
	p = &Employee1;

	cout << "\nvalues are:\n";
	cout << p->Name << endl;
	cout << p->Salary << endl << endl;


	void* GenericP;

	float F1 = 10.5;
	int x = 50;

	GenericP = &F1;

	cout << *(static_cast<float*>(GenericP)) << endl;

	GenericP = &x;

	cout << *(static_cast<int*>(GenericP)) << endl;
}