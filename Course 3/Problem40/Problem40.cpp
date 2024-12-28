#include <iostream>
using namespace std;

int main()
{
	float BillValue;
	float TotalBill;
	cout << "Please Enter The Total Bill Value?\n";
	cin >> BillValue;

	cout << '\n';

	TotalBill = BillValue * 1.1 * 1.16;

	cout << "The Total Bill is: " << TotalBill<< endl;

	return 0;
}
