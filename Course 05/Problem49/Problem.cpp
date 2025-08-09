#include <iostream>
using namespace std;

float ReadNumber() {
	float Num;
	cout << "Please Enter a Number\n";
	cin >> Num;
	return Num;
}

float GetFractionPart(float Num) {
	return Num - (int)Num;
}
int Ceil(float Num) {

	if (Num < 0) {
		return Num;
	}
	else
		return GetFractionPart(Num) == 0 ? Num : ++Num;
}

int main()
{
	float Num = ReadNumber();

	cout << "Ceil Result : " << Ceil(Num) << endl;
	cout << "C++ ceil Result : " << ceil(Num) << endl;

}
