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

//int CalculateDateDifference(sDate Date1, sDate Date2, bool IncludeEndDay = false) {
//    int TotalDaysDifference = 0;
//    bool IsDatesInverted = !IsDate1BeforeDate2(Date1, Date2);
//
//    if (IsDatesInverted) {
//        while (IsDate1BeforeDate2(Date2, Date1)) {
//            TotalDaysDifference++;
//            Date2 = IncreaseDayToDate(Date2);
//        }
//    }
//    else {
//        while (IsDate1BeforeDate2(Date1, Date2)) {
//            TotalDaysDifference++;
//            Date1 = IncreaseDayToDate(Date1);
//        }
//    }
//
//    TotalDaysDifference = IsDatesInverted ? TotalDaysDifference * -1 : TotalDaysDifference;
//
//    return IncludeEndDay ? (IsDatesInverted ? --TotalDaysDifference : ++TotalDaysDifference) 
//        : TotalDaysDifference;
//}

void SwapDates(sDate& Date1, sDate& Date2) {
    sDate TempDate = Date1;

    Date1.Year = Date2.Year;
    Date1.Month = Date2.Month;
    Date1.Day = Date2.Day;

    Date2.Year = TempDate.Year;
    Date2.Month = TempDate.Month;
    Date2.Day = TempDate.Day;
}

int CalculateDateDifference(sDate Date1, sDate Date2, bool IncludeEndDay = false) {
    int TotalDaysDifference = 0;
    short SwapFlagValue = 1;

    if (!IsDate1BeforeDate2(Date1, Date2)) {
        SwapDates(Date1, Date2);
        SwapFlagValue = -1;
    }

    while (IsDate1BeforeDate2(Date1, Date2)) {
        TotalDaysDifference++;
        Date1 = IncreaseDayToDate(Date1);
    }

    return IncludeEndDay ? ++TotalDaysDifference * SwapFlagValue : TotalDaysDifference * SwapFlagValue;
}

int main()
{
    sDate Date1 = ReadFullDate();
    sDate Date2 = ReadFullDate();

    cout << "\nDifference is: " << CalculateDateDifference(Date1, Date2);
    cout << "\nDifference (Including End Day) is:" << CalculateDateDifference(Date1, Date2, true);


    return 0;
}
