#include <iostream>
using namespace std;

enum enWeekDay {
	Sun = 1,
	Mon = 2,
	Tue = 3,
	Wed = 4,
	Thu = 5,
	Fri = 6,
	Sat = 7,
};

void ShowWeekDayMenu() {
	cout << "*************************************\n";
	cout << "(1) Sunday\n";
	cout << "(2) Monday\n";
	cout << "(3) Tuesday\n";
	cout << "(4) Wednesday\n";
	cout << "(5) Thursday\n";
	cout << "(6) Friday\n";
	cout << "(7) Saturday\n";
	cout << "*************************************\n";
	cout << "Please Chose Week day?\n";

}

enWeekDay ReadWeekDay() {
	short d;
	enWeekDay WeekDay;
	cin >> d;

	return (enWeekDay)d;

}

string GetWeekDayName(enWeekDay WeekDay) {
	switch (WeekDay)
	{
	case Sun:
		return "Sunday";
		break;
	case Mon:
		return "Monday";
		break;
	case Tue:
		return "Tuesday";
		break;
	case Wed:
		return "Wednesday";
		break;
	case Thu:
		return "Thursday";
		break;
	case Fri:
		return "Friday";
		break;
	case Sat:
		return "Satrday";
		break;
	default:
		return "Not Week Day";
		break;
	}
}

int main()
{

	ShowWeekDayMenu();

	string WeekDay = GetWeekDayName(ReadWeekDay());

	cout << "Today is: " << WeekDay << endl;

	return 0;
}
