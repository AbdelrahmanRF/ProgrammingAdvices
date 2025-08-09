#pragma once

#include <iostream>
#include "clsDate.h"
using namespace std;

class clsUtil
{
public:

	static void Srand() {
		srand((unsigned)time(NULL));
	}

	static int RandomNumber(int From, int To) {
		return rand() % (To - From + 1) + From;
	}

	enum enCharType { SmallLetter = 1, CapitalLetter = 2, Digit = 3, SpecialCharacter = 4, MixChars = 5 };

	static char GetRandomCharacter(enCharType CharType) {
		if (CharType == MixChars) {
			//Capital/Samll/Digits only
			CharType = (enCharType)RandomNumber(1, 3);
		}

		switch (CharType) {
		case SmallLetter:
			return char(RandomNumber(97, 122));

		case CapitalLetter:
			return (char)RandomNumber(65, 90);

		case SpecialCharacter:
			return (char)RandomNumber(33, 47);

		case Digit:
			return (char)RandomNumber(48, 57);
		}
	}

	static string GenerateWord(enCharType CharType, short Length) {
		string RandWord = "";

		for (short i = 0; i < Length; i++) {
			RandWord += GetRandomCharacter(CharType);
		}

		return RandWord;
	}

	static string GenerateKey(enCharType CharType = CapitalLetter) {
		string Key = "";

		for (short i = 0; i < 4; i++) {
			Key += GenerateWord(CharType, 4);
			if (i < 3)
				Key += "-";
		}

		return Key;
	}

	static void GenerateKeys(short NumberOfKeys, enCharType CharType) {
		for (short i = 0; i < NumberOfKeys; i++) {
			cout << GenerateKey(CharType) << endl;
		}
	}

	static void FillArrayWithRandomNumbers(int arr[100], int arrLength, int From, int To) {
		for (short i = 0; i < arrLength; i++) {
			arr[i] = RandomNumber(From, To);
		}
	}

	static void FillArrayWithRandomWords(string arr[100], int arrLength, enCharType CharType, short WordLength) {
		for (short i = 0; i < arrLength; i++) {
			arr[i] = GenerateWord(CharType, WordLength);
		}
	}

	static void FillArrayWithRandomKeys(string arr[100], int arrLength, enCharType CharType) {
		for (short i = 0; i < arrLength; i++) {
			arr[i] = GenerateKey(CharType);
		}
	}

	static void Swap(int& A, int& B) {
		int Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(double& A, double& B) {
		double Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(bool& A, bool& B) {
		bool Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(char& A, char& B) {
		char Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(string& A, string& B) {
		string Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(clsDate& A, clsDate& B) {
		clsDate::SwapDates(A, B);
	}

	static void ShuffleArray(int arr[100], int arrLength) {
		for (short i = 0; i < arrLength; i++) {
			Swap(arr[RandomNumber(1, arrLength) - 1], arr[RandomNumber(1, arrLength) - 1]);
		}
	}

	static void ShuffleArray(string arr[100], int arrLength) {
		for (short i = 0; i < arrLength; i++) {
			Swap(arr[RandomNumber(1, arrLength) - 1], arr[RandomNumber(1, arrLength) - 1]);
		}
	}

	static string Tabs(short NumberOfTabs) {
		string T = "";
		for (short i = 0; i < NumberOfTabs; i++) {
			T += "\t";
			cout << T;
		}
		return T;
	}

	static string EncryptText(string Text, short EncryptionKey) {
		for (int i = 0; i < Text.length(); i++) {
			Text[i] = char((int)Text[i] + EncryptionKey);
		}
		return Text;
	}

	static string DecryptText(string Text, short EncryptionKey) {
		for (int i = 0; i < Text.length(); i++) {
			Text[i] = char((int)Text[i] - EncryptionKey);
		}
		return Text;
	}
};

