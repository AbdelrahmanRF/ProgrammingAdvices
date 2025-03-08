#include <iostream>
#include <string>
using namespace std;

struct strClient
{
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance;
};

strClient ReadNewClient() {
	strClient Client;

	cout << "Enter Account Number? ";
	getline(cin, Client.AccountNumber);

	cout << "Enter PinCode? ";
	getline(cin, Client.PinCode);

	cout << "Enter Name? ";
	getline(cin, Client.Name);

	cout << "Enter Phone? ";
	getline(cin, Client.Phone);

	cout << "Enter AccountBalance? ";
	cin >> Client.AccountBalance;

	return Client;
}

string ConvertRecordToLine(strClient Client, string Seperator = "#//#") {
	string ClientRecord = "";

	ClientRecord += Client.AccountNumber + Seperator;
	ClientRecord += Client.PinCode + Seperator;
	ClientRecord += Client.Name + Seperator;
	ClientRecord += Client.Phone + Seperator;
	ClientRecord += to_string(Client.AccountBalance);

	return ClientRecord;
}

int main()
{
	strClient Client;

	cout << "\nPlease Enter Client Data: \n\n";
	Client = ReadNewClient();

	cout << "\n\nClient Record for Saving is: \n";
	cout << ConvertRecordToLine(Client);

	return 0;
}

