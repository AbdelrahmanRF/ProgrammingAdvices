#include <iostream>
#include <string>
#include <vector>
using namespace std;

string JoinString(vector<string> vString, string Delimiter) {
	string String = "";
	for (string& Word : vString) {
		String = String + Word + Delimiter;
	}
	return String.substr(0, String.length() - Delimiter.length());
}

string JoinString(string arrString[], short Length, string Delimiter) {
	string String = "";
	for (int i = 0; i < Length; i++) {
		String = String + arrString[i] + Delimiter;
	}
	return String.substr(0, String.length() - Delimiter.length());
}

int main()
{
	vector<string> vString = { "Mohammed","Faid","Ali","Maher" };
	cout << "Vector after join: \n";
	cout << JoinString(vString, "**") << endl;

	string arrString[4] = { "Mohammed","Faid","Ali","Maher" };
	cout << "\nArray after join: \n";
	cout << JoinString(arrString, 4, "**") << endl;

	return 0;
}

