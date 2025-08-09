#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <fstream>
using namespace std;

const string ClientsFileName = "Clients.txt";

void ShowMainMenu();
void ShowTransactionMenu();

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

string ConvertRecordToLine(strClient Client, string Separator = "#//#") {
	string ClientRecord = "";

	ClientRecord += Client.AccountNumber + Separator;
	ClientRecord += Client.PinCode + Separator;
	ClientRecord += Client.Name + Separator;
	ClientRecord += Client.Phone + Separator;
	ClientRecord += to_string(Client.AccountBalance);

	return ClientRecord;
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
	vector<strClient> Clients = GetClientsData(ClientsFileName);

	cout << "\n\t\t\t\t\tClient List (" << Clients.size() << ") Client(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
	cout << "| " << left << setw(15) << "Account Number";
	cout << "| " << left << setw(10) << "Pin Code";
	cout << "| " << left << setw(40) << "Client Name";
	cout << "| " << left << setw(12) << "Phone";
	cout << "| " << left << setw(12) << "Balance";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	if (Clients.size() == 0)
		cout << "\t\t\tNo Clients Available in the system";
	else
		for (strClient& Client : Clients) {
			PrintClientRecord(Client);
			cout << endl;
		}
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
}

bool isAccountNumberExist(string AccNum, string FileName) {
	vector<strClient> Clients;
	fstream MyFile;
	MyFile.open(FileName, ios::in);

	if (MyFile.is_open()) {
		strClient Client;
		string Line;

		while (getline(MyFile, Line)) {
			Client = ConvertLineToRecord(Line);
			if (AccNum == Client.AccountNumber) {
				MyFile.close();
				return true;
			}
			Clients.push_back(Client);
		}

		MyFile.close();
	}

	return false;
}

bool FindClientByAccountNumber(string AccNum, vector<strClient>& Clients, strClient& Client) {
	for (strClient C : Clients) {
		if (C.AccountNumber == AccNum) {
			Client = C;
			return true;
		}
	}
	return false;
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

strClient ReadNewClient() {
	strClient Client;

	cout << "Enter Account Number? ";
	getline(cin >> ws, Client.AccountNumber);

	while (isAccountNumberExist(Client.AccountNumber, ClientsFileName)) {
		cout << "Client With [" << Client.AccountNumber << "] Exists, Enter Another Account Number? ";
		getline(cin >> ws, Client.AccountNumber);
	}

	Client = ReadClient(Client.AccountNumber);

	return Client;

}

void AddDataLineToFile(string FileName, string DataLine) {
	fstream MyFile;

	MyFile.open(FileName, ios::out | ios::app);

	if (MyFile.is_open()) {
		MyFile << DataLine << endl;

		MyFile.close();
	}
}

void AddNewClient() {
	strClient Client;
	Client = ReadNewClient();
	AddDataLineToFile(ClientsFileName, ConvertRecordToLine(Client));
}

void AddNewClients() {
	char AddNew = 'n';

	do {
		cout << "Adding New Client:\n\n";

		AddNewClient();
		cout << "Client Added Successfully, Do You Want To Add More Clients? Y/N? ";
		cin >> AddNew;

	} while (AddNew == 'Y' || AddNew == 'y');

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

void MarkClientForDelete(string AccNum, vector<strClient>& Clients) {
	for (strClient& C : Clients) {
		if (C.AccountNumber == AccNum)
			C.MarkForDelete = true;
	}
}

void UpdateClientsFile(string FileName, vector<strClient> Clients) {
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {
		string Line;
		for (strClient C : Clients) {
			if (!C.MarkForDelete) {
				Line = ConvertRecordToLine(C);
				MyFile << Line << endl;
			}
		}

		MyFile.close();
	}
}

bool DeleteClient(string AccNum, vector<strClient>& Clients) {
	strClient Client;
	char Confirm = 'n';

	if (FindClientByAccountNumber(AccNum, Clients, Client)) {

		PrintClientData(Client);
		cout << "\nAre you sure you want delete this client? y/n ? ";
		cin >> Confirm;

		if (Confirm == 'Y' || Confirm == 'y') {
			MarkClientForDelete(Client.AccountNumber, Clients);
			UpdateClientsFile(ClientsFileName, Clients);

			Clients = GetClientsData(ClientsFileName);

			cout << "\nClient deleted Successfully\n";
			return true;
		}
	}
	else {
		cout << "Client With [" << Client.AccountNumber << "] Doesn\'t Exist!";
		return false;
	}

}

string ReadAccountNumber() {
	string AccNum;
	cout << "Enter Account Number? ";
	getline(cin >> ws, AccNum);

	return AccNum;
}

void ShowDeleteClientScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tDelete Client Screen";
	cout << "\n-----------------------------------\n";

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	string AccNum = ReadAccountNumber();
	DeleteClient(AccNum, Clients);
}

void UpdateClientRecord(string AccNum, vector<strClient>& Clients) {
	for (strClient& C : Clients) {
		if (C.AccountNumber == AccNum) {
			C = ReadClient(AccNum);
			break;
		}
	}
}

bool UpdateClientInfo(string AccNum, vector<strClient>& Clients) {
	strClient Client;
	char Confirm = 'n';


	if (FindClientByAccountNumber(AccNum, Clients, Client)) {

		PrintClientData(Client);
		cout << "\nAre you sure you want update this client? y/n ? ";
		cin >> Confirm;

		if (Confirm == 'Y' || Confirm == 'y') {
			UpdateClientRecord(AccNum, Clients);
			UpdateClientsFile(ClientsFileName, Clients);

			Clients = GetClientsData(ClientsFileName);
			cout << "\nClient Updated Successfully\n";
		}
	}
	else {
		cout << "Client With [" << Client.AccountNumber << "] Doesn\'t Exist!";
		return false;
	}

}

void ShowUpdateClientScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tUpdate Client Info Screen";
	cout << "\n-----------------------------------\n";

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	string AccNum = ReadAccountNumber();
	UpdateClientInfo(AccNum, Clients);
}

void ShowFindClientScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tFind Client Screen";
	cout << "\n-----------------------------------\n";

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	strClient Client;
	string AccNum = ReadAccountNumber();

	if (FindClientByAccountNumber(AccNum, Clients, Client)) {
		PrintClientData(Client);
	}
	else {
		cout << "\nClient With [" << AccNum << "] Doesn\'t Exist!";
	}
}

double ReadAmount(string Message) {
	double Amount;
	cout << Message;
	cin >> Amount;

	return Amount;
}

bool DoDepositTransaction(string AccNum, double Amount, vector<strClient>& Clients) {
	char Confirm = 'n';

	cout << "\nAre you sure you want perform this transaction? y/n ? ";
	cin >> Confirm;

	if (toupper(Confirm) == 'Y') {

		for (strClient& C : Clients) {
			if (C.AccountNumber == AccNum) {
				C.AccountBalance = C.AccountBalance + Amount;
				UpdateClientsFile(ClientsFileName, Clients);
				cout << "\nDone Successfully, New Balance is: " << C.AccountBalance << endl;
				return true;
			}
		}
	}
	return false;
}

void MakeDeposit(string AccNum, vector<strClient>& Clients) {
	strClient Client;
	int Amount = 0;
	
	while (!FindClientByAccountNumber(AccNum, Clients, Client)) {
		cout << "Client With [" << AccNum << "] Doesn\'t Exists\nEnter Another Account Number? ";
		getline(cin >> ws, AccNum);
	}

	PrintClientData(Client);
	Amount = ReadAmount("Please Enter Deposit Amount? ");

	DoDepositTransaction(AccNum, Amount, Clients);
	
}

void ShowDepositScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tDeposit Screen";
	cout << "\n-----------------------------------\n";

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	string AccNum = ReadAccountNumber();
	MakeDeposit(AccNum, Clients);
}

void MakeWithdraw(string AccNum, vector<strClient>& Clients) {
	strClient Client;
	int Amount = 0;

	while (!FindClientByAccountNumber(AccNum, Clients, Client)) {
		cout << "Client With [" << AccNum << "] Doesn\'t Exists\nEnter Another Account Number? ";
		getline(cin >> ws, AccNum);
	}

	PrintClientData(Client);
	Amount = ReadAmount("Please Enter Withdraw Amount? ");

	while (Amount > Client.AccountBalance) {
		cout << "Amount Exceeds the balance, you can withdraw up to: " << Client.AccountBalance << endl;
		Amount = ReadAmount("Please Enter Another Amount? ");
	}

	DoDepositTransaction(AccNum, Amount * -1, Clients);

}

void ShowWithdrawScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tWithdraw Screen";
	cout << "\n-----------------------------------\n";

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	string AccNum = ReadAccountNumber();
	MakeWithdraw(AccNum, Clients);
}

void PrintClientBalanceRecord(strClient Client) {
	cout << "| " << left << setw(15) << Client.AccountNumber;
	cout << "| " << left << setw(40) << Client.Name;
	cout << "| " << left << setw(12) << Client.AccountBalance;
}

void ViewTotalBalancesScreen() {
	vector<strClient> Clients = GetClientsData(ClientsFileName);
	double Total = 0;

	cout << "\n\t\t\t\tBalances List (" << Clients.size() << ") Client(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
	cout << "| " << left << setw(15) << "Account Number";
	cout << "| " << left << setw(40) << "Client Name";
	cout << "| " << left << setw(12) << "Balance";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	if (Clients.size() == 0)
		cout << "\t\t\tNo Clients Available in the system";
	else
		for (strClient& Client : Clients) {
			PrintClientBalanceRecord(Client);
			Total += Client.AccountBalance;
			cout << endl;
		}
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n";
	cout << "\n\t\t\t\tTotal Balances = " << Total;

}

void BackToMainMenu() {
	cout << "\n\nPress Any Key To Go Back To Main Menu...";
	system("pause>0");
	ShowMainMenu();
}

void BackToTransactionMenu() {
	cout << "\n\nPress Any Key To Go Back To Transactions Menu...";
	system("pause>0");
	ShowTransactionMenu();
}

short TakeUserChoice(string Message) {
	short Choice;
	cout << Message;
	cin >> Choice;

	return Choice;
}

enum enTransactionMenuOptions {
	eMakeDeposit = 1,
	eMakeWithdraw = 2,
	eViewTotalBalances = 3,
	eOpenMainMenu = 4,
};

void DoTransactionAction(enTransactionMenuOptions TransactionMenuOption) {
	switch (TransactionMenuOption) {
	case eMakeDeposit:
		system("cls");
		ShowDepositScreen();
		BackToTransactionMenu();
		break;

	case eMakeWithdraw:
		system("cls");
		ShowWithdrawScreen();
		BackToTransactionMenu();
		break;

	case eViewTotalBalances:
		system("cls");
		ViewTotalBalancesScreen();
		BackToTransactionMenu();
		break;

	case eOpenMainMenu:
		system("cls");
		ShowMainMenu();
		break;
	}
}

void ShowTransactionMenu() {
	system("cls");
	cout << "================================================\n";
	cout << "\t\tMain Menu Screen\n";
	cout << "================================================\n";
	cout << "\t[1] Deposit.\n";
	cout << "\t[2] Withdraw.\n";
	cout << "\t[3] Total Balances.\n";
	cout << "\t[4] Main Menu.\n";
	cout << "================================================\n";

	DoTransactionAction((enTransactionMenuOptions)TakeUserChoice("What Do You Want To Do? [1 to 4]? "));
}

void ShowEndProgramScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tProgram Ends :-)";
	cout << "\n-----------------------------------\n";
}

enum enMainMenuOptions {
	eListClient = 1,
	eAddNewClient = 2,
	eDeleteClient = 3,
	eUpdateClient = 4,
	eFindClient = 5,
	eOpenTransactionMenu = 6,
	eExit = 7,
};

void DoAction(enMainMenuOptions MainMenuOption) {
	switch (MainMenuOption) {
	case eListClient:
		system("cls");
		ShowClientList();
		BackToMainMenu();
		break;

	case eAddNewClient:
		system("cls");
		ShowAddNewClientsScreen();
		BackToMainMenu();
		break;

	case eDeleteClient:
		system("cls");
		ShowDeleteClientScreen();
		BackToMainMenu();
		break;

	case eUpdateClient:
		system("cls");
		ShowUpdateClientScreen();
		BackToMainMenu();
		break;

	case eFindClient:
		system("cls");
		ShowFindClientScreen();
		BackToMainMenu();
		break;

	case eOpenTransactionMenu:
		system("cls");
		ShowTransactionMenu();
		break;

	case eExit:
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
	cout << "\t[6] Transactions.\n";
	cout << "\t[7] Exit.\n";
	cout << "================================================\n";

	DoAction((enMainMenuOptions)TakeUserChoice("What Do You Want To Do? [1 to 7]? "));
}

int main()
{
	ShowMainMenu();
	system("pause>0");
	return 0;
}

