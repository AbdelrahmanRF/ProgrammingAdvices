#include <iostream>
#include <string>
#include <vector>
using namespace std;

string JoinString(vector<string> vString, string Delimiter) {
	string String = "";
	for (string &Word : vString) {
		String = String + Word + Delimiter;
	}
	return String.substr(0, String.length() - Delimiter.length());
}

int main()
{
	vector<string> vString = { "Mohammed","Faid","Ali","Maher" };
	cout << "Vector after join: \n";
	cout << JoinString(vString, "**") << endl;
	
	return 0;
}

