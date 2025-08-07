#pragma once

#include <iostream>  
#include <vector>  
using namespace std;


class clsString
{
	string _Value;

public:
	clsString() {
		_Value = "";
	}

	clsString(string Value) {
		_Value = Value;
	}

	void SetValue(string Value) {
		_Value = Value;
	}

	string GetValue() 
	{
		return _Value;
	}

	__declspec(property(get = GetValue, put = SetValue)) string Value;

	static short Length(string S1)
	{
		return S1.length();
	};

	short Length()
	{
		return _Value.length();
	};

	//static short CountWords(string S1) 
	//{
	//	short Counter = 0;
	//	string Separator = " ";
	//	string Word = "";
	//	short Pos = 0;

	//	while ((Pos = S1.find(Separator)) != string::npos) {
	//		Word = S1.substr(0, Pos);

	//		if (Word != "") {
	//			++Counter;
	//		}

	//		S1.erase(0, Pos + Separator.length());
	//	}

	//	if (S1 != "") {
	//		++Counter;
	//	}

	//	return Counter;
	//}

	//short CountWords() 
	//{
	//	return CountWords(_Value);
	//}

	static void PrintFirstLetterOfEachWord(string S1) {
		bool isFirstLetter = true;     
		
		cout << "First letters of this string: \n";

		for (short i = 0; i < S1.length(); i++) {
			if (S1[i] != ' ' && isFirstLetter) {
				cout << S1[i] << endl;
			}
			isFirstLetter = S1[i] == ' ' ? true : false;
		}
	}

	void PrintFirstLetterOfEachWord() {
		PrintFirstLetterOfEachWord(_Value);
	}

	static string UpperFirstLetterOfEachWord(string S1) {
		bool isFirstLetter = true;

		for (short i = 0; i < S1.length(); i++) {
			if (S1[i] != ' ' && isFirstLetter) {
				S1[i] = toupper(S1[i]);
			}
			isFirstLetter = S1[i] == ' ' ? true : false;
		}

		return S1;
	}

	void UpperFirstLetterOfEachWord() {
		_Value = UpperFirstLetterOfEachWord(_Value);
	}

	static string LowerFirstLetterOfEachWord(string S1) {
		bool isFirstLetter = true;

		for (short i = 0; i < S1.length(); i++) {
			if (S1[i] != ' ' && isFirstLetter) {
				S1[i] = tolower(S1[i]);
			}
			isFirstLetter = S1[i] == ' ' ? true : false;
		}

		return S1;
	}

	void LowerFirstLetterOfEachWord() {
		_Value = LowerFirstLetterOfEachWord(_Value);
	}

	static string UpperAllString(string S1) {
		for (short i = 0; i < S1.length(); i++) {
			S1[i] = toupper(S1[i]);
		}

		return S1;
	}

	void UpperAllString() {
		_Value = UpperAllString(_Value);
	}

	static string LowerAllString(string S1) {
		for (short i = 0; i < S1.length(); i++) {
			S1[i] = tolower(S1[i]);
		}

		return S1;
	}

	void LowerAllString() {
		_Value = LowerAllString(_Value);
	}

	static char  InvertLetterCase(char char1) {
		return isupper(char1) ? tolower(char1) : toupper(char1);
	}

	static string InvertAllStringLettersCase(string S1) {
		for (short i = 0; i < S1.length(); i++) {
			S1[i] = InvertLetterCase(S1[i]);
		}

		return S1;
	}

	void InvertAllStringLettersCase() {
		_Value = InvertAllStringLettersCase(_Value);
	}


	enum enWhatToCount { SmallLetters = 0, CapitalLetters = 1, All = 3 };

	static short CountLetters(string S1, enWhatToCount WhatToCount = enWhatToCount::All) 
	{ 
		if (WhatToCount == enWhatToCount::All) return S1.length();

		short Counter = 0;

		if (WhatToCount == enWhatToCount::CapitalLetters) {
			for (short i = 0; i < S1.length(); i++) {
				if (isupper(S1[i]))
					++Counter;
			}

			return Counter;
		}

		if (WhatToCount == enWhatToCount::SmallLetters) {
			for (short i = 0; i < S1.length(); i++) {
				if (islower(S1[i]))
					++Counter;
			}

			return Counter;
		}

		return Counter;
	}

