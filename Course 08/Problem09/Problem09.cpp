#include <iostream>
#include <iomanip>

using namespace std;

short ReadYear() {
    short Year;
    cout << "Please Enter a Year? ";
    cin >> Year;

    return Year;
}

short DayOrder(short Year, short Month, short Day) {
    short A, Y, M;
    A = (14 - Month) / 12;
    Y = Year - A;
    M = Month + 12 * A - 2;

    return (Day + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
}

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Year, short Month)
{
    if (Month < 0 || Month > 12) {
        return 0;
    }
    short MonthDays[12] = { 31, 28, 31, 30, 31, 30, 31  ,31, 30, 31, 30,31 };

    return Month == 2 ? (IsLeapYear(Year) ? 29 : 28) : MonthDays[Month - 1];
}


string MonthName(short MonthNum) {
    string Months[12] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    return Months[MonthNum - 1];
}

void PrintMonthCalender(short Year, short Month) {
    short NumberOfDays = NumberOfDaysInAMonth(Year, Month);
    short MonthDayIndex = DayOrder(Year, Month, 1);

    printf("\n ________________%s______________\n\n", MonthName(Month).c_str());
    printf(" Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");
    int i;
    for (i = 0; i < MonthDayIndex; i++)
        printf("     ");

    for (int j = 1; j < NumberOfDays; j++)
    {
        printf("%5d", j);

        if (++i == 7) {
            i = 0;
            printf("\n");
        }
    }

    printf("\n _________________________________\n");
}

void PrintYearCalender(short Year) {
    printf("\n _________________________________\n\n");
    printf("          Calender - %d       \n", Year);
    printf("\n _________________________________\n");

    for (int i = 1; i <= 12; i++) {
        PrintMonthCalender(Year, i);
    }
}

int main()
{
    short Year = ReadYear();

    PrintYearCalender(Year);

    return 0;
}