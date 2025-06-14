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

sDate ReadFullDate() {
    sDate Date;

    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();

    return Date;
}

//sDate GetDateAfterAddingDays(short DaysToAdd, sDate Date) {
//    short MonthDays = 0, DaysUntilMonthEnd = 0;
//    short RemainingDays = DaysToAdd;
//
//    while (RemainingDays != 0) {
//        MonthDays = NumberOfDaysInAMonth(Date.Month, Date.Year);
//        DaysUntilMonthEnd = MonthDays - Date.Day;
//
//        if (RemainingDays < DaysUntilMonthEnd || RemainingDays == DaysUntilMonthEnd) {
//            Date.Day += RemainingDays;
//            RemainingDays = 0;
//        }
//
//        if (RemainingDays > DaysUntilMonthEnd) {
//            Date.Day = 1;
//            RemainingDays -= DaysUntilMonthEnd + 1;
//
//            if (++Date.Month == 13) {
//                Date.Month = 1;
//                ++Date.Year;
//            }
//        }
//    }
//    
//    return Date;
//}

sDate GetDateAfterAddingDays(short DaysToAdd, sDate Date) {
    short MonthDays = 0;
    short RemainingDays = DaysToAdd + DaysFromTheBeginningOfYear(Date);

    Date.Month = 1;

    while (true) {
        MonthDays = NumberOfDaysInAMonth(Date.Month, Date.Year);

        if (RemainingDays > MonthDays) {
            RemainingDays -= MonthDays;
            Date.Month++;

            if (Date.Month == 13) {
                Date.Month = 1;
                Date.Year++;
            }
        }
        else {
            Date.Day = RemainingDays;
            break;
        }
    }

    return Date;
}


int main()
{
    sDate Date = ReadFullDate();
    short DaysToAdd = ReadDaysToAdd();


    Date = GetDateAfterAddingDays(DaysToAdd, Date);
    cout << "\nDate after adding [" << DaysToAdd << "] days is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

    return 0;
}