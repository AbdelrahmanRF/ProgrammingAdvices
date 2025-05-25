#include <iostream>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

const string ClientsFileName = "Clients.txt";

//struct strClient {
//	string AccountNumber;
//	string PinCode;
//	string Name;
//	string Phone;
//	double AccountBalance;
//};

struct strClient {
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance;
	bool MarkForDelete = false;
};

vector<string> Split(string S1, string Separator = "#//#") {
	vector<string> Words;
	string Word;
	short Pos = 0;

	while ((Pos = S1.find(Separator)) != string::npos) {
		Word = S1.substr(0, Pos);
		if (Word != "") {
			Words.push_back(Word);
		}
		S1.erase(0, Pos + Separator.length());
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
	MyFile.open(FileName, ios::in);
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

bool FindClientByAccountNumber(string AccountNumber, strClient& Client, vector<strClient> Clients) {
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

char ConfirmDeleting() {
	char Confirm;
	cout << "\nAre you sure you delete this client? y/n ? ";
	cin >> Confirm;

	return Confirm;
}

//void DeleteLineFromFile(string AccountNumberToSearch, string Separator) {
//	fstream MyFile;
//	fstream tempFile;
//
//	MyFile.open(ClientsFileName, ios::in);
//	tempFile.open("temp.txt", ios::out);
//	if (MyFile.is_open() && tempFile.is_open()) {
//		string Line;
//		string AccountNumber;
//		while (getline(MyFile, Line)) {
//			AccountNumber = Line.substr(0, Line.find(Separator));
//			if (AccountNumber != AccountNumberToSearch)
//			tempFile << Line << endl;
//		}
//
//		tempFile.close();
//		MyFile.close();
//
//		remove(ClientsFileName.c_str());
//		rename("temp.txt", ClientsFileName.c_str());
//	}
//}

//void DeleteUserRecord(string AccountNumber, vector<strClient> Clients) {
//	strClient Client;
//	if (FindClientByAccountNumber(AccountNumber, Client, Clients))
//	{
//		PrintAccountDetails(Client);
//		char Confirm = ConfirmDeleting();
//
//		if (toupper(Confirm) == 'Y') {
//
//			DeleteLineFromFile(AccountNumber, "#//#");
//			Clients = LoadClientsDataFromFile(ClientsFileName);
//			cout << "\nClient Deleted Successfully.";
//		}
//	}
//	else
//	{
//		cout << "\nClient with Account Number (" << AccountNumber <<
//			") is Not Found!";
//	}
//
//}

string ConvertRecordToLine(strClient Client, string Seperator = "#//#") {
	string ClientRecord = "";

	ClientRecord += Client.AccountNumber + Seperator;
	ClientRecord += Client.PinCode + Seperator;
	ClientRecord += Client.Name + Seperator;
	ClientRecord += Client.Phone + Seperator;
	ClientRecord += to_string(Client.AccountBalance);

	return ClientRecord;
}

bool MarkClientForDeleteByAccountNumber(string AccountNumber, vector<strClient>& Clients) {
	for (strClient& Client : Clients) {
		if (Client.AccountNumber == AccountNumber) {
			Client.MarkForDelete = true;
			return true;
		}
	}
	return false;
}

void SaveCleintsDataToFile(string FileName, vector<strClient>& Clients) {
	fstream MyFile;
	string Line;
	MyFile.open(ClientsFileName, ios::out);
	if (MyFile.is_open()) {
		for (strClient& C : Clients) {
			if (!C.MarkForDelete) {
				Line = ConvertRecordToLine(C);
				MyFile << Line << endl;
			}
		}
	}
}

void DeleteUserRecord(string AccountNumber, vector<strClient>& Clients) {
	strClient Client;
	if (FindClientByAccountNumber(AccountNumber, Client, Clients))
	{
		PrintAccountDetails(Client);
		char Confirm = ConfirmDeleting();

		if (toupper(Confirm) == 'Y') {

			MarkClientForDeleteByAccountNumber(AccountNumber, Clients);
			SaveCleintsDataToFile(ClientsFileName, Clients);

			Clients = LoadClientsDataFromFile(ClientsFileName);
			cout << "\nClient Deleted Successfully.";
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

	DeleteUserRecord(AccountNumber, Clients);


	return 0;
}

