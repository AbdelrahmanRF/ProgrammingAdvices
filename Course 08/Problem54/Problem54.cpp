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

sDate ReadFullDate() {
    sDate Date;

    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();

    return Date;
}

short DayOrder(sDate Date) {
    short A, Y, M;
    A = (14 - Date.Month) / 12;
    Y = Date.Year - A;
    M = Date.Month + 12 * A - 2;

    return (Date.Day + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
}

string GetDayName(short DayOrder) {
    string Days[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    return Days[DayOrder];
}

bool IsWeekEnd(sDate Date) {
    short DayIndex = DayOrder(Date);
    return DayIndex == 5 || DayIndex == 6;
}

bool IsBusinessDay(sDate Date) {
    return !IsWeekEnd(Date);
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

short CalculateVacationDays(sDate Date1, sDate Date2) {
    short TotalDays = 0;

    while (IsDate1BeforeDate2(Date1, Date2)) {
        if (IsBusinessDay(Date1))
            ++TotalDays;
        
        Date1 = IncreaseDayToDate(Date1);
    }

    return TotalDays;
}

int main()
{
    cout << "Vacation Starts:\n";
    sDate vStart = ReadFullDate();

    cout << "\nVacation Ends:\n";
    sDate vEnd = ReadFullDate();

    cout << "\nVacation From: " << GetDayName(DayOrder(vStart)) << " , ";
    cout << vStart.Day << "/" << vStart.Month << "/" << vStart.Year << endl;

    cout << "Vacation To: " << GetDayName(DayOrder(vEnd)) << " , ";
    cout << vEnd.Day << "/" << vEnd.Month << "/" << vEnd.Year << endl;

    cout << "Actual Vacation Days are: " << CalculateVacationDays(vStart, vEnd);

    return 0;
}
