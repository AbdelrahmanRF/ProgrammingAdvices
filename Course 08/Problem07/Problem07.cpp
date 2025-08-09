#include <iostream>
using namespace std;

short ReadYear() {
    short Year;
    cout << "Please Enter a Year? ";
    cin >> Year;

    return Year;
}

short ReadMonth() {
    short Month;
    cout << "Please Enter a Month? ";
    cin >> Month;

    return Month;
}

short ReadDay() {
    short Month;
    cout << "Please Enter a Day? ";
    cin >> Month;

    return Month;
}

//bool IsLeapYear(short Year) {
//    return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
//}
//
//short NumberOfDaysInAMonth(short Year, short Month)
//{
//    if (Month < 0 || Month > 12) {
//        return 0;
//    }
//    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31  ,31, 30, 31, 30,31 };
//
//    return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];
//}
//
//int DaysGoneTotal(short Year, short Month, short Day) {
//    int DaysGone = 0;
//
//    for (short i = 1900; i < Year; i++) {
//        DaysGone += IsLeapYear(i) ? 366 : 365;
//    }
//    for (short i = 1; i < Month; i++) {
//        DaysGone += NumberOfDaysInAMonth(Year, i);
//    }
//    DaysGone += Day;
//
//    return DaysGone;
//}
//
//short DayOrder(short Year, short Month, short Day) {
//    return DaysGoneTotal(Year, Month, Day) % 7;
//}

short DayOrder(short Year, short Month, short Day) {
    short A, Y, M;
    A = (14 - Month) / 12;
    Y = Year - A;
    M = Month + 12 * A - 2;

    return (Day + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
}

string DayName(short DayOfWeekOrder) {
    string Days[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    return Days[DayOfWeekOrder];
}

int main()
{
    short Year = ReadYear();
    short Month = ReadMonth();
    short Day = ReadDay();
    short DayOfWeekOrder = DayOrder(Year, Month, Day);

    cout << "\nDate        :" << Day << "/" << Month << "/" << Year;
    cout << "\nDay Order   :" << DayOfWeekOrder;
    cout << "\nDay Name    :" << DayName(DayOfWeekOrder);

    return 0;
}