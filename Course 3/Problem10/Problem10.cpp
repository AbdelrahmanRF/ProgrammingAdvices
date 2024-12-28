#include <iostream>
using namespace std;

int main()
{
	float FirstNum, SecondNum, ThirdNumber;
	cout << "Please Enter The First Number?\n";
	cin >> FirstNum;
	cout << "Please Enter The Second Number?\n";
	cin >> SecondNum;
	cout << "Please Enter The Third Number?\n";
	cin >> ThirdNumber;
	cout << '\n';

	cout << "The Average is: " << (FirstNum + SecondNum + ThirdNumber) / 3;

	return 0;
}
