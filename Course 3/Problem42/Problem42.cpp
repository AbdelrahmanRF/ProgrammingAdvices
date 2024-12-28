#include <iostream>
using namespace std;

int main()
{
	short Days, Hours, Minutes, Seconds;
	int TotalSeconds;
	cout << "Please Enter The Days?\n";
	cin >> Days;
	cout << "Please Enter The Hours?\n";
	cin >> Hours;
	cout << "Please Enter The Minutes?\n";
	cin >> Minutes;
	cout << "Please Enter The Seconds?\n";
	cin >> Seconds;

	cout << '\n';

	TotalSeconds = Days * 86400 + Hours * 3600 + Minutes * 60 + Seconds;

	cout << "The Total Seconds is: " << TotalSeconds << endl;

	return 0;
}
