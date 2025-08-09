#include <iostream>
#include <format>
using namespace std;

string ReadPassword(string Message) {
	string Password;
	cout << Message << endl;
	cin >> Password;
	return Password;
}


bool GuessPasswordFromAAAtoZZZ(string Password) {
	int TrialNumber = 0;
	string Word = "";
	for (int i = 65; i <= 90; i++) {
		for (int j = 65; j <= 90; j++) {
			for (int k = 65; k <= 90; k++) {
				TrialNumber++;
				Word = Word + (char)i;
				Word = Word + (char)j;
				Word = Word + (char)k;
				cout << format("Trial[{}]: {}\n", TrialNumber, Word);

				if (Password == Word) {
					cout << format("\nPassword is {}", Word) << endl;
					cout << format("Found after {} Trial(s)", TrialNumber) << endl;
					return 1;
				}
				Word = "";

			}
		}
	}
	return 0;

}

int main()
{
	GuessPasswordFromAAAtoZZZ(ReadPassword("Please Enter Password"));
}
