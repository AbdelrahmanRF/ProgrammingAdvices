#include <iostream>
#include <string>
using namespace std;

string TrimLeft(string S1) {

	for (short i = 0; i < S1.length(); i++) {
		if (S1[i] != ' ') {
			return S1.substr(i);
		}
	}
	return "";
}

string TrimRight(string S1) {
	for (short i = S1.length() - 1; i > 0; i--) {
		if (S1[i] != ' ') {
			return S1.substr(0, i + 1);
		}
	}
	return "";
}

string Trim(string S1) {
	return TrimRight(TrimLeft(S1));
}

int main()
{
	string S1 = "    Lorem ipsum dolor sit amet.    ";

	cout << "\nString = " << S1;
	cout << "\n\nTrim Left = " << TrimLeft(S1);
	cout << "\nTrim Right = " << TrimRight(S1);
	cout << "\nTrim = " << Trim(S1);

	return 0;
}
