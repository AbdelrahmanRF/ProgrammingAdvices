#include <iostream>
using namespace std;

float ReadNumber() {
	float Num;
	cout << "Please Enter a Number\n";
	cin >> Num;
	return Num;
}

float Sqrt(float Num) {
	return pow(Num, 0.5);
}

int main()
{
	float Num = ReadNumber();

	cout << "Ceil Sqrt : " << Sqrt(Num) << endl;
	cout << "C++ sqrt Result : " << sqrt(Num) << endl;

}
