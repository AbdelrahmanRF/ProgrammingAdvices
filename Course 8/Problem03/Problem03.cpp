#include <iostream>
using namespace std;

short ReadYear() {
    short Year;
    cout << "Enter a Year? ";
    cin >> Year;

    return Year;
}

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0);
}

int main()
{
    short Year = ReadYear();

    if (IsLeapYear(Year)) {
        cout << Year << " is a Leap Year";
    }
    else {
        cout << Year << " is not a Leap Year";
    };

    return 0;
}