#include <iostream>
#include <iomanip>

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

//void PrintMonthCalender(short Year, short Month) {
//    string Days[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
//    string Months[12] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
//    short NumberOfDays = NumberOfDaysInAMonth(Year, Month);
//    short MonthDayIndex = DayOrder(Year, Month, 1);
//
//    printf("\n ________________%s_______________\n", Months[Month - 1].c_str());
//    for (short i = 0; i < 7; i++) {
//        cout << right << setw(5) << Days[i];
//    }
//    cout << endl;
//    //short Counter = -1;
//    short Counter = 0;
//    for (short i = MonthDayIndex * -1 ; i <= NumberOfDays; i++) {
//        Counter++;
//
//        if (i > 0)
//            cout <<  right << setw(5) << i;
//        else
//            cout << setw(5) << " ";
//
//        //if (Counter % 7 == 0) cout << endl;
//        if (Counter == 7) {
//            Counter = 0;
//            cout << endl;
//        }
//    }
//
//    printf("\n __________________________________\n");
//}

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

int main()
{
    short Year = ReadYear();
    short Month = ReadMonth();

    PrintMonthCalender(Year, Month);

    return 0;
}