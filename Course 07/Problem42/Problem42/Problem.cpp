#include <iostream>
#include <string>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String:" << endl;
	getline(cin, S1);
	return	S1;
}

string Replace(string S1, string StringToReplace, string ReplaceTo) {

	short Pos = S1.find(StringToReplace);

	while (Pos != string::npos) {
		S1 = S1.replace(Pos, StringToReplace.length(), ReplaceTo);
		Pos = S1.find(StringToReplace);
	}
	return S1;
}

int main()
{
	string S1 = "Welcome to Jordan , Jordan is a nice country";
	string StringToReplace = "Jordan";
	string ReplaceTo = "USA";
	cout << "\nOrigial String\n" << S1;
	cout << "\n\nString After Replace:";
	cout << "\n" << Replace(S1, StringToReplace, ReplaceTo) << endl;

	return 0;
}