#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <fstream>
using namespace std;

const string UsersFileName = "Users.txt";
const string ClientsFileName = "Clients.txt";

enum enMainMenuPermissions
{
	eAll = -1, pListClients = 1, pAddNewClient = 2, pDeleteClient = 4, pUpdateClients = 8, pFindClient = 16, pTranactions = 32, pManageUsers = 64
};
void ShowMainMenu(short Permissions = -1);
void ShowTransactionMenu(short Permissions = -1);
void ShowManageUsersMenu(short Permissions = -1);

void Login();

struct strClient {
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double AccountBalance = 0.000000;
	bool MarkForDelete = false;
};

struct strUser {
	string Username;
	string Password;
	short Permissions;
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
		cout << "\nClient Added Successfully, Do You Want To Add More Clients? Y/N? ";
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
		cout << "Client With [" << AccNum << "] Doesn\'t Exist!";
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
		cout << "Client With [" << AccNum << "] Doesn\'t Exist!";
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

strUser ConvertLineToUserRecord(string Line) {
	strUser User;
	vector<string> UserData = Split(Line);

	User.Username = UserData[0];
	User.Password = UserData[1];
	User.Permissions = stoi(UserData[2]);

	return User;
}

string ConvertUserRecordToLine(strUser User, string Separator = "#//#") {
	string UserRecord = "";

	UserRecord += User.Username + Separator;
	UserRecord += User.Password + Separator;
	UserRecord += to_string(User.Permissions);

	return UserRecord;
}

vector<strUser> GetUsersData(string FileName) {
	fstream MyFile;
	vector<strUser> vUsers;

	MyFile.open(FileName, ios::in);
	if (MyFile.is_open()) {
		string Line;
		strUser User;
		while (getline(MyFile, Line)) {
			User = ConvertLineToUserRecord(Line);
			vUsers.push_back(User);
		}

		MyFile.close();
	}

	return vUsers;
}

void PrintUserRecord(strUser Users) {
	cout << "| " << left << setw(15) << Users.Username;
	cout << "| " << left << setw(15) << Users.Password;
	cout << "| " << left << setw(12) << Users.Permissions;
}

void ShowListUsersScreen() {
	vector<strUser> Users = GetUsersData(UsersFileName);

	cout << "\n\t\t\t\tBalances List (" << Users.size() << ") Users(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
	cout << "| " << left << setw(15) << "Username";
	cout << "| " << left << setw(15) << "Password";
	cout << "| " << left << setw(12) << "Permissions";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	if (Users.size() == 0)
		cout << "\t\t\tNo Users Available in the system";
	else
		for (strUser& User : Users) {
			PrintUserRecord(User);
			cout << endl;
		}
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n";
}

bool isUsernameExist(string Username, string FileName) {
	vector<strUser> Users = GetUsersData(UsersFileName);

	for (strUser& U : Users) {
		if (U.Username == Username)
			return true;
	}
	return false;
}

short ReadPermissionsSet() {
	short Permissions = 0;
	char Answer = 'n';

	cout << "\n\nDo you want to give full access? y/n? ";
	cin >> Answer;

	if (toupper(Answer) == 'Y') return -1;

	cout << "\nDo you want to give access to :" << endl;

	cout << "Show Client List? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pListClients;

	cout << "Add New Client? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pAddNewClient;

	cout << "Delete Client? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pDeleteClient;

	cout << "Update Client? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pUpdateClients;

	cout << "Find Client? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pFindClient;

	cout << "Transactions? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pTranactions;

	cout << "Manage Users? y/n? ";
	cin >> Answer;
	if (toupper(Answer) == 'Y') Permissions += pManageUsers;

	return Permissions;
}

strUser ReadNewUser() {
	strUser User;

	cout << "Enter Username? ";
	getline(cin >> ws, User.Username);

	while (isUsernameExist(User.Username, UsersFileName)) {
		cout << "User With [" << User.Username << "] Exists, Enter Another Username? ";
		getline(cin >> ws, User.Username);
	}

	cout << "Enter Password? ";
	getline(cin , User.Password);

	User.Permissions = ReadPermissionsSet();

	return User;
}

void AddNewUser() {
	strUser User;
	User = ReadNewUser();
	AddDataLineToFile(UsersFileName, ConvertUserRecordToLine(User));
}

void AddNewUsers() {
	char AddNew = 'n';

	do {
		cout << "Adding New User:\n\n";

		AddNewUser();
		cout << "User Added Successfully, Do You Want To Add More Users? Y/N? ";
		cin >> AddNew;

	} while (AddNew == 'Y' || AddNew == 'y');
}

void ShowAddNewUserScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tAdd New User Screen";
	cout << "\n-----------------------------------\n";

