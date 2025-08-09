#include <iostream>
#include <string>
#include <vector>
using namespace std;

struct sDate {
    short Day;
    short Month;
    short Year;
};

string ReadDateStr() {
    string DateStr;
    cout << "\nPlease Enter Date dd/mm/yyyy? ";
    getline(cin >> ws, DateStr);

    return DateStr;
}

vector<string> Split(string S1, string Delimiter = " ") {
	short Pos = 0;
	string Word;
	vector<string> Words;

	while ((Pos = S1.find(Delimiter)) != string::npos) {
		Word = S1.substr(0, Pos);

		if (Word != "") {
			Words.push_back(Word);
		}
		S1.erase(0, Pos + Delimiter.length());
	}
	if (S1 != "") {
		Words.push_back(S1);
	}

	return Words;
}

sDate StringToDate(string DateStr) {
	sDate Date;
	vector <string> vDate;

	vDate = Split(DateStr, "/");

	Date.Day = stoi(vDate[0]);
	Date.Month = stoi(vDate[1]);
	Date.Year = stoi(vDate[2]);

	return Date;
}

string DateToString(sDate Date) {
	return to_string(Date.Day) + "/" + to_string(Date.Month) + "/" + to_string(Date.Year);
}

int main()
{
    string DateStr = ReadDateStr();

	sDate Date = StringToDate(DateStr);
	cout << "\nDay  : " << Date.Day << endl;
	cout << "Month: " << Date.Month << endl;
	cout << "Year : " << Date.Year << endl;

	cout << "\n\nYou Entered: " << DateToString(Date);

    return 0;
}
