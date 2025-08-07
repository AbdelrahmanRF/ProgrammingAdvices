#include <iostream>
#include "clsString.h"

using namespace std;

int main()
{
    clsString String1;
    clsString String2("Jamal Dawood Ahmad Dawood");

    String1.Value = "Ali";

    cout << "String1 = " << String1.Value << endl;
    cout << "String2 = " << String2.Value << endl;

    cout << "Number of words: " << String1.CountWords() << endl;
    cout << "Number of words: " << String1.CountWords("Fadi Ahmad") << endl;
    cout << "Number of words: " << clsString::CountWords("Qasem Ahmad Eyad") << endl;
    cout << "***********************************************************************************" << endl;

    clsString::PrintFirstLetterOfEachWord("Qasem Ahmad Eyad");
    cout << "***********************************************************************************" << endl;

    for (string& Word : clsString::Split("Qasem Ahmad Eyad", " ")) {
        cout << Word << endl;
    }
    cout << "***********************************************************************************" << endl;

    cout << clsString::Trim("         Qasem Ahmad Eyad                  ") << endl;
    cout << "***********************************************************************************" << endl;

    cout << clsString::Join(clsString::Split("Qasem Ahmad Eyad", " "), " ") << endl;
    cout << "***********************************************************************************" << endl;

    string arrString[] = { "Mohammed","Faid","Ali","Maher" };
    cout << clsString::Join(arrString, 4, " ") << endl;
    cout << "***********************************************************************************" << endl;

    String2.ReplaceWord("Dawood", "Fareed");
    cout << String2.Value << endl;
    cout << "***********************************************************************************" << endl;

    string S1 = "Welcome to Jordan, Jordan is a nice country; it's amazing.";     
    cout << "Pauncuations Removed:\n" << clsString::RemovePunctuations(S1) << endl;
    cout << "***********************************************************************************" << endl;
}
