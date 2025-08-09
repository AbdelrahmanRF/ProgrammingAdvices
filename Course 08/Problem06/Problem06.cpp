#include <iostream>
using namespace std;

short ReadYear() {
    short Year;
    cout << "Please Enter a Year to check? ";
    cin >> Year;

    return Year;
}

short ReadMonth() {
    short Month;
    cout << "Please Enter a Month to check? ";
    cin >> Month;

    return Month;
}

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
}


short NumberOfDaysInAMonth(short Year, short Month)
{
    if (Month < 0 || Month > 12) {
        return 0;
    }
    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31  ,31, 30, 31, 30,31 };

    return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];

    //return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) :
    //    (Month == 4 || Month == 6 || Month == 9 || Month == 11) ? 30 : 31;
}

short NumberOfHoursInAMonth(short Year, short Month)
{
    return NumberOfDaysInAMonth(Year, Month) * 24;
}

int NumberOfMinutesInAMonth(short Year, short Month)
{
    return NumberOfHoursInAMonth(Year, Month) * 60;
}

int NumberOfSecondsInAMonth(short Year, short Month)
{
    return NumberOfMinutesInAMonth(Year, Month) * 60;
}

int main()
{
    short Year = ReadYear();
    short Month = ReadMonth();

    cout << "Number of Days in Month    [" << Month << "] is " << NumberOfDaysInAMonth(Year, Month) << endl;
    cout << "Number of Hours in Month   [" << Month << "] is " << NumberOfHoursInAMonth(Year, Month) << endl;
    cout << "Number of Minutes in Month [" << Month << "] is " << NumberOfMinutesInAMonth(Year, Month) << endl;
    cout << "Number of Seconds in Month [" << Month << "] is " << NumberOfSecondsInAMonth(Year, Month) << endl;

    return 0;
}