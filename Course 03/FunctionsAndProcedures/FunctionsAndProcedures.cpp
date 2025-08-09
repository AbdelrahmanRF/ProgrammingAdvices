#include <iostream>
#include <string>
#include <format>
using namespace std;

string gName = "Waleed Farahat";
// Procedure (return no thing)
void greeting() {
    cout << "Welcome!\n";
}

void swapTwoNumbers(int &num1, int &num2) {
    int temp = num1;
    num1 = num2;
    num2 = temp;
}
// function (return value)
string greetingWithName(string name) {
    return format("Hello mr/miss {}\n", name);
}
int main()
{
    int x = 1, y = 2;
    greeting();
    cout << greetingWithName("Abdelrahman Alfar") + "LOL\n";
    cout << greetingWithName(::gName);

    ::gName = "Tareq Vlad";
    cout << greetingWithName(::gName);

    cout << x << ',' << y << endl;

    swapTwoNumbers(x, y);
    cout << x << ',' << y << endl;

    return 0;
}
