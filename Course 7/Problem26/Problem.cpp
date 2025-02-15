#include <iostream>
#include <string>
#include <cctype>
using namespace std;

string ReadString() {
	string UserString = "";
	cout << "Please enter your string:" << endl;
	getline(cin, UserString);
	return UserString;
}

string LowerEachWord(string UserString) {
	for (int i = 0; i < UserString.length(); i++) {
		UserString[i] = tolower(UserString[i]);
	}
	return UserString;
}

string CapitalizeEachWord(string UserString) {
	for (int i = 0; i < UserString.length(); i++) {
		UserString[i] = toupper(UserString[i]);
	}
	return UserString;
}

int main()
{
	string UserString = ReadString();

	cout << "\nString after Upper:\n";
	UserString = CapitalizeEachWord(UserString);
	cout << UserString << endl;

	cout << "\nString after Lower:\n";
	UserString = LowerEachWord(UserString);
	cout << UserString << endl;
}
