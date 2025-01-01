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

float CalculateTotalBill(float BillValue) {
	return BillValue * 1.16 * 1.1;
}


int main()
{
	float BillValue = ReadPositiveNumber("Enter The Bill Value?");

	cout << format("Total Bill = {}", CalculateTotalBill(BillValue)) << endl;


	return 0;
}
