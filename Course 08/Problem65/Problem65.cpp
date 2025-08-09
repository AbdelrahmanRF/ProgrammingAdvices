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

string Replace(string S1, string StringToReplace, string ReplaceTo) {

	short Pos = S1.find(StringToReplace);

	while (Pos != string::npos) {
		S1 = S1.replace(Pos, StringToReplace.length(), ReplaceTo);
		Pos = S1.find(StringToReplace);
	}
	return S1;
}

string toFormattedDateString (sDate Date, string Format = "dd/mm/yyyy") 
{
	string FormattedDateString = "";

	FormattedDateString = Replace(Format, "dd", to_string(Date.Day));
	FormattedDateString = Replace(FormattedDateString, "mm", to_string(Date.Month));
	FormattedDateString = Replace(FormattedDateString, "yyyy", to_string(Date.Year));

	return FormattedDateString;
}

int main()
{
	string DateStr = ReadDateStr();

	sDate Date = StringToDate(DateStr);
	
	cout << "\n" << toFormattedDateString(Date) << "\n";
	cout << "\n" << toFormattedDateString(Date, "yyyy/dd/mm") << "\n";
	cout << "\n" << toFormattedDateString(Date, "mm/dd/yyyy") << "\n";
	cout << "\n" << toFormattedDateString(Date, "mm-dd-yyyy") << "\n";
	cout << "\n" << toFormattedDateString(Date, "dd-mm-yyyy") << "\n";
	cout << "\n" << toFormattedDateString(Date, "Day:dd, Month:mm, Year:yyyy") << "\n";

	return 0;
}
