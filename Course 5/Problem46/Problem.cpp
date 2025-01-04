#include <iostream>
using namespace std;

float ReadNumber() {
	float Num;
	cout << "Please Enter a Number\n";
	cin >> Num;
	return Num;
}

float Abs(float Num) {
	return Num < 0 ? -Num : Num;
}

int main()
{
	float Num = ReadNumber();

	cout << "Abs Result : " << Abs(Num) << endl;
	cout << "C++ abs Result : " << abs(Num) << endl;
}
