#include <iostream>
#include <format>
using namespace std;


//int ReadPINCode(string Message) {
//	int Num;
//	cout << Message << endl;
//	cin >> Num;
//
//	return Num;
//}
//
//bool CheckPIN(int Num) {
//	return Num == 1234;
//}
//
//string DisplayBalance() {
//	int Num = ReadPINCode("Please Enter Your PIN");
//	if (CheckPIN(Num))
//		return "7500";
//
//	do {
//		Num = ReadPINCode("Wrong PIN, Please Enter The Correct PIN");
//	} while (!CheckPIN(Num));
//
//	return "7500";
//}

string ReadPINCode(string Message) {
	string PINCode;
	cout << Message << endl;
	cin >> PINCode;

	return PINCode;
}

bool Login() {
	string PINCode;

	do {
		PINCode = ReadPINCode("Please Enter PIN Code");

		if (PINCode != "1234") {
			cout << "\nWrong PIN\n";
			system("color 4F");
		}
		else
			return 1;
	} while (PINCode != "1234");
}
float main()
{
	if (Login()) {
		system("color 2F");
		cout << format("\nYour Total Balance : {}\n", 7500);
	}

	return 0;
}
