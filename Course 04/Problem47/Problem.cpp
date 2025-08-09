#include <iostream>
#include <format>
using namespace std;

float ReadPositiveNumber(string Message) {
	float Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);

	return Num;
}

float CalculateMonths(float LoanAmount, float MonthlyPayment) {
	return (float)LoanAmount / MonthlyPayment;
}


float main()
{
	float LoanAmount = ReadPositiveNumber("Please Enter Loan Amount:");
	float MonthlyPayment = ReadPositiveNumber("Please Enter Monthly Payment:");

	cout << format("\nTotal Months to settle loan = {}", CalculateMonths(LoanAmount, MonthlyPayment)) << endl;

	return 0;
}
