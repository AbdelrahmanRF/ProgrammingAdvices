#include <iostream>
#include <vector>
using namespace std;

const string Ones[10] = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
const string Teens[9] = {"Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
const string Tens[9] = {"Ten", "Twenty", "Thirty", "Forty","Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
const string Scales[4] = {"Hundred", "Thousand", "Million", "Billion"};

int CountDigits(int Number) {
    if (Number == 0) {
        return 1;
    }
    if (Number / 10 == 0) {
        return 1;
    }
    return 1 + CountDigits(Number / 10);
}

string ConvertOnesAndTensToText(int Number) {
    int Digits = CountDigits(Number);

    if (Digits == 1)
        return Ones[Number];

    if (Digits == 2 && Number / 10 == 1)
        return Teens[Number % 10 - 1];
    
    if (Digits == 2 && Number % 10 == 0) 
        return Tens[Number / 10 - 1];
    
    if (Digits == 2) 
        return Tens[Number / 10 - 1] + " " + Ones[Number % 10];
    
    if (Digits == 3) {
        string First2Digits = ConvertOnesAndTensToText(Number % 100);
        return Ones[Number / 100] + " " + Scales[0] + (First2Digits != "" ? " " + First2Digits : "");
    }
}

vector<int> BreakNumberTo3Bricks(int Number) {
    vector<int> Bricks;

    while (Number != 0) {
        Bricks.push_back(Number % 1000);
        Number /= 1000;
    }

    return Bricks;
}

int ReadNumber() {
    int Number;
    cout << "Enter a Number? ";
    cin >> Number;

    return Number;
}

string ConvertNumberToText(int Number) {
    if (Number == 0)
        return "Zero";

    if (CountDigits(Number) <= 3)
        return ConvertOnesAndTensToText(Number);

    vector<int> vNumber = BreakNumberTo3Bricks(Number);
    string result = "";

    for (int i = vNumber.size() - 1; i >= 0; --i) {
        result += ConvertOnesAndTensToText(vNumber[i]);
        if (i > 0) result += " " + Scales[i] + " ";
    }

    return result;
}

int main()
{
    cout << ConvertNumberToText(ReadNumber());
    return 0;
}

