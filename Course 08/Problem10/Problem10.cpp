#include <iostream>
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

short NumberOfDaysInAMonth(short Year, short Month)
{
    if (Month < 0 || Month > 12) {
        return 0;
    }
    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31  ,31, 30, 31, 30,31 };

    return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];
}

short DaysFromTheBeginningOfYear(short Year, short Month, short Day) {
    short TotalDays = 0;

    for (int i = 1; i < Month; i++) {
        TotalDays += NumberOfDaysInAMonth(Year, i);
    }

    TotalDays += Day;

    return TotalDays;
}

int main()
{
    short Day = ReadDay();
    short Month = ReadMonth();
    short Year = ReadYear();

    cout << "\nNumber of Days from the begining of the year is " 
        << DaysFromTheBeginningOfYear(Year, Month, Day);

    return 0;
}