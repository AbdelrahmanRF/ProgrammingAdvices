#include <iostream>
#include <format>
#include <numbers>
using namespace std;


int ReadAge() {
	int Age;
	cout << "Enter Your Age?\n";
	cin >> Age;

	return Age;
}

void PrintResult(string Message, bool isValid) {
	cout << format("\n{} {}\n\n", Message, isValid ? "Valid" : "Invalid");
}

void ValidateNumberInRange(int Number, int From, int To) {
	bool isValid = true;
	while (isValid) {
		if (Number >= From && Number <= To) {
			PrintResult("Your Age is:", true);
			isValid = false;
		}
		else {
			PrintResult("Your Age is:", false);
			Number = ReadAge();
		}
	}
}



int main()
{
	ValidateNumberInRange(ReadAge(), 18, 45);
	return 0;
}
