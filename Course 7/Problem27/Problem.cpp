#include <iostream>
#include <string>
#include <cctype>
using namespace std;

char ReadChar()
{
	char Ch1;
	cout << "Please Enter a Character?\n";
	cin >> Ch1;

	return Ch1;
}

char InvertLetterCase(char Ch1) {
	return isupper(Ch1) ? tolower(Ch1) : toupper(Ch1);
}


int main()
{
	char Ch1 = ReadChar();
	cout << "\nChar after inverting case:\n";
	Ch1 = InvertLetterCase(Ch1);
	cout << Ch1 << endl;
}
