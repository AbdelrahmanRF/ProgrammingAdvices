#include <iostream>
using namespace std;

struct sDate {
    short Day;
    short Month;
    short Year;
};

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

sDate GetDateFromDayOrderInYear(short DayOrderInYear, short Year) {
    sDate Date;
    short RemainingDays = DayOrderInYear;
    short MonthDays = 0;

    Date.Year = Year;
    Date.Month = 1;

    while (true) {
        MonthDays = NumberOfDaysInAMonth(Date.Month, Year);

        if (RemainingDays > MonthDays) {
            RemainingDays -= MonthDays;
            ++Date.Month;
        }
        else {
            Date.Day = RemainingDays;
            break;
        }
    }

    return Date;
}

int main()
{
    short Day = ReadDay();
    short Month = ReadMonth();
    short Year = ReadYear();

    short DayOrderInYear = DaysFromTheBeginningOfYear(Year, Month, Day);

    cout << "\nNumber of Days from the begining of the year is "
        << DayOrderInYear;

    sDate Date;
    Date = GetDateFromDayOrderInYear(DayOrderInYear, Year);
    cout << "\nDate For [" << DayOrderInYear << "] is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    return 0;
}