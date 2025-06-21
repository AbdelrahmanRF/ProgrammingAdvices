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

bool IsFirstDayInMonth(sDate Date) {
    return Date.Day == 1;
}

bool IsFirstMonthInYear(short Month) {
    return (Month == 1);
}

sDate DecreaseDayFromDate(sDate Date)
{
    if (IsFirstDayInMonth(Date)) {
        if (IsFirstMonthInYear(Date.Month)) {
            Date.Month = 12;
            Date.Day = 31;
            Date.Year--;
        }
        else {
            Date.Month--;
            Date.Day = NumberOfDaysInAMonth(Date.Month, Date.Year);
        }
    }
    else {
        Date.Day--;
    }

    return Date;
}

sDate DecreaseDateByXDays(short Days, sDate Date) {
    for (short i = 1; i <= Days; i++) {
        Date = DecreaseDayFromDate(Date);
    }
    return Date;
}

sDate DecreaseDateByOneWeek(sDate Date)
{
    for (short i = 1; i <= 7; i++) {
        Date = DecreaseDayFromDate(Date);
    }
    return Date;
}

sDate DecreaseDateByXWeeks(short Weeks, sDate Date) {
    for (short i = 1; i <= Weeks; i++) {
        Date = DecreaseDateByOneWeek(Date);
    }
    return Date;
}

sDate DecreaseDateByOneMonth(sDate Date)
{
    if (IsFirstMonthInYear(Date.Month)) {
        Date.Month = 12;
        Date.Year--;
    }
    else {
        Date.Month--;
    }
    short LastValidDayInMonth = NumberOfDaysInAMonth(Date.Month, Date.Year);
    Date.Day = Date.Day > LastValidDayInMonth ? LastValidDayInMonth : Date.Day;

    return Date;
}

short AdjustDayToMonth(short OriginalDay, short Month, short Year) {
    short LastDayInMonth = NumberOfDaysInAMonth(Month, Year);
    return (OriginalDay > LastDayInMonth) ? LastDayInMonth : OriginalDay;
}

sDate DecreaseDateByXMonths(short Months, sDate Date) {
    short OriginalDay = Date.Day;
    for (short i = 1; i <= Months; i++) {
        Date = DecreaseDateByOneMonth(Date);
    }

    Date.Day = AdjustDayToMonth(OriginalDay, Date.Month, Date.Year);
    return Date;
}

sDate DecreaseDateByOneYear(sDate Date)
{
    short OriginalDay = Date.Day;

    Date.Year--;
    Date.Day = AdjustDayToMonth(OriginalDay, Date.Month, Date.Year);

    return Date;
}

sDate DecreaseDateByXYears(short Years, sDate Date) {
    for (short i = 1; i <= Years; i++) {
        Date = DecreaseDateByOneYear(Date);
    }
    return Date;
}

sDate DecreaseDateByXYearsFaster(short Years, sDate Date) {
    short OriginalDay = Date.Day;

    Date.Year -= Years;
    Date.Day = Date.Day = AdjustDayToMonth(OriginalDay, Date.Month, Date.Year);

    return Date;
}

sDate DecreaseDateByOneDecade(sDate Date) {
    return DecreaseDateByXYearsFaster(10, Date);
}

sDate DecreaseDateByXDecades(short Decades, sDate Date) {
    for (short i = 1; i <= Decades; i++) {
        Date = DecreaseDateByOneDecade(Date);
    }
    return Date;
}

sDate DecreaseDateByXDecadesFaster(short Decades, sDate Date)
{
    return DecreaseDateByXYearsFaster(Decades * 10, Date);
}

sDate DecreaseDateByOneCentury(sDate Date) {
    return DecreaseDateByXYearsFaster(100 * 1, Date);
}

sDate DecreaseDateByOneMillennium(sDate Date) {
    return DecreaseDateByXYearsFaster(1000 * 1, Date);
}

int main()
{
    sDate Date = ReadFullDate();

    cout << "\nDate after:\n";

    Date = DecreaseDayFromDate(Date);
    cout << "\n01-Subtracting one day is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXDays(10, Date);
    cout << "\n02-Subtracting 10 days is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByOneWeek(Date);
    cout << "\n03-Subtracting one week is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXWeeks(10, Date);
    cout << "\n04-Subtracting 10 weeks is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByOneMonth(Date);
    cout << "\n05-Subtracting one Month is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXMonths(5, Date);
    cout << "\n06-Subtracting 5 Months is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByOneYear(Date);
    cout << "\n07-Subtracting one Year is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXYears(10, Date);
    cout << "\n08-Subtracting 10 Years is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXYearsFaster(10, Date);
    cout << "\n09-Subtracting 10 Years (Faster) is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByOneDecade(Date);
    cout << "\n10-Subtracting one Decade is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXDecades(10, Date);
    cout << "\n11-Subtracting 10 Decades is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByXDecadesFaster(10, Date);
    cout << "\n12-Subtracting 10 Decades (Faster) is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByOneCentury(Date);
    cout << "\n13-Subtracting one Century is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = DecreaseDateByOneMillennium(Date);
    cout << "\n14-Subtracting one Millennium is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    return 0;
}
