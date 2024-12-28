#include <iostream>
using namespace std;

int main()
{
	float LoanAmount, MonthlyPayment;
	cout << "Please Enter The Loan Amount?\n";
	cin >> LoanAmount;
	cout << "Please Enter The Monthly Payment?\n";
	cin >> MonthlyPayment;

	cout << '\n';


	cout << "The Total Months: " << floor(LoanAmount / MonthlyPayment) << endl;

	return 0;
}
