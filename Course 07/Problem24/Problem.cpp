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

string UppercaseFirstLetterOfEachWord(string UserString) {
	bool isFirstLetter = true;
	cout << "\nString after conversion:" << endl;

	for (int i = 0; i < UserString.length(); i++) {
		if (UserString[i] != ' ' && isFirstLetter)
			UserString[i] = toupper(UserString[i]);

		isFirstLetter = UserString[i] == ' ' ? true : false;
	}
	return UserString;
}

int main()
{

	cout << UppercaseFirstLetterOfEachWord(ReadString());
}
