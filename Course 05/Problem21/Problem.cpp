#include <iostream>
#include <cstdlib>
#include <format>
using namespace std;

int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

int RandomNumber(int From, int To) {

	int RandomNum = rand() % (To - From + 1) + From;
	return RandomNum;
}

string GenerateKey() {
	string Key = "";
	for (int i = 1; i <= 16; i++) {
		Key = Key + (char)RandomNumber(65, 90);
		if (i % 4 == 0 && i != 16)
			Key = Key + "-";
	}
	return Key;
}

void PrintNKeys(int N) {
	for (int i = 1; i <= N; i++)
		cout << format("Key[{}]: {}", i, GenerateKey()) << endl;
}

int main()
{

	srand((unsigned)time(NULL));
	PrintNKeys(ReadPositiveNumber("Please Enter Number of Keys"));

	return 0;
}
