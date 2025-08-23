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

	static string EncryptText(string Text, short EncryptionKey = 2) {
		for (char & C : Text)
			C += EncryptionKey;

		return Text;
	}

	static string DecryptText(string Text, short EncryptionKey = 2) {
		for (char& C : Text)
			C -= EncryptionKey;

		return Text;
	}

	static string ConvertNumberToText(int Number) {
		if (Number == 0) {
			return "";
		}

		if (Number >= 1 && Number <= 19) {
			string arr[] = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" , "Ten",
				 "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

			return arr[Number] + " ";
		}
		if (Number >= 20 && Number <= 99) {
			string arr[] = { "", "", "Twenty", "Thirty", "Forty","Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

			return arr[Number / 10] + " " + ConvertNumberToText(Number % 10);
		}
		if (Number >= 100 && Number <= 199) {
			return "One Handred " + ConvertNumberToText(Number % 100);
		}
		if (Number >= 200 && Number <= 999) {
			return ConvertNumberToText(Number / 100) + "Handreds " + ConvertNumberToText(Number % 100);
		}
		if (Number >= 1000 && Number <= 1999) {
			return "One Thousands " + ConvertNumberToText(Number % 1000);
		}
		if (Number >= 2000 && Number <= 999999) {
			return ConvertNumberToText(Number / 1000) + "Thousands " + ConvertNumberToText(Number % 1000);
		}
		if (Number >= 1000000 && Number <= 1999999) {
			return "One Million " + ConvertNumberToText(Number % 1000000);
		}
		if (Number >= 2000000 && Number <= 999999999) {
			return ConvertNumberToText(Number / 1000000) + "Millions " + ConvertNumberToText(Number % 1000000);
		}
		if (Number >= 1000000000 && Number <= 1999999999) {
			return "One Billion " + ConvertNumberToText(Number % 1000000000);
		}
		else {
			return ConvertNumberToText(Number / 1000000000) + "Billions " + ConvertNumberToText(Number % 1000000000);
		}
	}
};

