#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <fstream>
using namespace std;

const string ClientsFileName = "Clients.txt";
void ShowMainMenu();
struct strClient {
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance = 0.000000;
	bool MarkForDelete = false;
};

vector<string> Split(string Str, string Separator = "#//#") {
	vector<string> Words;
	string Word = "";
	short Pos = 0;

	while ((Pos = Str.find(Separator)) != string::npos) {
		Word = Str.substr(0, Pos);

		if (Word != "") {
			Words.push_back(Word);
		}
		Str.erase(0, Pos + Separator.length());
	}

	if (Str != "") {
		Words.push_back(Str);
	}

	return Words;
}

strClient ConvertLineToRecord(string Line) {
	strClient Client;
	vector<string> ClientData = Split(Line);

	Client.AccountNumber = ClientData[0];
	Client.PinCode = ClientData[1];
	Client.Name = ClientData[2];
	Client.Phone = ClientData[3];
	Client.AccountBalance = stod(ClientData[4]);

	return Client;
}

vector<strClient> GetClientsData(string FileName) {
	fstream MyFile;
	vector<strClient> vClients;

	MyFile.open(FileName, ios::in);
	if (MyFile.is_open()) {
		string Line;
		strClient Client;
		while (getline(MyFile, Line)) {
			Client = ConvertLineToRecord(Line);
			vClients.push_back(Client);
		}

		MyFile.close();
	}

	return vClients;
}

void PrintClientRecord(strClient Client) {
	cout << "| " << left << setw(15) << Client.AccountNumber;
	cout << "| " << left << setw(10) << Client.PinCode;
	cout << "| " << left << setw(40) << Client.Name;
	cout << "| " << left << setw(12) << Client.Phone;
	cout << "| " << left << setw(12) << Client.AccountBalance;
}

void ShowClientList() {
	vector<strClient> Clinets = GetClientsData(ClientsFileName);

	cout << "\n\t\t\t\t\tClient List (" << Clinets.size() << ") Client(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
	cout << "| " << left << setw(15) << "Account Number";
	cout << "| " << left << setw(10) << "Pin Code";
	cout << "| " << left << setw(40) << "Client Name";
	cout << "| " << left << setw(12) << "Phone";
	cout << "| " << left << setw(12) << "Balance";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	for (strClient& Client : Clinets) {
		PrintClientRecord(Client);
		cout << endl;
	}
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
}

bool isAccountNumberExist(string AccNum, strClient& Client , vector<strClient>& Clients) {
	for (strClient& C : Clients) {
		if (C.AccountNumber == AccNum) {
			Client = C;
			return true;
		}
	}
	return false;
}

string ReadAccountNumber() {
	string AccNum;
	cout << "Enter Account Number? ";
	getline(cin, AccNum);

	return AccNum;
}

strClient ReadClient(string AccNum) {
	strClient Client;

	Client.AccountNumber = AccNum;

	cout << "Enter Pin Code? ";
	getline(cin, Client.PinCode);

	cout << "Enter Name? ";
	getline(cin, Client.Name);

	cout << "Enter Phone? ";
	getline(cin, Client.Phone);

	cout << "Enter Account Balance? ";
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

void SaveClientRecordsToFile(vector<strClient>& Clients, string FileName) {
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {
		string Line;
		for (strClient& Client : Clients) {
			if (Client.MarkForDelete == false) {
				Line = ConvertRecordToLine(Client);
				MyFile << Line << endl;
			}
		}
		MyFile.close();
	}

}

void AddNewClients() {
	vector<strClient> Clients = GetClientsData(ClientsFileName);
	strClient Client;
	string AccNum = "";
	char AddNew = 'Y';

	cout << "Adding New Client:\n\n";

	do {
		AccNum = ReadAccountNumber();

		while (isAccountNumberExist(AccNum, Client, Clients)) {
			cout << "Client With [" << AccNum << "] Exists, Enter Another Account Number? ";
			getline(cin, AccNum);
		}

		Client = ReadClient(AccNum);
		Clients.push_back(Client);
		SaveClientRecordsToFile(Clients, ClientsFileName);

		cout << "Client Added Successfully, Do You Want To Add More Clients? Y/N? ";
		cin >> AddNew;
		cin.ignore();

	} while (toupper(AddNew) == 'Y');
	
}

void ShowAddNewClientsScreen()
{
	cout << "\n-----------------------------------\n";
	cout << "\tAdd New Clients Screen";
	cout << "\n-----------------------------------\n";
	AddNewClients();
}

void PrintClientData(strClient Client) {
	cout << "\nThe following are the client details:\n";
	cout << "-------------------------------------\n";
	cout << "Account Number: " << Client.AccountNumber << endl;
	cout << "Pin Code      : " << Client.PinCode << endl;
	cout << "Name          : " << Client.Name << endl;
	cout << "Phone         : " << Client.Phone << endl;
	cout << "Account Balance: " << Client.AccountBalance << endl;
	cout << "-------------------------------------\n\n";
}

void FlagClientRecord(string AccNum, vector<strClient>& Clients) {
	for (strClient& C : Clients) {
		if (C.AccountNumber == AccNum) {
			C.MarkForDelete = true;
		}
	}
}

void DeleteClient() {
	string AccNum;
	strClient Client;
	vector<strClient> Clients = GetClientsData(ClientsFileName);
	char Confirm = 'Y';

	AccNum = ReadAccountNumber();
	while (!isAccountNumberExist(AccNum, Client, Clients)) {
		cout << "Client With [" << AccNum << "] Doesn\'t Exist, Try Again? ";
		getline(cin, AccNum);
	}

	PrintClientData(Client);
	cout << "\nAre you sure you want delete this client? y/n ? ";
	cin >> Confirm;
	cin.ignore();

	if (Confirm == 'Y' || Confirm == 'y') {
		cout << endl;
		FlagClientRecord(AccNum, Clients);
		cout << "\nClient deleted Successfully\n";
		SaveClientRecordsToFile(Clients, ClientsFileName);
	}
}

void ShowDeleteClientScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tDelete Client Screen";
	cout << "\n-----------------------------------\n";
	DeleteClient();
}

