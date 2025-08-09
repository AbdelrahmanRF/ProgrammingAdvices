#include <iostream>
#include <string>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String?\n";
	getline(cin, S1);

	return S1;
}

int CountWords(string S1) {
	string Delimiter = " ";
	short Pos = 0;
	string Word;
	short Counter = 0;

	while ((Pos = S1.find(Delimiter)) != string::npos) {
		Word = S1.substr(0, Pos);

		if (Word != "") {
			Counter++;
		}
		S1.erase(0, Pos + Delimiter.length());
	}
	if (S1 != "") {
		Counter++;
	}
	return Counter;
}

int main()
{
	string S1 = ReadString();

	cout << "\nThe number of words in your string is: ";
	cout << CountWords(S1);

	return 0;
}

