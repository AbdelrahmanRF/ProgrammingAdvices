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

bool IsDate1AfterDate2(sDate Date1, sDate Date2) {
    return (!IsDate1BeforeDate2(Date1, Date2) && !IsDate1EqualDate2(Date1, Date2));
}

int main()
{
    cout << "Enter Date 1:\n";
    sDate Date1 = ReadFullDate();

    cout << "\nEnter Date 2:\n";
    sDate Date2 = ReadFullDate();

    if (IsDate1AfterDate2(Date1, Date2)) {
        cout << "\nYes, Date 1 is After Date 2";
    }
    else {
        cout << "\nNo, Date 1 is Not After Date 2";
    }

    return 0;
}