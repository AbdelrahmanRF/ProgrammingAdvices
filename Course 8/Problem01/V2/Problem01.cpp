#include <iostream>
using namespace std;

int ReadNumber() {
    int Number;
    cout << "Enter a Number? ";
    cin >> Number;

    return Number;
}

string ConvertNumberToText(int Number) {
    if (Number == 0) {
        return "";
    }

    if (Number >= 1 && Number <= 19) {
        string arr[] = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" , "Ten",
             "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        return arr[Number] + " ";
    }
    if (Number >= 20 && Number <= 99) {
        string arr[] = { "", "", "Twenty", "Thirty", "Forty","Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        return arr[Number / 10] + " " + ConvertNumberToText(Number % 10);
    }
    if (Number >= 100 && Number <= 199) {
        return "One Handred " + ConvertNumberToText(Number % 100);
    }
    if (Number >= 200 && Number <= 999) {
        return ConvertNumberToText(Number / 100) + "Handreds " + ConvertNumberToText(Number % 100);
    }
    if (Number >= 1000 && Number <= 1999) {
        return "One Thousands " + ConvertNumberToText(Number % 1000);
    }
    if (Number >= 2000 && Number <= 999999) {
        return ConvertNumberToText(Number / 1000) + "Thousands " + ConvertNumberToText(Number % 1000);
    }
    if (Number >= 1000000 && Number <= 1999999) {
        return "One Million " + ConvertNumberToText(Number % 1000000);
    }
    if (Number >= 2000000 && Number <= 999999999) {
        return ConvertNumberToText(Number / 1000000) + "Millions " + ConvertNumberToText(Number % 1000000);
    }
    if (Number >= 1000000000 && Number <= 1999999999) {
        return "One Billion " + ConvertNumberToText(Number % 1000000000);
    }
    else{
        return ConvertNumberToText(Number / 1000000000) + "Billions " + ConvertNumberToText(Number % 1000000000);
    }
}

int main()
{
    int Number = ReadNumber();

    cout << ConvertNumberToText(Number);

    return 0;
}

