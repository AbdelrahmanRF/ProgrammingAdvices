#include <iostream>
#include <format>
using namespace std;

enum enDayOfTheWeek {
	Sunday = 1,
	Monday = 2,
	TuesDay = 3,
	Wednesday = 4,
	Thursday = 5,
	Friday = 6,
	Saturday = 7,
};

int ReadNumberInRange(string Message, int From, int To) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num < From || Num > To);

	return Num;
}

//enDayOfTheWeek CheckDayOfTheWeek(int DayNum) {
//	return (enDayOfTheWeek)DayNum;
//}
enDayOfTheWeek ReadDayOfTheWeek() {
	return (enDayOfTheWeek)ReadNumberInRange("Please Enter Day of week (1 - 7)", 1, 7);
}

string PrintDayOfTheWeek(enDayOfTheWeek DayNum) {
	switch (DayNum)
	{
	case Sunday:
		return "Sunday";
	case Monday:
		return "Monday";

	case TuesDay:
		return "TuesDay";

	case Wednesday:
		return "Wednesday";

	case Thursday:
		return "Thursday";

	case Friday:
		return "Friday";

	case Saturday:
		return "Saturday";
	default:
		return "Wrong Day";
	}
}

int main()
{
	//cout << format("\nIt\'s {}\n", PrintDayOfTheWeek(CheckDayOfTheWeek(ReadNumberInRange("Please Enter Day of week (1 - 7)", 1, 7))));
	cout << format("\nIt\'s {}\n", PrintDayOfTheWeek(ReadDayOfTheWeek()));
}
