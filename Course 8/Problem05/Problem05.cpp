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
    if (Month == 2) {
        return IsLeapYear(Year) ? 29 : 28;
    }
    short arr30Days[4] = { 4, 6, 9, 11 };
    for (short i = 0; i < 4; i++) {
        if (arr30Days[i] == Month)
            return 30;
    }
    return 31;

    //if (Month == 4 || Month == 6 || Month == 9 || Month == 11) {
    //    return 30;
    //}
    //return 31;
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