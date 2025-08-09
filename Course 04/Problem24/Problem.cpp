#include <iostream>
#include <format>
#include <numbers>
using namespace std;


int ReadAge() {
	int Age;
	cout << "Please Enter Your Age?\n";
	cin >> Age;

	return Age;
}

bool ValidateNumberInRange(int Number, int From, int To) {
	return (Number >= From && Number <= To);
}

void PrintResult(string Message, bool isValid) {
	cout << format("\n{} {}\n", Message, isValid ? "Valid" : "Invalid");
}

int main()
{
	PrintResult("Your Age is:", ValidateNumberInRange(ReadAge(), 18, 45));
	return 0;
}
