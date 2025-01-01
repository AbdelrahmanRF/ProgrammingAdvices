#include <iostream>
#include <format>
using namespace std;

int NumberOfTries = 3;
string ReadPINCode(string Message) {
	string PINCode;
	cout << Message << endl;
	cin >> PINCode;

	return PINCode;
}

bool Login() {
	string PINCode;

	do {
		NumberOfTries--;
		PINCode = ReadPINCode("Please Enter PIN Code");

		if (PINCode == "1234") {
			return 1;
		}
		else {
			cout << format("\nWrong PIN, You have {} more tries\n", NumberOfTries);
			system("color 4F");
		}
	} while (PINCode != "1234" && NumberOfTries >= 1);
	return 0;
}
float main()
{
	if (Login()) {
		system("color 2F");
		cout << format("\nYour Total Balance : {}\n", 7500);
	}
	else {
		cout << "Card is locked";
	}

	return 0;
}