void UpdateClientRecord(string AccNum, vector<strClient>& Clients) {
	for (strClient& C : Clients) {
		if (C.AccountNumber == AccNum) {
			C = ReadClient(AccNum);
		}
	}
}

void UpdateClientInfo() {
	string AccNum;
	strClient Client;
	vector<strClient> Clients = GetClientsData(ClientsFileName);
	char Confirm = 'Y';

	AccNum = ReadAccountNumber();
	while (!isAccountNumberExist(AccNum, Client, Clients)) {
		cout << "Client With [" << AccNum << "] Doesn\'t Exist, Try Again? ";
		getline(cin, AccNum);
	}

	PrintClientData(Client);
	cout << "\nAre you sure you want update this client? y/n ? ";
	cin >> Confirm;
	cin.ignore();

	if (Confirm == 'Y' || Confirm == 'y') {
		cout << endl;
		UpdateClientRecord(AccNum, Clients);
		cout << "\nClient Updated Successfully\n";
		SaveClientRecordsToFile(Clients, ClientsFileName);
	}
}

void ShowUpdateClientScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tUpdate Client Info Screen";
	cout << "\n-----------------------------------\n";
	UpdateClientInfo();
}

void FindClient() {
	string AccNum;
	strClient Client;
	vector<strClient> Clients = GetClientsData(ClientsFileName);

	AccNum = ReadAccountNumber();

	if (isAccountNumberExist(AccNum, Client, Clients)) {
		PrintClientData(Client);
	}
	else {
		cout << "\nClient With [" << AccNum << "] Doesn\'t Exist!";
	}
}

void ShowFindClientScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tFind Client Screen";
	cout << "\n-----------------------------------\n";
	FindClient();
}

void ShowEndProgramScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tProgram Ends :-)";
	cout << "\n-----------------------------------\n";
}

void BackToMainMenu() {
	cout << "\n\nPress Any Key To Go Back To Main Menu...";
	system("pause>0");
	ShowMainMenu();
}

short TakeUserChoice() {
	short Choice;
	cout << "What Do You Want To Do? [1 to 6]? ";
	cin >> Choice;
	cin.ignore();

	return Choice;
}

void DoAction(short Choice) {
	switch (Choice) {
	case 1: 
		system("cls");
		ShowClientList();
		BackToMainMenu();
		break;

	case 2:
		system("cls");
		ShowAddNewClientsScreen();
		BackToMainMenu();
		break;

	case 3:
		system("cls");
		ShowDeleteClientScreen();
		BackToMainMenu();
		break;

	case 4:
		system("cls");
		ShowUpdateClientScreen();
		BackToMainMenu();
		break;

	case 5:
		system("cls");
		ShowFindClientScreen();
		BackToMainMenu();
		break;

	case 6:
		system("cls");
		ShowEndProgramScreen();
		break;
	}
}

void ShowMainMenu() {
	system("cls");
	cout << "================================================\n";
	cout << "\t\tMain Menu Screen\n";
	cout << "================================================\n";
	cout << "\t[1] Show Client List.\n";
	cout << "\t[2] Add New Client.\n";
	cout << "\t[3] Delete Client.\n";
	cout << "\t[4] Update Client Info.\n";
	cout << "\t[5] Find Client.\n";
	cout << "\t[6] Exit.\n";
	cout << "================================================\n";

	DoAction(TakeUserChoice());
}


int main()
{
	ShowMainMenu();
	system("pause>0");
	return 0;
}

