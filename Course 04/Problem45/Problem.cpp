#include <iostream>
#include <format>
using namespace std;

enum enMonthOfTheYear {
	January = 1,
	February = 2,
	March = 3,
	April = 4,
	May = 5,
	June = 6,
	July = 7,
	August = 8,
	September = 9,
	October = 10,
	November = 11,
	December = 12
};

int ReadNumberInRange(string Message, int From, int To) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num < From || Num > To);

	return Num;
}

enMonthOfTheYear ReadMonthOfTheYear() {
	return (enMonthOfTheYear)ReadNumberInRange("Please Enter Day of week (1 - 12)", 1, 12);
}

string PrintMonthOfTheYear(enMonthOfTheYear MonthNum) {
	switch (MonthNum) {
	case January:
		return "January";
	case February:
		return "February";
	case March:
		return "March";
	case April:
		return "April";
	case May:
		return "May";
	case June:
		return "June";
	case July:
		return "July";
	case August:
		return "August";
	case September:
		return "September";
	case October:
		return "October";
	case November:
		return "November";
	case December:
		return "December";
	default:
		return "Invalid Month";
	}
}

int main()
{
	cout << format("\nIt\'s {}\n", PrintMonthOfTheYear(ReadMonthOfTheYear()));
}
