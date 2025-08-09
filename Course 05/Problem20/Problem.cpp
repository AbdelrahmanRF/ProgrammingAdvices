#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To) {
	int RandomNum = rand() % (To - From + 1) + From;
	return RandomNum;
}

enum enCharType {
	SmallLetter = 1,
	CapitalLetter = 2,
	SpetialCharacter = 3,
	Digit = 4,
};

char GenerateRandomChar(enCharType CharType) {
	switch (CharType)
	{
	case SmallLetter:
		return (char)RandomNumber(97, 122);
	case CapitalLetter:
		return (char)RandomNumber(65, 90);
	case SpetialCharacter:
		return (char)RandomNumber(33, 47);
	case Digit:
		return (char)RandomNumber(48, 57);
	}
}

int main()
{
	//Seeds the random number generator in C++, called only once
	srand((unsigned)time(NULL));
	cout << GenerateRandomChar(enCharType::SmallLetter) << endl;
	cout << GenerateRandomChar(enCharType::CapitalLetter) << endl;
	cout << GenerateRandomChar(enCharType::SpetialCharacter) << endl;
	cout << GenerateRandomChar(enCharType::Digit) << endl;
	return 0;
}
