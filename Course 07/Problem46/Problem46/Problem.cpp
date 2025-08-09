#include <iostream>
#include <string>
#include <vector>
using namespace std;

struct strClient
{
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance;
};

vector<string> Split(string S1, string Delimiter) {
	vector<string> Words;
	string Word;
	short Pos = 0;

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

strClient ConvertLinetoRecord(string Line) {
	vector<string> vecClient = Split(Line, "#//#");
	strClient Client;

	Client.AccountNumber = vecClient[0];
	Client.PinCode = vecClient[1];
	Client.Name = vecClient[2];
	Client.Phone = vecClient[3];
	Client.AccountBalance = stod(vecClient[4]);

	return Client;
}

void PrintClientRecord(strClient Client) {

	cout << "\n\nThe following is the extracted client record:\n\n";

	cout << "Account Number  : " << Client.AccountNumber << endl;
	cout << "Pin Code        : " << Client.PinCode << endl;
	cout << "Name            : " << Client.Name << endl;
	cout << "Phone           : " << Client.Phone << endl;
	cout << "Account Balance : " << Client.AccountBalance << endl;
}

int main()
{
	string strLine = "yy1234a#//#1234#//#mustafa ahmad#//#078000000#//#7878.000000";

	cout << "\nLine Record is:\n";
	cout << strLine;

	strClient Client = ConvertLinetoRecord(strLine);

	PrintClientRecord(Client);

	return 0;
}

