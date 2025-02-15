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

char ReadChar()
{
	char Ch1;
	cout << "\nPlease Enter a Character?\n";
	cin >> Ch1;

	return Ch1;
}

int CountLetter(string S1, char Ch1) {
	int LetterCount = 0;
	for (int i = 0; i < S1.length(); i++) {
		if (S1[i] == Ch1)
			LetterCount++;
	}
	return LetterCount;
}

int main()
{
	string S1 = ReadString();
	char Ch1 = ReadChar();

	printf("\nLetter \'%c\' Count = %d", Ch1, CountLetter(S1, Ch1));

}
