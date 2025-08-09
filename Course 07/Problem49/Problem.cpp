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

vector<string> Split (string S1, string Separator = "#//#"){
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
	strClient Client;
	vector<string> Record = Split(Line);

	Client.AccountNumber = Record[0];
	Client.PinCode = Record[1];
	Client.Name = Record[2];
	Client.Phone = Record[3];
	Client.AccountBalance = stod(Record[4]);

	return Client;
}

vector<strClient> LoadClientsFromFile(string FileName) {
	vector<strClient> Clients;
	fstream MyFile;

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

void PrintAccountDetails(strClient Client) {
	cout << "Account Number : " << Client.AccountNumber << endl;
	cout << "Pin Code       : " << Client.PinCode << endl;
	cout << "Name           : " << Client.Name << endl;
	cout << "Phone          : " << Client.Phone << endl;
	cout << "Account Balance: " << Client.AccountBalance << endl;
}

//short FindIndex(vector<strClient>& Clients, string AccountNumber) {
//	for (short i = 0; i < Clients.size(); i++) {
//		if (Clients[i].AccountNumber == AccountNumber)
//			return i;
//	}
//	return -1;
//}
//
//void FindAccount(vector<strClient>& Clients) {
//	string AccountNumber;
//	cout << "Please Enter Account Number? ";
//	cin >> AccountNumber;
//
//	short AccountIndex = FindIndex(Clients, AccountNumber);
//
//	if (AccountIndex != -1) {
//		cout << "\nThe following are the client details:\n\n";
//		PrintAccountDetails(Clients[AccountIndex]);
//	}
//	else {
//		cout << "\nClient with Account Number (" << AccountNumber <<") Not Found!" << endl;
//	}
//}

string ReadClientAccountNumber() {
	string AccountNumber;
	cout << "Please Enter Account Number? ";
	cin >> AccountNumber;

	return AccountNumber;
}

bool FindClientByAccountNumber(string AccountNumber, strClient & Client) {
	vector<strClient> Clients = LoadClientsFromFile(ClientsFileName);

	for (strClient C : Clients) {
		if (C.AccountNumber == AccountNumber) {
			Client = C;
			return true;
		}
	}
	return false;
}

int main()
{
	//vector<strClient> Clients = LoadClientsFromFile(ClientsFileName);
	//FindAccount(Clients);

	strClient Client;
	string AccountNumber = ReadClientAccountNumber();
	if (FindClientByAccountNumber(AccountNumber, Client))
	{
		PrintAccountDetails(Client);
	}
	else
	{
		cout << "\nClient with Account Number (" << AccountNumber <<
			") is Not Found!";
	}

	return 0;
}

