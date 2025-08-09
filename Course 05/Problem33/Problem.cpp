#include <iostream>
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
	return rand() % (To - From + 1) + From;
}

enum enCharType {
	SmallLetter = 1,
	CapitalLetter = 2,
	SpectialCharacter = 3,
	Digit = 4,
};

char GenerateRandomChar(enCharType CharType) {
	switch (CharType)
	{
	case SmallLetter:
		return (char)RandomNumber(97, 122);
	case CapitalLetter:
		return (char)RandomNumber(65, 90);
	case SpectialCharacter:
		return (char)RandomNumber(33, 47);
	case Digit:
		return (char)RandomNumber(48, 57);
	}
}

string GenerateRandomWord(enCharType CharType, short Length) {
	string Word = "";
	for (int i = 0; i < Length; i++) {
		Word = Word + GenerateRandomChar(CharType);
	}
	return Word;
}

string GenerateKey() {
	string Key = "";

	Key = Key + GenerateRandomWord(enCharType::CapitalLetter, 4) + "-";
	Key = Key + GenerateRandomWord(enCharType::CapitalLetter, 4) + "-";
	Key = Key + GenerateRandomWord(enCharType::CapitalLetter, 4) + "-";
	Key = Key + GenerateRandomWord(enCharType::CapitalLetter, 4);

	return Key;
}

void FillArrayWithKeys(string Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		Arr[i] = GenerateKey();
	}
}

void PrintArray(string Arr[100], int Length) {
	cout << "\nArray Elements:\n\n";
	for (int i = 0; i < Length; i++) {
		cout << "Array[" << i << "]: " << Arr[i] << endl;
	}
}


int main()
{
	srand(time(0));
	string Arr[100];
	int NumberOfElements;
	NumberOfElements = ReadPositiveNumber("Enter How Many Keys to Generate:");
	FillArrayWithKeys(Arr, NumberOfElements);

	PrintArray(Arr, NumberOfElements);


}
