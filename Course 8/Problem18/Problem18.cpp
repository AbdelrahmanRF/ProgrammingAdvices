#pragma warning(disable : 4996)

#include <iostream>
#include <ctime>
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

    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();

    return Date;
}

bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
    if (Date1.Year != Date2.Year)
        return Date1.Year < Date2.Year;

    if (Date1.Month != Date2.Month)
        return Date1.Month < Date2.Month;

    return Date1.Day < Date2.Day;
}

bool IsLastDayInMonth(sDate Date) {
    return Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year);
}

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

int CalculateDateDifference(sDate Date1, sDate Date2, bool IncludeEndDay = false) {
    int TotalDaysDifference = 0;

    while (IsDate1BeforeDate2(Date1, Date2)) {
        TotalDaysDifference++;
        Date1 = IncreaseDayToDate(Date1);
    }

    return IncludeEndDay ? ++TotalDaysDifference : TotalDaysDifference;
}

sDate GetSystemDate() {
    sDate SystemDate;

    time_t t = time(0);
    tm* now = localtime(&t);

    SystemDate.Year = now->tm_year + 1900;
    SystemDate.Month = now->tm_mon + 1;
    SystemDate.Day = now->tm_mday;

    return SystemDate;
}

int main()
{
    cout << "Please Enter Your Date Of Birth:\n";
    sDate Date = ReadFullDate();
    sDate SystemDate = GetSystemDate();

    cout << "\nYour Age is: " << CalculateDateDifference(Date, SystemDate, true) << " Day(s)";

    return 0;
}