	AddNewUsers();
}

void PrintUserData(strUser User) {
	cout << "\nThe following are the user details:\n";
	cout << "-------------------------------------\n";
	cout << "Username   : " << User.Username << endl;
	cout << "Password   : " << User.Password << endl;
	cout << "Permissions: " << User.Permissions << endl;
	cout << "-------------------------------------\n\n";
}

void MarkUserForDelete(string Username, vector<strUser>& Users) {
	for (strUser& U : Users) {
		if (U.Username == Username)
			U.MarkForDelete = true;
	}
}

void UpdateUsersFile(string FileName, vector<strUser> Users) {
	fstream MyFile;

	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {
		string Line;
		for (strUser& U : Users) {
			if (!U.MarkForDelete) {
				Line = ConvertUserRecordToLine(U);
				MyFile << Line << endl;
			}
		}

		MyFile.close();
	}
}

bool FindUserByUsername(string Username, vector<strUser>& Users, strUser& User) {
	for (strUser& U : Users) {
		if (U.Username == Username) {
			User = U;
			return true;
		}
	}
	return false;
}

string ReadUsername() {
	string Username;
	cout << "Enter Username? ";
	cin >> Username;

	return Username;
}

bool DeleteUser(string Username, vector<strUser>& Users) {
	strUser User;
	char Confirm = 'n';

	if (FindUserByUsername(Username, Users, User)) {
		if (Username == "Admin") {
			cout << "\nYou cannot delete this user.";
			return false;
		}

		PrintUserData(User);
		cout << "\nAre you sure you want delete this user? y/n ? ";
		cin >> Confirm;

		if (Confirm == 'Y' || Confirm == 'y') {
			MarkUserForDelete(User.Username, Users);
			UpdateUsersFile(UsersFileName, Users);

			Users = GetUsersData(UsersFileName);

			cout << "\nUser deleted Successfully\n";
			return true;
		}
	}
	else {
		cout << "User With [" << Username << "] Doesn\'t Exist!";
		return false;
	}

}

void ShowDeleteUserScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tDelete User Screen";
	cout << "\n-----------------------------------\n";

	vector<strUser> Users = GetUsersData(UsersFileName);
	string Username = ReadUsername();
	DeleteUser(Username, Users);
}

void UpdateUserRecord(string Username, vector<strUser>& Users) {
	for (strUser& U : Users) {
		if (U.Username == Username) {
			cout << "Enter Password? ";
			cin >> U.Password;
			U.Permissions = ReadPermissionsSet();

			break;
		}
	}
}

bool UpdateUser(string Username, vector<strUser>& Users) {
	strUser User;
	char Confirm = 'n';


	if (FindUserByUsername(Username, Users, User)) {

		if (Username == "Admin") {
			cout << "\nYou cannot update this user.";
			return false;
		}

		PrintUserData(User);
		cout << "\nAre you sure you want update this user? y/n ? ";
		cin >> Confirm;

		if (Confirm == 'Y' || Confirm == 'y') {
			UpdateUserRecord(Username, Users);
			UpdateUsersFile(UsersFileName, Users);

			Users = GetUsersData(UsersFileName);

			cout << "\nUser updated Successfully\n";
			return true;
		}
	}
	else {
		cout << "User With [" << Username << "] Doesn\'t Exist!";
		return false;
	}

}

void ShowUpdateUserScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tUpdate User Screen";
	cout << "\n-----------------------------------\n";

	vector<strUser> Users = GetUsersData(UsersFileName);
	string Username = ReadUsername();
	UpdateUser(Username, Users);
}

void ShowFindUserScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tFind User Screen";
	cout << "\n-----------------------------------\n";

	vector<strUser> Users = GetUsersData(UsersFileName);
	strUser User;
	string Username = ReadUsername();

	if (FindUserByUsername(Username, Users, User)) {
		PrintUserData(User);
	}
	else {
		cout << "\nClient With [" << Username << "] Doesn\'t Exist!";
	}
}

void BackToMainMenu(short Permissions = -1) {
	cout << "\n\nPress Any Key To Go Back To Main Menu...";
	system("pause>0");
	ShowMainMenu(Permissions);
}

void BackToTransactionMenu(short Permissions = -1) {
	cout << "\n\nPress Any Key To Go Back To Transactions Menu...";
	system("pause>0");
	ShowTransactionMenu(Permissions);
}

void BackToManageUsersMenu(short Permissions = -1) {
	cout << "\n\nPress Any Key To Go Back To Manage Users Menu...";
	system("pause>0");
	ShowManageUsersMenu(Permissions);
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

void DoTransactionAction(enTransactionMenuOptions TransactionMenuOption, short Permissions) {
	switch (TransactionMenuOption) {
	case eMakeDeposit:
		system("cls");
		ShowDepositScreen();
		BackToTransactionMenu(Permissions);
		break;

	case eMakeWithdraw:
		system("cls");
		ShowWithdrawScreen();
		BackToTransactionMenu(Permissions);
		break;

	case eViewTotalBalances:
		system("cls");
		ViewTotalBalancesScreen();
		BackToTransactionMenu(Permissions);
		break;

	case eOpenMainMenu:
		system("cls");
		ShowMainMenu(Permissions);
		break;
	}
}

void ShowTransactionMenu(short Permissions) {
	system("cls");
	cout << "================================================\n";
	cout << "\t\tTransaction Menu Screen\n";
	cout << "================================================\n";
	cout << "\t[1] Deposit.\n";
	cout << "\t[2] Withdraw.\n";
	cout << "\t[3] Total Balances.\n";
	cout << "\t[4] Main Menu.\n";
	cout << "================================================\n";

	DoTransactionAction((enTransactionMenuOptions)TakeUserChoice("What Do You Want To Do? [1 to 4]? "), Permissions);
}

enum enManageUsersMenuOptions {
	eListUsers = 1,
	eAddNewUser = 2,
	eDeleteUser = 3,
	eUpdateUser = 4,
	eFindUser = 5,
	eMainMenu = 6,
};

void DoManageUserAction(enManageUsersMenuOptions ManageUsersMenuOption, short Permissions) {
	switch (ManageUsersMenuOption) {
	case eListUsers:
		system("cls");
		ShowListUsersScreen();
		BackToManageUsersMenu(Permissions);
		break;

	case eAddNewUser:
		system("cls");
		ShowAddNewUserScreen();
		BackToManageUsersMenu(Permissions);
		break;

	case eDeleteUser:
		system("cls");
		ShowDeleteUserScreen();
		BackToManageUsersMenu(Permissions);
		break;

	case eUpdateUser:
		system("cls");
		ShowUpdateUserScreen();
		BackToManageUsersMenu(Permissions);
		break;

	case eFindUser:
		system("cls");
		ShowFindUserScreen();
		BackToManageUsersMenu(Permissions);
		break;

	case eMainMenu:
		system("cls");
		ShowMainMenu(Permissions);
		break;
	}
}

void ShowManageUsersMenu(short Permissions) {
	system("cls");
	cout << "================================================\n";
	cout << "\t\tManage Users Menu Screen\n";
	cout << "================================================\n";
	cout << "\t[1] List Users.\n";
	cout << "\t[2] Add New User.\n";
	cout << "\t[3] Delete User.\n";
	cout << "\t[4] Update User.\n";
	cout << "\t[5] Find User.\n";
	cout << "\t[6] Main Menu.\n";
	cout << "================================================\n";

	DoManageUserAction((enManageUsersMenuOptions)TakeUserChoice("What Do You Want To Do? [1 to 6]? "), Permissions);
}

void ShowLoginScreen() {
	cout << "\n-----------------------------------\n";
	cout << "\tLogin Screen";
	cout << "\n-----------------------------------\n";

}

void ShowAccessDeniedScreen() {
	cout << "\n-----------------------------------\n";
	cout << "Access Denied," << endl;
	cout << "You dont Have Permission" << endl;
	cout << "Please Conact Your Admin." << endl;
	cout << "\n-----------------------------------\n";
}

enum enMainMenuOptions {
	eListClient = 1,
	eAddNewClient = 2,
	eDeleteClient = 3,
	eUpdateClient = 4,
	eFindClient = 5,
	eOpenTransactionMenu = 6,
	eManageUsers = 7,
	eLogout = 8,
};

enMainMenuPermissions GetRequiredPermission(enMainMenuOptions MainMenuOption) {
	switch (MainMenuOption) {
	case eListClient:
		return pListClients;
	case eAddNewClient:
		return pAddNewClient;
	case eDeleteClient:
		return pDeleteClient;
	case eUpdateClient:
		return pUpdateClients;
	case eFindClient:
		return pFindClient;
	case eOpenTransactionMenu:
		return pTranactions;
	case eManageUsers:
		return pManageUsers;
	default:
		return eAll;
	}
	return eAll;
}

void DoAction(enMainMenuOptions MainMenuOption, short Permissions = -1) {
	enMainMenuPermissions RequiredPermission = GetRequiredPermission(MainMenuOption);

	if (MainMenuOption == eLogout || Permissions == -1 || (Permissions & RequiredPermission))
		switch (MainMenuOption) {
		case eListClient:
			system("cls");
			ShowClientList();
			BackToMainMenu(Permissions);
			break;

		case eAddNewClient:
			system("cls");
			ShowAddNewClientsScreen();
			BackToMainMenu(Permissions);
			break;

		case eDeleteClient:
			system("cls");
			ShowDeleteClientScreen();
			BackToMainMenu(Permissions);
			break;

		case eUpdateClient:
			system("cls");
			ShowUpdateClientScreen();
			BackToMainMenu(Permissions);
			break;

		case eFindClient:
			system("cls");
			ShowFindClientScreen();
			BackToMainMenu(Permissions);
			break;

		case eOpenTransactionMenu:
			system("cls");
			ShowTransactionMenu(Permissions);
			break;

		case eManageUsers:
			system("cls");
			ShowManageUsersMenu(Permissions);
			break;

		case eLogout:
			system("cls");
			Login();
			break;
		}
	else {
		system("cls");
		ShowAccessDeniedScreen();
		BackToMainMenu(Permissions);
	}
}

void ShowMainMenu(short Permissions) {
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
	cout << "\t[7] Manage Users.\n";
	cout << "\t[8] Logout.\n";
	cout << "================================================\n";

	DoAction((enMainMenuOptions)TakeUserChoice("What Do You Want To Do? [1 to 8]? "), Permissions);
}

bool FindUserByUsernameAndPassword(string Username, string Password, strUser& CurrentUser) {
	vector<strUser> vUsers = GetUsersData(UsersFileName);

	for (strUser U : vUsers) {
		if (U.Username == Username && U.Password == Password) {
			CurrentUser = U;
			return true;
		}
	}

	return false;
}

bool isValidUserCredentials(string Username, string Password, strUser& CurrentUser) {

	if (FindUserByUsernameAndPassword(Username, Password, CurrentUser))
		return true;
	else 
		return false;
}

void Login() {
	strUser CurrentUser;
	string Username, Password;
	bool InvalidAttempt = false;

	do {
		system("cls");
		ShowLoginScreen();

		if (InvalidAttempt) {
			cout << "Invalid Username/Password\n";
		}
		cout << "Enter Username? ";
		cin >> Username;

		cout << "Enter Password? ";
		cin >> Password;

		if (isValidUserCredentials(Username, Password, CurrentUser))
			break;
		else 
			InvalidAttempt = true;
		
	} while (true);

	ShowMainMenu(CurrentUser.Permissions);
}

int main()
{
	Login();

	system("pause>0");
	return 0;
}

