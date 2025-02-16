#include <iostream>
#include <string>
using namespace std;

string ReadString() {
	string S1 = "";
	cout << "Please Enter Your String?\n";
	getline(cin, S1);

	return S1;
}

bool IsVowel(char Ch1)
{
	Ch1 = tolower(Ch1);

	return ((Ch1 == 'a') || (Ch1 == 'e') || (Ch1 == 'i') || (Ch1
		== 'o') || (Ch1 == 'u'));
}

int CountVowels(string S1) {
	int Counter = 0;
	for (char C : S1) {
		if (IsVowel(C))
			Counter++;
	}
	return Counter;
}

int main()
{
	string S1 = ReadString();

	printf("\nNumber of Vowels is %d", CountVowels(S1));
	return 0;
}

