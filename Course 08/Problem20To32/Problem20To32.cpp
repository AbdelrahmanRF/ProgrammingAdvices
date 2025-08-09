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

sDate IncreaseDateByXDays(short Days, sDate Date) {
    for (short i = 1; i <= Days; i++) {
        Date = IncreaseDayToDate(Date);
    }
    return Date;
}

sDate IncreaseDateByOneWeek(sDate Date)
{
    //return IncreaseDateByXDays(7, Date);
    for (short i = 1; i <= 7; i++) {
        Date = IncreaseDayToDate(Date);
    }
    return Date;
}

sDate IncreaseDateByXWeeks(short Weeks, sDate Date){
    for (short i = 1; i <= Weeks; i++) {
        Date = IncreaseDateByOneWeek(Date);
    }
    return Date;
}
 
sDate IncreaseDateByOneMonth(sDate Date)
{
    if (IsLastMonthInYear(Date.Month)) {
        Date.Month = 1;
        Date.Year++;
    }
    else {
        Date.Month++;
    }
    short LastValidDayInMonth = NumberOfDaysInAMonth(Date.Month, Date.Year);
    Date.Day = Date.Day > LastValidDayInMonth ? LastValidDayInMonth : Date.Day;

    return Date;
}

short AdjustDayToMonth(short OriginalDay, short Month, short Year) {
    short LastDayInMonth = NumberOfDaysInAMonth(Month, Year);
    return (OriginalDay > LastDayInMonth) ? LastDayInMonth : OriginalDay;
}

sDate IncreaseDateByXMonths(short Months, sDate Date){
    short OriginalDay = Date.Day;
    for (short i = 1; i <= Months; i++) {
        Date = IncreaseDateByOneMonth(Date);
    }

    Date.Day = AdjustDayToMonth(OriginalDay, Date.Month, Date.Year);
    return Date;
}

sDate IncreaseDateByOneYear(sDate Date)
{
    short OriginalDay = Date.Day;

    Date.Year++;
    Date.Day = AdjustDayToMonth(OriginalDay, Date.Month, Date.Year);

    return Date;
}

sDate IncreaseDateByXYears(short Years, sDate Date){
    for (short i = 1; i <= Years; i++) {
        Date = IncreaseDateByOneYear(Date);
    }
    return Date;
}

sDate IncreaseDateByXYearsFaster(short Years, sDate Date){
    short OriginalDay = Date.Day;

    Date.Year += Years;
    Date.Day = Date.Day = AdjustDayToMonth(OriginalDay, Date.Month, Date.Year);

    return Date;
}

sDate IncreaseDateByOneDecade(sDate Date){
    return IncreaseDateByXYearsFaster(10, Date);
}

sDate IncreaseDateByXDecades(short Decades, sDate Date){
    for (short i = 1; i <= Decades; i++) {
        Date = IncreaseDateByOneDecade(Date);
    }
    return Date;
}

sDate IncreaseDateByXDecadesFaster(short Decades, sDate Date)
{
    return IncreaseDateByXYearsFaster(Decades * 10, Date);
}

sDate IncreaseDateByOneCentury(sDate Date){
    return IncreaseDateByXYearsFaster(100, Date);
}

sDate IncreaseDateByOneMillennium(sDate Date){
    return IncreaseDateByXYearsFaster(1000, Date);
}

int main()
{
    sDate Date = ReadFullDate();

    Date = IncreaseDayToDate(Date);
    cout << "\n01-Date after adding one day is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXDays(10, Date);
    cout << "\n02-Date after adding 10 days is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByOneWeek(Date);
    cout << "\n03-Date after adding one week is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXWeeks(10, Date);
    cout << "\n04-Date after adding 10 weeks is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByOneMonth(Date);
    cout << "\n05-Date after adding one Month is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXMonths(5, Date);
    cout << "\n06-Date after adding 5 Months is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByOneYear(Date);
    cout << "\n07-Date after adding one Year is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXYears(10, Date);
    cout << "\n08-Date after adding 10 Years is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXYearsFaster(10, Date);
    cout << "\n09-Date after adding 10 Years (Faster) is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByOneDecade(Date);
    cout << "\n10-Date after adding one Decade is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXDecades(10, Date);
    cout << "\n11-Date after adding 10 Decades is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByXDecadesFaster(10, Date);
    cout << "\n12-Date after adding 10 Decades (Faster) is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByOneCentury(Date);
    cout << "\n13-Date after adding one Century is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    Date = IncreaseDateByOneMillennium(Date);
    cout << "\n14-Date after adding one Millennium is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    return 0;
}
