#include <iostream>
#include <string>
#include <vector>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String?\n";
	getline(cin, S1);

	return S1;
}

vector<string> Split(string S1, string Delimiter = " ") {
	short Pos = 0;
	string Word;
	vector<string> Words;

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


int main()
{
	string S1 = ReadString();
	vector<string> Words = Split(S1, "-");

	cout << "\nTokens = " << Words.size() << endl;

	for (string& Word : Words) {
		cout << Word << endl;
	}

	return 0;
}

