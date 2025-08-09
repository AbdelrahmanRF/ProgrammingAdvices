#include <iostream>
#include <format>
using namespace std;


struct strPiggyBankContent {
	int Pennies, Nickels, Dimes, Quarters, Dollars;
};

strPiggyBankContent ReadPiggyBankContent() {
	strPiggyBankContent PiggyBankContent;
	cout << "Please Enter Your Pennies?\n";
	cin >> PiggyBankContent.Pennies;
	cout << "Please Enter Your Nickels?\n";
	cin >> PiggyBankContent.Nickels;
	cout << "Please Enter Your Dimes?\n";
	cin >> PiggyBankContent.Dimes;
	cout << "Please Enter Your Quarters?\n";
	cin >> PiggyBankContent.Quarters;
	cout << "Please Enter Your Number?\n";
	cin >> PiggyBankContent.Dollars;
	cout << '\n';

	return PiggyBankContent;
}

int CalcTotalPennies(strPiggyBankContent PiggyBankContent) {
	return PiggyBankContent.Pennies + PiggyBankContent.Nickels * 5 + PiggyBankContent.Dimes * 10 + PiggyBankContent.Quarters * 25 + PiggyBankContent.Dollars * 100;

}
int main()
{
	int TotalPennies = CalcTotalPennies(ReadPiggyBankContent());

	cout << "Your Total Pennies is: " << TotalPennies << endl;
	cout << "Your Total Dollars is: " << (float)TotalPennies / 100 << endl;

	return 0;
}
