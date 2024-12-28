#include <iostream>
#include <format>
using namespace std;

int ReadTotalSales() {
	int Total;
	cout << "Please Enter Total Amount of Sales" << endl;
	cin >> Total;
	return Total;
}

//float CalcCommission(int Total) {
//	float Commission;
//	if (Total >= 1'000'000)
//		return Total * 0.01;
//	else if (Total >= 500'000 && Total < 1'000'000)
//		return Total * 0.02;
//	else if (Total >= 100'000 && Total < 500'000)
//		return Total * 0.03;
//	else if (Total >= 50'000 && Total < 100'000)
//		return Total * 0.05;
//	else
//		return 0;
//}

float GetCommissionPercentage(float TotalSales) {
	if (TotalSales >= 1'000'000)
		return 0.01;
	else if (TotalSales >= 500'000)
		return 0.02;
	else if (TotalSales >= 100'000)
		return 0.03;
	else if (TotalSales >= 50'000)
		return 0.05;
	else
		return 0.00;
}

float CalcTotalCommission(float TotalSales) {
	return GetCommissionPercentage(TotalSales) * TotalSales;
}
int main()
{

	float TotalSales = ReadTotalSales();

	cout << endl << "Commission Percantage = " << GetCommissionPercentage(TotalSales) << endl;
	cout << endl << "Total Commission = " << CalcTotalCommission(TotalSales) << endl;

	return 0;
}
