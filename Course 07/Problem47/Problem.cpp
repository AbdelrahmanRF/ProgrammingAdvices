#include <iostream>
#include <string>
#include <fstream>
using namespace std;

const string ClientsFileName = "Clients.txt";

struct strClient {
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance;
};

strClient ReadClient() {
	strClient Client;

	cout << "Enter Account Number? ";
	// Usage of std::ws will extract allthe whitespace character
	getline(cin >> ws, Client.AccountNumber);

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

string ConvertRecordToLine(strClient Client, string Separator = "#//#") {
	string ClientRecord = "";

	ClientRecord += Client.AccountNumber + Separator;
	ClientRecord += Client.PinCode + Separator;
	ClientRecord += Client.Name + Separator;
	ClientRecord += Client.Phone + Separator;
	ClientRecord += to_string(Client.AccountBalance);

	return ClientRecord;
}

void SaveStringToFile(string FileName, string Content) {
	fstream MyFile;

	MyFile.open(FileName, ios::out | ios::app);

	if (MyFile.is_open()) {

		MyFile << Content << endl;

		MyFile.close();
	}
}

void AddNewClient() {
	strClient Client;
	Client = ReadClient();
	SaveStringToFile(ClientsFileName, ConvertRecordToLine(Client));
}

void AddClients() {
	char AddNew = 'Y';

	do {
		system("cls");
		cout << "Adding New Client:\n\n";
		AddNewClient();
		cout << "\nClient Added Successfuly, do you want to add more clients? Y/N?";
		cin >> AddNew;

	} while (toupper(AddNew) == 'Y');
}

int main()
{
	AddClients();
	
	return 0;
}

