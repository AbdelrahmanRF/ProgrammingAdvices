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

float CalculateReminder(float TotalBill, float TotalPaid) {
	return TotalPaid - TotalBill;
}


int main()
{
	float TotalBill = ReadPositiveNumber("Enter The Total Bill?");
	float TotalPaid = ReadPositiveNumber("Enter The Total Paid?");

	cout << format("Total Bill = {}", TotalBill) << endl;
	cout << format("Total Paid = {}", TotalPaid) << endl;

	cout << "************************************\n";
	cout << format("Reminder = {}", CalculateReminder(TotalBill, TotalPaid));


	return 0;
}
