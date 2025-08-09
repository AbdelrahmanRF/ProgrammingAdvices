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
int Floor(float Num) {

	if (Num < 0) {
		return GetFractionPart(Num) == 0 ? Num : --Num;
	}
	else
		return Num;
}

int main()
{
	float Num = ReadNumber();

	cout << "Floor Result : " << Floor(Num) << endl;
	cout << "C++ floor Result : " << floor(Num) << endl;

}
