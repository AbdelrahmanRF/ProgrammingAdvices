#include <iostream>
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

int ReverseNumber(int Num) {
	int ReversedNumber = 0;

	while (Num != 0) {
		ReversedNumber = ReversedNumber * 10 + Num % 10;
		Num /= 10;
	}
	return ReversedNumber;
}

bool CheckPalindrome(int Num) {
	return Num == ReverseNumber(Num);
}

int main()
{
	int Num = ReadPositiveNumber("Please Enter a Number:");
	cout << format("{} is {}", Num, CheckPalindrome(Num) ? "a Palindrome Number" : "not a Palindrome Number");
}
