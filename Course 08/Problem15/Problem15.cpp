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

short ReadDaysToAdd() {
    short DaysToAdd;
    cout << "\nHow Many Days to Add? ";
    cin >> DaysToAdd;

    return DaysToAdd;
}

sDate ReadFullDate() {
    sDate Date;

    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();

    return Date;
}

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
}

//bool IsLastDayInMonth(sDate Date) {
//    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31 ,31, 30, 31, 30, 31 };
//
//    return Date.Month == 2 ? (Date.Day == (IsLeapYear(Date.Year) ? 29 : 28) ? true : false)
//        : (Date.Day == MonthDays[Date.Month - 1]);
//}

short NumberOfDaysInAMonth(short Month, short Year)
{
    if (Month < 0 || Month > 12) {
        return 0;
    }
    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31 ,31, 30, 31, 30, 31 };

    return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year);
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

int main()
{
    sDate Date = ReadFullDate();

    if (IsLastDayInMonth(Date)) {
        cout << "\nYes, Day is Last Day in Month.\n";
    }
    else {
        cout << "\nNo, Day is Not Last Day in Month.\n";
    }

    if (IsLastMonthInYear(Date.Month)) {
        cout << "\nYes, Month is Last Month in Year.\n";
    }
    else {
        cout << "\nNo, Month is Not Last Month in Year.\n";
    }

    return 0;
}
