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

string LowerFirstLetterOfEachWord(string UserString) {
	bool isFirstLetter = true;

	for (int i = 0; i < UserString.length(); i++) {
		if (UserString[i] != ' ' && isFirstLetter)
			UserString[i] = tolower(UserString[i]);

		isFirstLetter = UserString[i] == ' ' ? true : false;
	}
	return UserString;
}

int main()
{
	string UserString = ReadString();

	cout << "\nString after conversion:\n";
	UserString = LowerFirstLetterOfEachWord(UserString);
	cout << UserString << endl;
}
