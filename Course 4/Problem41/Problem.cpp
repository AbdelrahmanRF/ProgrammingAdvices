#include <iostream>
#include <format>
using namespace std;


float ReadPositiveNumber(string Message) {
	float Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);

	return Num;
}

//float CalculateTotalWeeks(float NumberOfHoures) {
//	return NumberOfHoures / 168;
//}

float HoursToDays(float NumberOfHoures) {
	return NumberOfHoures / 24;
}
float HoursToWeeks(float NumberOfHoures) {
	return NumberOfHoures / 168;
}
float DaysToWeeks(float NumberOfDays) {
	return NumberOfDays / 7;
}


int main()
{
	float NumberOfHoures = ReadPositiveNumber("Enter Total Hours?");
	float NumberOfDays = HoursToDays(NumberOfHoures);
	float NumberOfWeeks = DaysToWeeks(NumberOfDays);

	cout << endl;
	cout << format("Total Hours = {}", NumberOfHoures) << endl;
	cout << format("Total Days = {}", NumberOfDays) << endl;
	cout << format("Total Weeks = {}", NumberOfWeeks) << endl;


	return 0;
}
