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

//short CompareTwoDates(sDate Date1, sDate Date2) {
//    return IsDate1EqualDate2(Date1, Date2) ? 0 : (IsDate1BeforeDate2(Date1, Date2) ? -1 : 1);
//}

enum enDateCompare { Before = -1, Equal = 0, After = 1 };

enDateCompare CompareTwoDates(sDate Date1, sDate Date2) {
    return IsDate1EqualDate2(Date1, Date2) ? enDateCompare::Equal : 
        (IsDate1BeforeDate2(Date1, Date2) ? enDateCompare::Before: enDateCompare::After);
}

int main()
{
    cout << "Enter Date 1:\n";
    sDate Date1 = ReadFullDate();

    cout << "\nEnter Date 2:\n";
    sDate Date2 = ReadFullDate();

    cout << "\nCompare Result : " << CompareTwoDates(Date1, Date2);

    return 0;
}