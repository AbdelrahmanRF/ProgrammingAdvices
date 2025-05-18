#include <iostream>
#include <iomanip>
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

vector<string> Split(string S1, string Delimiter = "#//#") {
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

//short CountClientsRecords(string FileName) {
//	fstream MyFile;
//	short RecordsNumber = 0;
//	MyFile.open(ClientsFileName, ios::in);
//
//	if (MyFile.is_open()) {
//		string	Line;
//		while (getline(MyFile, Line)) {
//			RecordsNumber++;
//		}
//		MyFile.close();
//	}
//	return RecordsNumber;
//}

//void PrintRecordsTable() {
//	fstream MyFile;
//	strClient Client;
//
//	cout << "\t\t\tClint List (" << CountClientsRecords(ClientsFileName) << ") Client(s).\n";
//	cout << "------------------------------------------------------------------------------------------\n";
//	cout << "| Account Number\t" << "| Pin Code\t" << "| Client Name\t\t" << "| Phone\t\t" << "| Balance" << endl;
//	cout << "------------------------------------------------------------------------------------------\n";
//
//	MyFile.open(ClientsFileName, ios::in);
//	if (MyFile.is_open()) {
//		string Line;
//		while (getline(MyFile, Line)) {
//			Client = ConvertLineToRecord(Line);
//			
//			cout << Client.AccountNumber << "\t\t| " << Client.PinCode << "\t\t| " << Client.Name << "\t\t| " << Client.Phone << "\t| " << Client.AccountBalance << endl;
//		}
//		MyFile.close();
//	}
//
//	cout << "------------------------------------------------------------------------------------------\n";
//}

vector<strClient> LoadCleintsDataFromFile(string FileName) {
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

void PrintClientRecord(strClient Client) {
	cout << "| " << left << setw(15) << Client.AccountNumber;
	cout << "| " << left << setw(10) << Client.PinCode;
	cout << "| " << left << setw(40) << Client.Name;
	cout << "| " << left << setw(12) << Client.Phone;
	cout << "| " << left << setw(12) << Client.AccountBalance;
}

void PrintAllClientsData(vector<strClient> vClients) {
	cout << "\n\t\t\t\t\tClient List (" << vClients.size() << ") Client(s).";
	cout <<"\n_______________________________________________________";

	cout << "_________________________________________\n" << endl;
	cout << "| " << left << setw(15) << "Accout Number";
	cout << "| " << left << setw(10) << "Pin Code";
	cout << "| " << left << setw(40) << "Client Name";
	cout << "| " << left << setw(12) << "Phone";
	cout << "| " << left << setw(12) << "Balance";

	cout <<"\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	for (strClient& Client : vClients) {
		PrintClientRecord(Client);
		cout << endl;
	}
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
}

int main()
{
	/*PrintRecordsTable();*/

	vector<strClient> vClients = LoadCleintsDataFromFile(ClientsFileName);

	PrintAllClientsData(vClients);

	return 0;
}

