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

char InvertLetterCase(char Ch1) {
	return isupper(Ch1) ? tolower(Ch1) : toupper(Ch1);
}

string InvertAllStringLettersCase(string S1) {
	for (int i = 0; i < S1.length(); i++) {
		S1[i] = InvertLetterCase(S1[i]);
	}
	return S1;
}

int main()
{
	string S1 = ReadString();

	cout << "\nString after inverting all letters:\n";
	S1 = InvertAllStringLettersCase(S1);
	cout << S1 << endl;
}
