#include <iostream>
#include <string>
#include <iomanip>

using namespace std;

short ReadDay() {
    short Month;
    cout << "\nPlease Enter a Day? ";
    cin >> Month;

    return Month;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease Enter a Month? ";
    cin >> Month;

    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease Enter a Year? ";
    cin >> Year;

    return Year;
}

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year)
{
    if (Month < 0 || Month > 12) {
        return 0;
    }
    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31 ,31, 30, 31, 30, 31 };

    return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];
}

short DaysFromTheBeginningOfYear(short Year, short Month, short Day) {
    short TotalDays = 0;

    for (int i = 1; i < Month; i++) {
        TotalDays += NumberOfDaysInAMonth(i, Year);
    }

    TotalDays += Day;

    return TotalDays;
}

string DateFromDayOfYear(short TotalDaysElapsed, short Year) {
    short Day = 0, Month = 0, Reminder = TotalDaysElapsed;

    for (int i = 1; i < 12; i++) {
        if (Reminder - NumberOfDaysInAMonth(i, Year) < 0) break;

        Reminder -= NumberOfDaysInAMonth(i, Year);
        ++Month;
    }

    ++Month;
    Day = Reminder;

    return to_string(Day) + "/" + to_string(Month) + "/" + to_string(Year);
}

int main()
{
    short Day = ReadDay();
    short Month = ReadMonth();
    short Year = ReadYear();

    short TotalDaysElapsed = DaysFromTheBeginningOfYear(Year, Month, Day);

    cout << "\nNumber of Days from the begining of the year is "
        << TotalDaysElapsed;

    cout << "\nDate For [" << TotalDaysElapsed << "] is: " << DateFromDayOfYear(TotalDaysElapsed, Year);

    return 0;
}