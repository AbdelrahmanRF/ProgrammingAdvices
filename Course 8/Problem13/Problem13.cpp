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

// bool IsLeapYear(short Year) {
//     return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
// }

// short NumberOfDaysInAMonth(short Month, short Year)
// {
//     if (Month < 0 || Month > 12) {
//         return 0;
//     }
//     short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31 ,31, 30, 31, 30, 31 };

//     return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];
// }

// short DaysFromTheBeginningOfYear(sDate Date) {
//     short TotalDays = 0;

//     for (int i = 1; i < Date.Month; i++) {
//         TotalDays += NumberOfDaysInAMonth(i, Date.Year);
//     }

//     TotalDays += Date.Day;

//     return TotalDays;
// }

//bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
//    if (Date1.Year < Date2.Year) return true;
//
//    short Date1DayOfYear = DaysFromTheBeginningOfYear(Date1);
//    short Date2DayOfYear = DaysFromTheBeginningOfYear(Date2);
//
//    if ((Date1.Year == Date2.Year) && Date1DayOfYear < Date2DayOfYear) return true;
//
//    return false;
//}

//bool IsDate1BeforeDate2(sDate Date1, sDate Date2)
//{
//    return (Date1.Year < Date2.Year) 
//        ? true 
//        : ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true 
//            : (Date1.Month == Date2.Month) ? (Date1.Day < Date2.Day ? true : false) : false) : false);
//}

bool IsDate1BeforeDate2( sDate Date1, sDate Date2) {
    if (Date1.Year != Date2.Year)
        return Date1.Year < Date2.Year;

    if (Date1.Month != Date2.Month)
        return Date1.Month < Date2.Month;

    return Date1.Day < Date2.Day;
}

sDate ReadFullDate() {
    sDate Date;

    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();

    return Date;
}

int main()
{
    sDate Date1 = ReadFullDate();
    sDate Date2 = ReadFullDate();

    if (IsDate1BeforeDate2(Date1, Date2)) {
        cout << "\nYes, Date 1 is Less Than Date 2";
    }
    else {
        cout << "\nNo, Date 1 is Not Less Than Date 2";
    }

    return 0;
}