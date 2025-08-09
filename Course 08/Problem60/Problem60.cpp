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


//bool IsDateWithinPeriod(sPeriod Period, sDate DateToCheck) {
//    if (CompareTwoDates(Period.EndDate, DateToCheck) == enDateCompare::Before
//        || CompareTwoDates(Period.StartDate, DateToCheck) == enDateCompare::After) {
//        return false;
//    }
//
//    return true;
//}

bool IsDateWithinPeriod(sPeriod Period, sDate DateToCheck) {
    return !(CompareTwoDates(DateToCheck, Period.StartDate) == enDateCompare::Before
        || CompareTwoDates(DateToCheck, Period.EndDate) == enDateCompare::After);
}

int main()
{
    cout << "\nEnter Period :";
    sPeriod Period1 = ReadPeriod();

    cout << "\nEnter Date to Check :";
    sDate DateToCheck = ReadFullDate();

    if (IsDateWithinPeriod(Period1, DateToCheck)) {
        cout << "Yes, Date Within Period";
    }
    else {
        cout << "No, Date is not Within Period";
    }

    return 0;
}