#include <iostream>
using namespace std;

int main()
{
	int Nickels, Dimes, Quarters;
	float Dollars, Pennies;
	cout << "Please Enter Your Pennies?\n";
	cin >> Pennies;
	cout << "Please Enter Your Nickels?\n";
	cin >> Nickels;
	cout << "Please Enter Your Dimes?\n";
	cin >> Dimes;
	cout << "Please Enter Your Quarters?\n";
	cin >> Quarters;
	cout << "Please Enter Your Number?\n";
	cin >> Dollars;
	cout << '\n';

	Pennies = Pennies + Nickels * 5 + Dimes * 10 + Quarters * 25 + Dollars * 100;
	cout << "Your Total Pennies is: " << Pennies << endl;
	cout << "Your Total Dollars is: " << Pennies / 100 << endl;

	return 0;
}
