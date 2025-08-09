#include <iostream>
using namespace std;

int main()
{
	float TotalBill, CashPaid;
	cout << "Please Enter The Total Bill?\n";
	cin >> TotalBill;
	cout << "Please Enter The Cash Paid?\n";
	cin >> CashPaid;

	cout << '\n';

	cout << "The Reminder is: " << CashPaid - TotalBill << endl;

	return 0;
}
