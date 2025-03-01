#include <iostream>
#include <string>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String?\n";
	getline(cin, S1);

	return S1;
}

void PrintEachWordInString(string S1) {
	cout << "\nYour String Words are:\n\n";
	string Delimiter = " ";
	short Pos = 0;
	string Word;

	while ((Pos = S1.find(Delimiter)) != string::npos) {
		Word = S1.substr(0, Pos);

		if (Word != "") {
			cout << Word << endl;
		}
		S1.erase(0, Pos + Delimiter.length());
	}
	if (S1 != "") {
		cout << S1 << endl;
	}
}


int main()
{
	PrintEachWordInString(ReadString());

	return 0;
}

