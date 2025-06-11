#include <iostream>
using namespace std;

int ReadYear() {
    int Year;
    cout << "Enter a Year? ";
    cin >> Year;

    return Year;
}

bool IsLeapYear(int Year) {
    if (Year % 400 == 0) {
        return true;
    }
    if (Year % 100 == 0) {
        return false;
    }
    if (Year % 4 == 0) {
        return true;
    }
    return false;
}

int main()
{
    int Year = ReadYear();
    
    if (IsLeapYear(Year)) {
        cout << Year << " is a Leap Year";
    }
    else {
        cout << Year << " is not a Leap Year";
    };

    return 0;
}

