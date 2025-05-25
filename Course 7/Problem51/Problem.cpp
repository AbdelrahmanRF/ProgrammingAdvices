#include <iostream>
#include <string>
#include <vector>
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

vector<string> Split (string S1, string Seperator = "#//#"){
	string Word;
	vector<string> Words;
	short Pos = 0;

	while ((Pos = S1.find(Seperator)) != string::npos) {
		Word = S1.substr(0, Pos);
		if (Word != "") {
			Words.push_back(Word);
		}
		S1.erase(0, Pos + Seperator.length());
	}

	if (S1 != "") {
		Words.push_back(S1);
	}
	return Words;
}

strClient ConvertLineToRecord(string Line) {
	vector<string> Record = Split(Line);
	strClient Client;

	Client.AccountNumber = Record[0];
	Client.PinCode = Record[1];
	Client.Name = Record[2];
	Client.Phone = Record[3];
	Client.AccountBalance = stod(Record[4]);

	return Client;
}

vector<strClient> LoadClientsDataFromFile(string FileName) {
	fstream MyFile;
	vector<strClient> Clients;

	MyFile.open(ClientsFileName, ios::in);
	if (MyFile.is_open()) {
		string Line;
		strClient Client;
		while (getline(MyFile, Line)) {
			Client = ConvertLineToRecord(Line);
			Clients.push_back(Client);
		}
		MyFile.close();
	}
	return Clients;
}

string ReadAccountNumber() {
	string AccountNumber;
	cout << "Please Enter Account Number? ";
	cin >> AccountNumber;

	return AccountNumber;
}

bool FindClientByAccountNumber(string AccountNumber, strClient& Client, vector<strClient>& Clients) {
	for (strClient& C : Clients) {
		if (C.AccountNumber == AccountNumber) {
			Client = C;
			return true;
		}
	}
	return false;
}

void PrintAccountDetails(strClient Client) {
	cout << "\nThe following are the client details:\n";
	cout << "Account Number : " << Client.AccountNumber << endl;
	cout << "Pin Code       : " << Client.PinCode << endl;
	cout << "Name           : " << Client.Name << endl;
	cout << "Phone          : " << Client.Phone << endl;
	cout << "Account Balance: " << Client.AccountBalance << endl;
}

char ConfirmUpdating() {
	char Confirm;
	cout << "\nAre you sure you update this client? y/n ? ";
	cin >> Confirm;
	cin.ignore();

	return Confirm;
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

//void UpdateClientData(strClient& Client) {
//	cout << "\nEnter Pin Code? ";
//	getline(cin, Client.PinCode);
//
//	cout << "Enter Name? ";
//	getline(cin , Client.Name);
//
//	cout << "Enter Phone? ";
//	getline(cin, Client.Phone);
//
//	cout << "Enter Account Balance? ";
//	cin >> Client.AccountBalance;
//
//}

//void UpdateClientDataByAccountNumber(string AccountNumber, vector<strClient>& Clients) {
//	for (strClient& C : Clients) {
//		if (C.AccountNumber == AccountNumber)
//			UpdateClientData(C);
//	}
//}

strClient UpdateClientData(string AccountNumber)
{
	strClient Client;
	Client.AccountNumber = AccountNumber;

	cout << "\n\nEnter PinCode? ";
	getline(cin >> ws, Client.PinCode);

	cout << "Enter Name? ";
	getline(cin, Client.Name);

	cout << "Enter Phone? ";
	getline(cin, Client.Phone);

	cout << "Enter AccountBalance? ";
	cin >> Client.AccountBalance;

	return Client;
}

void SaveCleintsDataToFile(string FileName, vector<strClient>& Clients) {
	fstream MyFile;
	string Line;

	MyFile.open(ClientsFileName, ios::out);
	if (MyFile.is_open()) {
		for (strClient& C : Clients) {
			Line = ConvertRecordToLine(C);
			MyFile << Line << endl;
		}

		MyFile.close();
	}
}

void UpdateUserRecord(string AccountNumber, vector<strClient>& Clients) {
	strClient Client;
	if (FindClientByAccountNumber(AccountNumber, Client, Clients))
	{
		PrintAccountDetails(Client);
		char Confirm = ConfirmUpdating();

		if (toupper(Confirm) == 'Y') {

			for (strClient& C : Clients) {
				if (C.AccountNumber == AccountNumber) {
					//UpdateClientData(C);
					C = UpdateClientData(AccountNumber);
					break;
				}
			}

			SaveCleintsDataToFile(ClientsFileName, Clients);

			cout << "\nClient Updated Successfully.";
		}
	}
	else
	{
		cout << "\nClient with Account Number (" << AccountNumber <<
			") is Not Found!";
	}
}

int main()
{
	vector<strClient> Clients = LoadClientsDataFromFile(ClientsFileName);
	string AccountNumber = ReadAccountNumber();

	UpdateUserRecord(AccountNumber, Clients);

	return 0;
}

