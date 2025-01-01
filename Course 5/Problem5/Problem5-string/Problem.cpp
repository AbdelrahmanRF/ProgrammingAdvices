#include <iostream>
#include <format>
#include <string>
using namespace std;


string ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return to_string(Num);
}

//string ReversedNumber(string Num) {
//	string ReversedNumber = "";
//	int NumberLength = Num.length();
//
//	for (int i = NumberLength - 1; i >= 0; i--) {
//		ReversedNumber += Num[i];
//	}
//
//	return ReversedNumber;
//}

void ReversedNumber(string Num) {
	int NumberLength = Num.length();

	for (int i = NumberLength - 1; i >= 0; i--) {
		cout << Num[i] << endl;
	}

}

int main()
{
	string Num = ReadPositiveNumber("Please Enter a Number");
	ReversedNumber(Num);
}
