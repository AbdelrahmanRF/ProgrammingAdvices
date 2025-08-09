#include <iostream>
#include <string>
#include <cctype>
using namespace std;

enum enWhatToCount { SmallLetters = 0, CapitalLetters = 1, All = 3 };

string ReadString() {
	string UserString = "";
	cout << "Please enter your string:" << endl;
	getline(cin, UserString);
	return UserString;
}

int CountLetters(string S1, enWhatToCount WhatToCount = enWhatToCount::All) {
	if (WhatToCount == enWhatToCount::All)
		return S1.length();

	int Counter = 0;

	for (int i = 0; i < S1.length(); i++) {
		if (WhatToCount == enWhatToCount::CapitalLetters && isupper(S1[i]))
			Counter++;

		if (WhatToCount == enWhatToCount::SmallLetters && islower(S1[i]))
			Counter++;
	}

	return Counter;

}

int CountCapitalLetters(string S1) {
	int Counter = 0;
	for (int i = 0; i < S1.length(); i++) {
		if (isupper(S1[i]))
			Counter++;
	}
	return Counter;
}

int CountSmallLetters(string S1) {
	int Counter = 0;
	for (int i = 0; i < S1.length(); i++) {
		if (islower(S1[i]))
			Counter++;
	}
	return Counter;
}

int main()
{
	string S1 = ReadString();
	cout << "\nString Length = " << S1.length();
	cout << "\nCapital Letters Count= " <<
		CountCapitalLetters(S1);
	cout << "\nSmall Letters Count= " << CountSmallLetters(S1);

	cout << "\n\nMethod 2\n";
	cout << "\nString Length = " << CountLetters(S1);
	cout << "\nCapital Letters Count= " << CountLetters(S1,
		enWhatToCount::CapitalLetters);
	cout << "\nSmall Letters Count= " <<
		CountLetters(S1, enWhatToCount::SmallLetters);
}
