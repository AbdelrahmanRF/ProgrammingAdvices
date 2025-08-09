#include <iostream>
using namespace std;

struct sDate {
    short Day;
    short Month;
    short Year;
};

struct sPeriod {
    sDate StartDate;
    sDate EndDate;
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

bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
    if (Date1.Year != Date2.Year)
        return Date1.Year < Date2.Year;

    if (Date1.Month != Date2.Month)
        return Date1.Month < Date2.Month;

    return Date1.Day < Date2.Day;
}

bool IsDate1EqualDate2(sDate Date1, sDate Date2)
{
    if (Date1.Year != Date2.Year)
        return false;

    if (Date1.Month != Date2.Month)
        return false;

    return Date1.Day == Date2.Day;
}

sDate ReadFullDate() {
    sDate Date;

    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();

    return Date;
}

sPeriod ReadPeriod() {
    sPeriod Period;

    cout << "\nEnter Start Date:\n";
    Period.StartDate = ReadFullDate();

    cout << "\nEnter End Date:\n";
    Period.EndDate = ReadFullDate();

    return Period;
}

enum enDateCompare { Before = -1, Equal = 0, After = 1 };

enDateCompare CompareTwoDates(sDate Date1, sDate Date2) {
    return IsDate1EqualDate2(Date1, Date2) ? enDateCompare::Equal :
        (IsDate1BeforeDate2(Date1, Date2) ? enDateCompare::Before : enDateCompare::After);
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

int CalculatePeriodLength(sPeriod Period1, bool IncludeEndDay = false) {
    return CalculateDateDifference(Period1.StartDate, Period1.EndDate, IncludeEndDay);
}
bool IsPeriodsOverlap(sPeriod Period1, sPeriod Period2) {
    if (IsDate1BeforeDate2(Period2.EndDate, Period1.StartDate) || IsDate1BeforeDate2(Period1.EndDate, Period2.StartDate)) {
        return false;
    }

    return true;
}

bool IsDateWithinPeriod(sDate DateToCheck, sPeriod Period) {
    return !(CompareTwoDates(DateToCheck, Period.StartDate) == enDateCompare::Before
        || CompareTwoDates(DateToCheck, Period.EndDate) == enDateCompare::After);
}
//int CountOverlapDays(sPeriod Period1, sPeriod Period2) {
//    if (!IsPeriodsOverlap(Period1, Period2))
//      return 0;
//
//    sDate StartDate = (CompareTwoDates(Period1.StartDate, Period2.StartDate) == enDateCompare::Equal ||
//        CompareTwoDates(Period1.StartDate, Period2.StartDate) == enDateCompare::After) ? Period1.StartDate : Period2.StartDate;
//
//    sDate EndDate = (CompareTwoDates(Period1.EndDate, Period2.EndDate) == enDateCompare::Equal ||
//        CompareTwoDates(Period1.EndDate, Period2.EndDate) == enDateCompare::Before) ? Period1.EndDate : Period2.EndDate;
//
//    return CalculateDateDifference(StartDate, EndDate, true);
//}

int CountOverlapDays(sPeriod Period1, sPeriod Period2) {
    int Period1Length = CalculatePeriodLength(Period1, true);
    int Period2Length = CalculatePeriodLength(Period2, true);
    int OverlapDays = 0;

    if (!IsPeriodsOverlap(Period1, Period2))
        return 0;

    if (Period1Length < Period2Length) {
        while (IsDate1BeforeDate2(Period1.StartDate, Period1.EndDate)) {
            if (IsDateWithinPeriod(Period1.StartDate, Period2))
                ++OverlapDays;

            Period1.StartDate = IncreaseDayToDate(Period1.StartDate);
        }
    }
    else {
        while (IsDate1BeforeDate2(Period2.StartDate, Period2.EndDate)) {
            if (IsDateWithinPeriod(Period2.StartDate, Period1))
                ++OverlapDays;

            Period2.StartDate = IncreaseDayToDate(Period2.StartDate);
        }
    }

    return OverlapDays;
}

int main()
{
    cout << "\nEnter Period 1:";
    sPeriod Period1 = ReadPeriod();
    cout << "\nEnter Period 2:";

    sPeriod Period2 = ReadPeriod();


   cout << "Overlap Days Count Is: " << CountOverlapDays(Period1, Period2);

    return 0;
}