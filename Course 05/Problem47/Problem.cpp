#include <iostream>
using namespace std;

float ReadNumber() {
	float Num;
	cout << "Please Enter a Number\n";
	cin >> Num;
	return Num;
}

//float Abs(float Num) {
//	return Num < 0 ? -Num : Num;
//}

float GetFractionPart(float Num) {
	return Num - (int)Num;
}

int Round(float Num) {
	//float decimalNum = Num - (int)Num;
	float FractionPart = GetFractionPart(Num);

	//if (Abs(decimalNum) >= 0.5)
	if (abs(FractionPart) >= 0.5) {
		//return Num > 0 ? Num + 1 : Num - 1;
		return Num > 0 ? ++Num : --Num;
	}
	else
		return Num;
}

int main()
{
	float Num = ReadNumber();

	cout << "Round Result : " << Round(Num) << endl;
	cout << "C++ round Result : " << round(Num) << endl;

}
