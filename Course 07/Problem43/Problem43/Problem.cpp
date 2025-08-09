#include <iostream>
#include <string>
#include <vector>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String:" << endl;
	getline(cin, S1);
	return	S1;
}

vector<string> Split(string S1, string Delimiter = " ") {
	vector<string> Words;
	string Word = "";
	short Pos = 0;

	while ((Pos = S1.find(Delimiter)) != string::npos) {
		Word = S1.substr(0, Pos);

		if (Word != "") {
			Words.push_back(Word);
		}
		S1.erase(0, Pos + Delimiter.length());
	}
	if (S1 != "") {
		Words.push_back(S1);
	}

	return Words;
}

string Join(vector<string> Words, string Delimiter = " ") {
	string S1 = "";
	for (string& Word : Words) {
		S1 = S1 + Word + Delimiter;
	}

	return S1.substr(0, S1.length() - Delimiter.length());
}

string ToLower(string S1) {
	for (int i = 0; i < S1.length(); i++) {
		S1[i] = tolower(S1[i]);
	}
	return S1;
}

string Replace(string S1, string StringToReplace, string ReplaceTo, bool MatchCase = true) {
	string ReplacedStr = "";
	vector<string> Words;
	Words = Split(S1);

	for (string& Word : Words) {
		if (MatchCase) {
			if (Word == StringToReplace)
				Word = ReplaceTo;
		}
		else {
			if (ToLower(Word) == ToLower(StringToReplace))
				Word = StringToReplace;
		}
	}

	return Join(Words);
}

int main()
{
	string S1 = "Welcome to Jordan , jordan is a nice country";
	string StringToReplace = "Jordan";
	string ReplaceTo = "USA";

	cout << "\nOriginal String:\n" << S1;

	cout << "\n\nReplace with match case: ";
	cout << "\n" << Replace(S1,StringToReplace, ReplaceTo);

	cout << "\n\nReplace with dont match case: ";
	cout << "\n" << Replace(S1,StringToReplace, ReplaceTo, false);

	return 0;
}



