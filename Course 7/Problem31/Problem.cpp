#include <iostream>
#include <string>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String?\n";
	getline(cin, S1);

	return S1;
}

char ReadChar() {
	char Ch1;
	cout << "Please Enter a Character?\n";
	cin >> Ch1;
	return Ch1;
}

char InvertCase(char Ch1) {
	return isupper(Ch1) ? tolower(Ch1) : toupper(Ch1);
}

//int CountLetter(string S1, char Ch1, bool MatchCase = true) {
//	int Counter = 0;
//	char invCase = InvertCase(Ch1);
//	for (int i = 0; i < S1.length(); i++) {
//		if (S1[i] == Ch1)
//			Counter++;
//		if (!MatchCase && S1[i] == invCase)
//			Counter++;
//	}
//
//	return Counter;
//}

int CountLetter(string S1, char Ch1, bool MatchCase = true) {
	int Counter = 0;

	for (char C : S1) {
		if (MatchCase) {
			if (C == Ch1)
				Counter++;
		}
		else {
			if (tolower(C) == tolower(Ch1))
				Counter++;
		}
	}

	return Counter;
}

int main()
{
	string S1 = ReadString();
	char Ch1 = ReadChar();

	printf("\nLetter \'%c\' Count = %d", Ch1, CountLetter(S1, Ch1));

	printf("\nLetter \'%c\' or \'%c\' Count = %d", Ch1, InvertCase(Ch1), CountLetter(S1, Ch1, false));

	return 0;
}

