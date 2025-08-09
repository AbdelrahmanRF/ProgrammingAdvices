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

void UpdateClientsFile(string FileName) {
	vector<strClient> Clients = GetClientsData(FileName);
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {
		string Line;
		for (strClient& Client : Clients) {
			if (Client.AccountNumber == CurrentClient.AccountNumber) 
				Line = ConvertRecordToLine(CurrentClient);
			else
				Line = ConvertRecordToLine(Client);

			MyFile << Line << endl;
		}

		MyFile.close();
	}
}

void PrintBalance() {
	cout << "Your Balance is " << CurrentClient.AccountBalance << endl;
}

void PrintQuickWithdrawChoices() {
	cout << setw(10) << " " << left << setw(15) << "[1] 20" << left << setw(25) << "[2] 50" << endl;
	cout << setw(10) << " " << left << setw(15) << "[3] 100" << left << setw(25) << "[4] 200" << endl;
	cout << setw(10) << " " << left << setw(15) << "[5] 400" << left << setw(25) << "[6] 600" << endl;
	cout << setw(10) << " " << left << setw(15) << "[7] 800" << left << setw(25) << "[8] 1000" << endl;
	cout << setw(10) << " " << left << setw(15) << "[9] Exit" << endl;
}

bool MakeWithdraw(double Amount) {
	CurrentClient.AccountBalance -= Amount;
	UpdateClientsFile(ClientsFileName);

	return true;
}

void PerformQuickWithdraw() {
	double Amount = 0;
	char Answer = 'n';
	short ItemIndex = 0;
	double TransactionAmounts[8] = { 20, 50, 100, 200, 400, 600, 800, 1000 };
	bool WithdrawFailed = false;

	do {
		system("cls");
		cout << "\n================================================\n";
		cout << "\t\tQuick Withdraw";
		cout << "\n================================================\n";
		PrintQuickWithdrawChoices();
		cout << "================================================\n";

		PrintBalance();
		ItemIndex = 0;

		while (ItemIndex < 1 || ItemIndex > 9) {
			cout << "\nChoose what to withdraw from[1] to [8] ? ";
			cin >> ItemIndex;
			Amount = TransactionAmounts[ItemIndex - 1];
		}

		if (ItemIndex == 9)
			ShowMainMenu();

		WithdrawFailed = Amount > CurrentClient.AccountBalance;

		if (WithdrawFailed) {
			cout << "\nThe amount exceeds your balance, make another choice." << endl;
			cout << "Press Any key to continue..." << endl;
			system("pause>0");
		}
		else {
			cout << "\nAre you sure you want perfrom this transaction? y/n ? ";
			cin >> Answer;

			if (toupper(Answer) == 'Y') {
				MakeWithdraw(Amount);
				cout << "\nDone Successfully. New balance is: " << CurrentClient.AccountBalance;
			}
		}

	} while (WithdrawFailed);

}

void ShowQuickWithdrawScreen() {
	cout << "\n================================================\n";
	cout << "\t\tQuick Withdraw";
	cout << "\n================================================\n";

	PerformQuickWithdraw();
}

void PerformNormalWithdraw() {
	double Amount = 1;
	char Answer = 'n';
	bool WithdrawFailed = false;

	do {
		system("cls");
		cout << "\n================================================\n";
		cout << "\t\tNormal Withdraw Screen";
		cout << "\n================================================\n";
		Amount = 1;

		while ((int)Amount % 5 != 0) {
			cout << "\nEnter an amount multiple of 5\'s ? ";
			cin >> Amount;
		}

		WithdrawFailed = Amount > CurrentClient.AccountBalance;

		if (WithdrawFailed) {
			cout << "\nThe amount exceeds your balance, make another choice." << endl;
			cout << "Press Any key to continue..." << endl;
			system("pause>0");
		}
		else {
			cout << "\nAre you sure you want perfrom this transaction? y/n ? ";
			cin >> Answer;

			if (toupper(Answer) == 'Y') {
				MakeWithdraw(Amount);
				cout << "\nDone Successfully. New balance is: " << CurrentClient.AccountBalance;
			}
		}

	} while (WithdrawFailed);
}

void ShowNormalWithdrawScreen() {
	cout << "\n================================================\n";
	cout << "\t\tNormal Withdraw Screen";
	cout << "\n================================================\n";

	PerformNormalWithdraw();
}

void PerformDeposit() {
	double Amount = -1;
	char Answer = 'n';

	while (Amount < 0) {
		cout << "\nEnter positive deposit Amount? ";
		cin >> Amount;
	}

	cout << "\nAre you sure you want perfrom this transaction? y/n ? ";
	cin >> Answer;

	if (toupper(Answer) == 'Y') {
		MakeWithdraw(Amount * -1);
		cout << "\nDone Successfully. New balance is: " << CurrentClient.AccountBalance;
	}
}

void ShowDepositScreen() {
	cout << "\n================================================\n";
	cout << "\t\tDeposit Screen";
	cout << "\n================================================\n";

	PerformDeposit();
}

void ShowCheckBalanceScreen() {
	cout << "\n================================================\n";
	cout << "\t\tCheck Balance Screen";
	cout << "\n================================================\n";

	PrintBalance();
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

