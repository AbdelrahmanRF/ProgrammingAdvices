#pragma once
#include <iostream>
using namespace std;

namespace MyLib
{
	void Greeting(string Name) {
		cout << "Hello, " << Name << "!" << endl;
	}

	string CheckPassFail(int Mark) {
		return Mark >= 50 ? "Pass" : "Fail";
	}

	string isZeroPositiveNegative(int Num) {
		return (Num == 0) ? "Zero" : (Num > 0) ? "Positive" : "Negative";
	}

	int ReadNumber() {
		int Number = 0;
		cout << "Please Enter a Number: ";
		cin >> Number;

		while (cin.fail()) {
			// Ignore the error
			cin.clear();

			// Ignore all the inputted size until \n
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

			cout << "Invalid Number, Please Enter a Valid one: ";
			cin >> Number;
		}
		return Number;
	}
}