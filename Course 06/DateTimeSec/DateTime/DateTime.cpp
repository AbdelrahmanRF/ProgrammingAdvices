#pragma warning(disable : 4996)

#include <ctime>
#include <iostream>
using namespace std;

int main()
{
	time_t t = time(0); // get time now

	char* dt = ctime(&t); // convert to string form
	cout << "Local date and time is : " << dt << endl;

	tm* gmtm = gmtime(&t); // converting now to tm struct for UTC date/time
	dt = asctime(gmtm); // convert from struct to string
	cout << "UTC date and time is : " << dt << endl;


}
