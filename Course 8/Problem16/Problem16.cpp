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

sDate ReadFullDate() {
    sDate Date;

    Date.Year = ReadYear();
    while (Date.Year < 0) {
        cout << "\nThe Year Entered is Invalid, Try Again:\n";
        cin >> Date.Year;
    }

    Date.Month = ReadMonth();
    while (Date.Month < 0 || Date.Month > 12) {
        cout << "\nThe Month Entered is Invalid, Try Again:\n";
        cin >> Date.Month;
    }

    Date.Day = ReadDay();
    while (Date.Day > NumberOfDaysInAMonth(Date.Month, Date.Year) || Date.Day < 0) {
        cout << "\nThe Day Entered is Invalid, Try Again:\n";
        cin >> Date.Day;
    }

    return Date;
}

bool IsLastDayInMonth(sDate Date) {
    return Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year);
}

//sDate IncreaseDayToDate(sDate Date) 
//{
//    if (IsLastDayInMonth(Date)) {
//        Date.Day = 1;
//        Date.Month++;
//
//        if (Date.Month == 13) {
//            Date.Month = 1;
//            Date.Year++;
//        }
//    }
//    else {
//        Date.Day++;
//    }
//
//    return Date;
//}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

sDate IncreaseDayToDate(sDate Date)
{
    if (IsLastDayInMonth(Date)) {
        if (IsLastMonthInYear(Date.Month)) {
            Date.Month = 1;
            Date.Day = 1;
            Date.Year++;
        }
        else {
            Date.Day = 1;
            Date.Month++;
        }
    }
    else {
        Date.Day++;
    }

    return Date;
}

int main()
{
    sDate Date = ReadFullDate();

    Date = IncreaseDayToDate(Date);

    cout << "\nDate after adding one day is: " ;
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    return 0;
}
