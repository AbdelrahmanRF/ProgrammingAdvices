#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <fstream>
using namespace std;

struct strClient {
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance = 0.000000;
	bool MarkForDelete = false;
};

const string ClientsFileName = "Clients.txt";
strClient CurrentClient;

void ShowMainMenu();
void Login();
void ShowQuickWithdrawScreen();
void ShowNormalWithdrawScreen();
void ShowDepositScreen();

enum enMainMenuOptions {
	eQuickWithdraw = 1, eNormalWithdraw = 2, eDeposit = 3, eCheckBalance = 4, eLogout = 5,
};

vector<string> Split(string S1, string Separator = "#//#") {
	vector<string> Words;
	string Word = "";
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
	vector<string> DataRecord = Split(Line);
	strClient Client;

	Client.AccountNumber = DataRecord[0];
	Client.PinCode = DataRecord[1];
	Client.Name = DataRecord[2];
	Client.Phone = DataRecord[3];
	Client.AccountBalance = stod(DataRecord[4]);

	return Client;
}

vector<strClient> GetClientsData(string FileName) {
	vector<strClient> Clients;
	fstream MyFile;

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

string ConvertRecordToLine(strClient Client, string Separator = "#//#") {
	string ClientRecord = "";

	ClientRecord += Client.AccountNumber + Separator;
	ClientRecord += Client.PinCode + Separator;
	ClientRecord += Client.Name + Separator;
	ClientRecord += Client.Phone + Separator;
	ClientRecord += to_string(Client.AccountBalance);

	return ClientRecord;
}

void UpdateClientsFile(string FileName, vector<strClient> Clients) {
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {
		string Line;
		for (strClient& Client : Clients) {
			Line = ConvertRecordToLine(Client);
			MyFile << Line << endl;
		}

		MyFile.close();
	}
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

short GetQuickWithdrawAmount(short QuickWithdrawOption) {
	switch (QuickWithdrawOption) {
	case 1:
		return 20;
	case 2:
		return 50;
	case 3:
		return 100;
	case 4:
		return 200;
	case 5:
		return 400;
	case 6:
		return 600;
	case 7:
		return 800;
	case 8:
		return 1000;
	default:
		return 0; 
	}
}

void PerformQuickWithdraw(short QuickWithdrawOption) {
	if (QuickWithdrawOption == 9)
		ShowMainMenu();

	short Amount = GetQuickWithdrawAmount(QuickWithdrawOption);

	if (Amount > CurrentClient.AccountBalance) {
		cout << "\nThe amount exceeds your balance, make another choice." << endl;
		cout << "Press Any key to continue..." << endl;
		system("pause>0");
		ShowQuickWithdrawScreen();
		return;
	}

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	if(DoDepositTransaction(CurrentClient.AccountNumber, Amount * -1, Clients))
		CurrentClient.AccountBalance -= Amount;
}

short ReadQuickWithdrawOption() {
	short Choice = 0;

	while (Choice < 1 || Choice > 9) {
		cout << "\nChoose what to withdraw from[1] to [8] or [9] to Exit? ";
		cin >> Choice;
	}

	return Choice;
}

void ShowQuickWithdrawScreen() {
	system("cls");
	cout << "\n================================================\n";
	cout << "\t\tQuick Withdraw";
	cout << "\n================================================\n";
	cout << "\t[1] 20\t\t[2] 50" << endl;
	cout << "\t[3] 100\t\t[4] 200" << endl;
	cout << "\t[5] 400\t\t[6] 600" << endl;
	cout << "\t[7] 800\t\t[8] 1000" << endl;
	cout << "\t[9] Exit" << endl;
	cout << "================================================\n";

	cout << "Your Balance is " << CurrentClient.AccountBalance << endl;

	PerformQuickWithdraw(ReadQuickWithdrawOption());
}

int ReadWithdrawAmount() {
	int Amount = 1;

	while (Amount % 5 != 0) {
		cout << "\nEnter an amount multiple of 5\'s ? ";
		cin >> Amount;
	}

	return Amount;
}

void PerformNormalWithdraw() {
	int Amount = ReadWithdrawAmount();

	if (Amount > CurrentClient.AccountBalance) {
		cout << "\nThe amount exceeds your balance, make another choice." << endl;
		cout << "Press Any key to continue..." << endl;
		system("pause>0");
		ShowNormalWithdrawScreen();
		return;
	}

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	if (DoDepositTransaction(CurrentClient.AccountNumber, Amount * -1, Clients))
		CurrentClient.AccountBalance -= Amount;
}

void ShowNormalWithdrawScreen() {
	system("cls");
	cout << "\n================================================\n";
	cout << "\t\tNormal Withdraw Screen";
	cout << "\n================================================\n";

	PerformNormalWithdraw();
}

double ReadDepositAmount() {
	double Amount = -1;

	while (Amount < 0) {
		cout << "\nEnter positive deposit Amount? ";
		cin >> Amount;
	}

	return Amount;
}

void PerformDeposit() {
	double Amount = ReadDepositAmount();

	vector<strClient> Clients = GetClientsData(ClientsFileName);
	if (DoDepositTransaction(CurrentClient.AccountNumber, Amount, Clients))
		CurrentClient.AccountBalance += Amount;
}

void ShowDepositScreen() {
	system("cls");
	cout << "\n================================================\n";
	cout << "\t\tDeposit Screen";
	cout << "\n================================================\n";

	PerformDeposit();
}

void ShowCheckBalanceScreen() {
	cout << "\n================================================\n";
	cout << "\t\tCheck Balance Screen";
	cout << "\n================================================\n";

	cout << "Your Balance is " << CurrentClient.AccountBalance << endl;
}

void BackToMainMenu() {
	cout << "\n\nPress Any Key To Go Back To Main Menu...";
	system("pause>0");
	ShowMainMenu();
}

short TakeUserChoice(string Message) {
	short Choice;
	cout << Message;
	cin >> Choice;

	return Choice;
}

void DoAction(enMainMenuOptions MainMenuOptions) {
	switch (MainMenuOptions) {
	case eQuickWithdraw:
		system("cls");
		ShowQuickWithdrawScreen();
		BackToMainMenu();
		break;

	case eNormalWithdraw:
		system("cls");
		ShowNormalWithdrawScreen();
		BackToMainMenu();
		break;

	case eDeposit:
		system("cls");
		ShowDepositScreen();
		BackToMainMenu();
		break;

	case eCheckBalance:
		system("cls");
		ShowCheckBalanceScreen();
		BackToMainMenu();
		break;

	case eLogout:
		system("cls");
		Login();
		break;
	}
}

void ShowMainMenu() {
	system("cls");
	cout << "================================================\n";
	cout << "\t\tTransaction Menu Screen\n";
	cout << "================================================\n";
	cout << "\t[1] Quick Withdraw.\n";
	cout << "\t[2] Normal Withdraw.\n";
	cout << "\t[3] Deposit.\n";
	cout << "\t[4] Check Balance.\n";
	cout << "\t[5] Logout.\n";
	cout << "================================================\n";

	DoAction((enMainMenuOptions)TakeUserChoice("What Do You Want To Do? [1 to 5]? "));
}

bool FindClientByAccountNumberAndPinCode(string AccountNumber, string PinCode, strClient& Client) {
	vector<strClient> Clients = GetClientsData(ClientsFileName);

	for (strClient& C : Clients) {
		if (C.AccountNumber == AccountNumber && C.PinCode == PinCode) {
			Client = C;
			return true;
		}
	}

	return false;
}

bool LoadClientInfo(string AccountNumber, string PinCode) 
{
	return FindClientByAccountNumberAndPinCode(AccountNumber, PinCode, CurrentClient);
}

void Login() {
	string AccountNumber, PinCode;
	bool LoginFailed = false;

	do {
		system("cls");

		cout << "\n-----------------------------------\n";
		cout << "\tLogin Screen";
		cout << "\n-----------------------------------\n";

		if(LoginFailed)
			cout << "Invalid Account Number/Pin Code\n";

		cout << "Enter Account Number? ";
		cin >> AccountNumber;

		cout << "Enter Pin Code? ";
		cin >> PinCode;

		LoginFailed = !LoadClientInfo(AccountNumber, PinCode);

	} while (LoginFailed);

	ShowMainMenu();
}

int main()
{
	Login();

	system("pause>0");
    return 0;
}

