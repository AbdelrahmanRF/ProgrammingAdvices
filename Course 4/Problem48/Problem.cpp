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

float CalculateMonthlyPayment(float LoanAmount, float MonthsNum) {
	return (float)LoanAmount / MonthsNum;
}


float main()
{
	float LoanAmount = ReadPositiveNumber("Please Enter Loan Amount:");
	float MonthsNum = ReadPositiveNumber("Please Enter Length Of Loan Period in Months:");

	cout << format("\nTotal Monthly installment = {}", CalculateMonthlyPayment(LoanAmount, MonthsNum)) << endl;

	return 0;
}
