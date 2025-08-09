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
	string Word;
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


//string ReverseString(vector<string> Words, string Delimiter = " ") {
//	string ReversedStr = "";
//
//	for (int i = Words.size() - 1; i >= 0; i--) {
//		ReversedStr = ReversedStr + Words[i] + Delimiter;
//	}
//	return ReversedStr;
//}

string ReverseString(string S1) {
	string ReversedStr = "";
	vector<string> Words;
	Words = Split(S1);

	vector<string>::iterator iter = Words.end();

	while (iter != Words.begin()) {
		--iter;

		ReversedStr += *iter + " ";
	}

	ReversedStr = ReversedStr.substr(0, ReversedStr.length() - 1);
	return ReversedStr;
}

int main()
{
	//string ReversedStr = ReadString();
	string S1 = ReadString();

	//cout << "String After Reverse:\n" << ReverseString(Split(ReversedStr));
	cout << "\nString After Reverse:\n" << ReverseString(S1) << endl;

	return 0;
}

