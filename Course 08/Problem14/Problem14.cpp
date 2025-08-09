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

//bool IsDate1EqualDate2(const sDate Date1, const sDate Date2)
//{
//    //return (Date1.Year == Date2.Year) && (Date1.Month == Date2.Month) && (Date1.Day == Date2.Day);
//
//    return (Date1.Year == Date2.Year) ?
//        ((Date1.Month == Date2.Month) ? ((Date1.Day == Date2.Day) ? true : false) : false)
//        : false;
//}

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

int main()
{
    sDate Date1 = ReadFullDate();
    sDate Date2 = ReadFullDate();

    if (IsDate1EqualDate2(Date1, Date2)) {
        cout << "\nYes, Date 1 is Equal to Date 2";
    }
    else {
        cout << "\nNo, Date 1 is Not Equal to Date 2";
    }

    return 0;
}
