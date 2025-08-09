#include <iostream>
#include <string>
using namespace std;

string ReadString() {
	string UserString = "";
	cout << "Please enter your string:" << endl;
	getline(cin, UserString);
	return UserString;
}

void PrintFirstLetterOfEachWord(string UserString) {
	bool isFirstLetter = true;
	cout << "\nFirst letters of this string:" << endl;

	for (int i = 0; i < UserString.length(); i++) {
		if (UserString[i] != ' ' && isFirstLetter)
			cout << UserString[i] << endl;

		isFirstLetter = UserString[i] == ' ' ? true : false;
	}
}

int main()
{

	PrintFirstLetterOfEachWord(ReadString());
}