	static short CountLetter(string S1, char Letter, bool MatchCase = true) {
		if (MatchCase == false) {
			S1 = LowerAllString(S1);
			Letter = tolower(Letter);
		}

		short Counter = 0;

		for (short i = 0; i < S1.length(); i++) {
			if (S1[i] == Letter)
				++Counter;
		}

		return Counter;

	}

	static bool IsVowel(char Ch1) {
		Ch1 = tolower(Ch1);

		return (Ch1 == 'a' || Ch1 == 'e' || Ch1 == 'i' || Ch1 == 'o' || Ch1 == 'u');
	}

	static short CountVowels(string S1) {
		short Counter = 0;

		for (short i = 0; i < S1.length(); i++) {
			if (IsVowel(S1[i]))
				++Counter;
		}

		return Counter;
	}

	short CountVowels() {
		return CountVowels(_Value);
	}

	static vector<string> Split(string S1, string Separator) {
		vector<string> Words;
		string Word = "";
		short Pos = 0;


		while ((Pos = S1.find(Separator)) != string::npos) {
			Word = S1.substr(0, Pos);

			if (Word != "") {
				Words.push_back(Word);
			}

			S1.erase(0, Pos + Separator.length());
		}

		if (S1 != "") {
			Words.push_back(S1);
		}

		return Words;
	}

	vector<string> Split(string Separator)
	{
		return Split(_Value, Separator);
	}

	static short CountWords(string S1) {
		return Split(S1, " ").size();
	}

	short CountWords()
	{
		return CountWords(_Value);
	}

	static string TrimLeft(string S1) 
	{
		for (short i = 0; i < S1.length(); i++) {
			if (S1[i] != ' ')
				return S1.substr(i);
		}
		
		return "";
	}

	void TrimLeft() {
		_Value = TrimLeft(_Value);
	}

	static string TrimRight(string S1) {
		for (short i = S1.length() - 1; i >= 0; i--) {
			if (S1[i] != ' ')
				return S1.substr(0, i + 1);
		}

		return "";
	}

	void TrimRight() {
		_Value = TrimRight(_Value);
	}

	static string Trim(string S1) {
		return TrimRight(TrimLeft(S1));
	}

	void Trim() {
		_Value = Trim(_Value);
	}

	static string Join(vector<string> Words, string Separator) {
		string JoinedStr = "";

		for (string& Word : Words) {
			JoinedStr += Word + Separator;
		}

		return JoinedStr.substr(0, JoinedStr.length() - Separator.length());
	}

	static string Join(string Words[], short Length, string Separator) {
		string JoinedStr = "";

		for (short i = 0; i < Length; i++) {
			JoinedStr += Words[i] + Separator;
		}

		return JoinedStr.substr(0, JoinedStr.length() - Separator.length());
	}

	static string ReverseWordsInString(string S1) {
		vector<string> Words = Split(S1, " ");
		string rStr = "";

		vector<string>::iterator iter = Words.end();

		while (iter != Words.begin()) {
			--iter;
			rStr += *iter + " ";
		}

		return rStr.substr(0, rStr.length() - 1);
	}

	void ReverseWordsInString()
	{
		_Value = ReverseWordsInString(_Value);
	}

	static string ReplaceWord(string S1, string StringToReplace, string ReplaceTo, bool MatchCase = true) {
		vector<string> Words = Split(S1, " ");

		for (string& Word : Words) {
			if (MatchCase) {
				if (Word == StringToReplace)
					Word = ReplaceTo;
			}
			else {
				if (LowerAllString(Word) == LowerAllString(StringToReplace))
					Word = ReplaceTo;
			}
		}

		return Join(Words, " ");
	}

	void ReplaceWord(string StringToReplace, string ReplaceTo, bool MatchCase = true)
	{
		_Value = ReplaceWord(_Value, StringToReplace, ReplaceTo, MatchCase);
	}

	static string RemovePunctuations(string S1) {
		string S2 = "";

		for (short i = 0; i < S1.length(); i++) {
			if (!ispunct(S1[i]))
				S2 += S1[i];
		}

		return S2;
	}

	void RemovePunctuations()
	{
		_Value = RemovePunctuations(_Value);
	}
};

