#pragma warning(disable : 4996)

#include <iostream>
#include <ctime>
using namespace std;

struct sDate {
    short Day;
    short Month;
    short Year;
};

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

short DaysFromTheBeginningOfYear(sDate Date) {
    short TotalDays = 0;

    for (int i = 1; i < Date.Month; i++) {
        TotalDays += NumberOfDaysInAMonth(i, Date.Year);
    }

    TotalDays += Date.Day;

    return TotalDays;
}

string GetDayName(short DayOrder) {
    string Days[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    return Days[DayOrder];
}

short DayOrder(sDate Date) {
    short A, Y, M;
    A = (14 - Date.Month) / 12;
    Y = Date.Year - A;
    M = Date.Month + 12 * A - 2;

    return (Date.Day + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
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

bool IsEndOfWeek(sDate Date) {
    return DayOrder(Date) == 6;
}

bool IsWeekEnd(sDate Date){
    short DayIndex = DayOrder(Date);
    return DayIndex == 5 || DayIndex == 6;
}

bool IsBusinessDay(sDate Date){
    return !IsWeekEnd(Date);
}

short DaysUntilTheEndOfWeek(sDate Date){
    short DayIndex = DayOrder(Date);

    return 6 - DayIndex;
}

short DaysUntilTheEndOfMonth(sDate Date){
    return NumberOfDaysInAMonth(Date.Month, Date.Year) - Date.Day + 1;
}

short DaysUntilTheEndOfYear(sDate Date){
    short TotalDaysElapsed = DaysFromTheBeginningOfYear(Date);
    return IsLeapYear ? 366 - TotalDaysElapsed : 365 - TotalDaysElapsed;
}

int main()
{
    sDate Date = GetSystemDate();
    string TodayName = GetDayName(DayOrder(Date));

    cout << "Today is " << TodayName << " , ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year << endl;

    cout << "\nIs it End of Week?\n";
    if (IsEndOfWeek(Date))
        cout << "Yes it is Saturday, it\'s End of Week";
    else
        cout << "No Not End of Week";


    cout << "\n\nIs it Weekend?\n";
    if (IsWeekEnd(Date))
        cout << "Yes it is a Weekend";
    else
        cout << "No today is " << TodayName << ", Not a weekend.";
    
    cout << "\n\nIs it Business Day?\n";
    if (IsBusinessDay(Date))
        cout << "Yes it is a business day."; 
    else        
        cout << "No it is NOT a business day.";

    cout << "\n\nDays until end of week : " << 
        DaysUntilTheEndOfWeek(Date) << " Day(s).";
 
    cout << "\nDays until end of month : " << 
        DaysUntilTheEndOfMonth(Date) << " Day(s).";
 
    cout << "\nDays until end of year : " << 
        DaysUntilTheEndOfYear(Date) << " Day(s).";

    return 0;
}
