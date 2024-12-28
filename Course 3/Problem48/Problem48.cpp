#include <iostream>
using namespace std;

int main()
{
	double LoanAmount;
	short Months;
	cout << "Please Enter The Loan Amount?\n";
	cin >> LoanAmount;
	cout << "Please Enter How Many Months?\n";
	cin >> Months;

	cout << '\n';


	cout << "The Monthly Payment is: " << floor(LoanAmount / Months) << endl;

	return 0;
}
