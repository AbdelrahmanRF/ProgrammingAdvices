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
//enum enDateCompare { Before = -1, Equal = 0, After = 1 };
//
//enDateCompare CompareTwoDates(sDate Date1, sDate Date2) {
//    return IsDate1EqualDate2(Date1, Date2) ? enDateCompare::Equal :
//        (IsDate1BeforeDate2(Date1, Date2) ? enDateCompare::Before : enDateCompare::After);
//}

//bool IsPeriodsOverlap(sPeriod Period1, sPeriod Period2) {
//    sPeriod PeriodsBoundaries;
//    short CompareStartDatesResult = CompareTwoDates(Period1.StartDate, Period2.StartDate);
//    short CompareEndDatesResult = CompareTwoDates(Period1.EndDate, Period2.EndDate);
//
//    PeriodsBoundaries.StartDate = (CompareStartDatesResult == 0 || CompareStartDatesResult == -1) ? Period1.StartDate : Period2.StartDate;
//    PeriodsBoundaries.EndDate = (CompareEndDatesResult == 0 || CompareEndDatesResult == 1) ? Period1.EndDate : Period2.EndDate;
//
//    if ((CompareTwoDates(Period1.StartDate, PeriodsBoundaries.StartDate) >= 0) &&
//        (CompareTwoDates(Period1.StartDate, PeriodsBoundaries.EndDate) == -1 || CompareTwoDates(Period1.EndDate, PeriodsBoundaries.EndDate) == -1)) {
//        return true;
//    }
//
//    if ((CompareTwoDates(Period2.StartDate, PeriodsBoundaries.StartDate) >= 0) &&
//        (CompareTwoDates(Period2.StartDate, PeriodsBoundaries.EndDate) == -1 || CompareTwoDates(Period2.EndDate, PeriodsBoundaries.EndDate) == -1)) {
//        return true;
//    }
//
//    return false;
//}

bool IsPeriodsOverlap(sPeriod Period1, sPeriod Period2) {
    if (IsDate1BeforeDate2(Period2.EndDate, Period1.StartDate) || IsDate1BeforeDate2(Period1.EndDate, Period2.StartDate)) {
        return false;
    }

    return true;
}

int main()
{
    cout << "\nEnter Period 1:"; 
    sPeriod Period1 = ReadPeriod();
    cout << "\nEnter Period 2:"; 

    sPeriod Period2 = ReadPeriod();

    
    if (IsPeriodsOverlap(Period1, Period2)) {
        cout << "Yes, Periods Overlap";
    }
    else {
        cout << "No, Periods not Overlapping";
    }

    return 0;
}