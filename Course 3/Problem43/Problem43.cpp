#include <iostream>
using namespace std;

int main()
{
	int TotalSeconds;
	cout << "Please Enter The Total Seconds?\n";
	cin >> TotalSeconds;

	cout << '\n';

	const int SECONDS_IN_A_DAY = 24 * 60 * 60;
	const int SECONDS_IN_AN_HOUR = 60 * 60;
	const int SECONDS_IN_A_MINUTE = 60;

	
	int Days = floor(TotalSeconds / SECONDS_IN_A_DAY);
	int Hours = floor(TotalSeconds % SECONDS_IN_A_DAY / SECONDS_IN_AN_HOUR);
	int Minutes = floor(TotalSeconds % SECONDS_IN_A_DAY % SECONDS_IN_AN_HOUR / SECONDS_IN_A_MINUTE);
	int Seconds = floor(TotalSeconds % SECONDS_IN_A_DAY % SECONDS_IN_AN_HOUR % SECONDS_IN_A_MINUTE);

	cout << "The Time is: " << Days << ':' << Hours << ':' << Minutes << ':' << Seconds << endl;

	return 0;
}
