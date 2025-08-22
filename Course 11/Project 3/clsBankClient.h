#pragma once

#include <iostream>  
#include <string>  
#include  "clsString.h"
#include  "clsPerson.h"
#include <vector>  
#include <fstream>  
using namespace std;

class clsBankClient : public clsPerson
{
	enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 };
	enMode _Mode;

	string _AccountNumber;
	string _PinCode;
	float _Balance;
	bool _MarkedForDelete = false;

	static clsBankClient _ConvertLineToClientObject(string Line, string Separator = "#//#") {
		vector<string> vClient = clsString::Split(Line, "#//#");

		return clsBankClient(enMode::UpdateMode, vClient[0], vClient[1], vClient[2], vClient[3], vClient[4], vClient[5], stof(vClient[6]));
	}

	static string _ConvertClientObjectToLine(clsBankClient Client, string Separator = "#//#") {
		string ClientDataLine = "";

		ClientDataLine = ClientDataLine + Client.FirstName + Separator;
		ClientDataLine = ClientDataLine + Client.LastName + Separator;
		ClientDataLine = ClientDataLine + Client.Email + Separator;
		ClientDataLine = ClientDataLine + Client.Phone + Separator;
		ClientDataLine = ClientDataLine + Client.GetAccountNumber() + Separator;
		ClientDataLine = ClientDataLine + Client.PinCode + Separator;
		ClientDataLine = ClientDataLine + to_string(Client.Balance);

		return ClientDataLine;
	}

	static clsBankClient _GetEmptyClientObject() {
		return clsBankClient(enMode::EmptyMode, "", "", "", "", "", "", 0.000000);
	}

	static vector<clsBankClient> _GetClientsData() {
		fstream ClientsFile;
		vector<clsBankClient> Clients;

		ClientsFile.open("Clients.txt", ios::in);

		if (ClientsFile.is_open()) {
			string Line;

			while (getline(ClientsFile, Line)) {
				Clients.push_back(_ConvertLineToClientObject(Line));
			}

			ClientsFile.close();
		}

		return Clients;
	}

	static void _SaveClientRecordsToFile(vector<clsBankClient>& Clients) {
		fstream ClientsFile;

		ClientsFile.open("Clients.txt", ios::out);

		if (ClientsFile.is_open()) {

			for (clsBankClient& Client : Clients) {
				if (!Client.MarkedForDelete())
				ClientsFile << _ConvertClientObjectToLine(Client) << endl;
			}

			ClientsFile.close();
		}
	}

	void _Update() {
		vector<clsBankClient> Clients = _GetClientsData();

		for (clsBankClient& C : Clients) {
			if (C.GetAccountNumber() == GetAccountNumber()) {
				C = *this;
				_SaveClientRecordsToFile(Clients);
				break;
			}
		}

	}

	static void _AddDataLineToFile(string Content) {
		fstream MyFile;

		MyFile.open("Clients.txt", ios::out | ios::app);

		if (MyFile.is_open()) {

			MyFile << Content << endl;

			MyFile.close();
		}
	}

	void _AddNew() {
		_AddDataLineToFile(_ConvertClientObjectToLine(*this));
	}

public:

	clsBankClient(enMode Mode, string FirstName, string LastName, string Email, string Phone, string AccountNumber, string PinCode, float Balance)
		: clsPerson(FirstName, LastName, Email, Phone) 
	{
		_Mode = Mode;
		_AccountNumber = AccountNumber;
		_PinCode = PinCode;
		_Balance = Balance;
	}

	bool isEmpty() {
		return _Mode == enMode::EmptyMode;
	}

	bool MarkedForDelete() {
		return _MarkedForDelete;
	}

	string GetAccountNumber()
	{
		return _AccountNumber;
	}

	void SetPinCode(string PinCode) {
		_PinCode = PinCode;
	}

	string GetPinCode()
	{
		return _PinCode;
	}

	__declspec(property(get = GetPinCode, put = SetPinCode)) string PinCode;

	void SetBalance(float Balance) {
		_Balance = Balance;
	}

	float GetBalance()
	{
		return _Balance;
	}

	__declspec(property(get = GetBalance, put = SetBalance)) float Balance;

	//void Print() {
	//	cout << "\nClient Card:\n";
	//	cout << "------------------------------------------------\n";
	//	cout << "FirstName                 : " << FirstName << endl;
	//	cout << "LastName                  : " << LastName << endl;
	//	cout << "FullName                  : " << GetFullName() << endl;
	//	cout << "Email                     : " << Email << endl;
	//	cout << "Phone                     : " << Phone << endl;
	//	cout << "Acc. Number               : " << _AccountNumber << endl;
	//	cout << "Pin Code                  : " << PinCode << endl;
	//	cout << "Balance                   : " << Balance << endl;
	//	cout << "------------------------------------------------\n";
	//}

	static clsBankClient Find(string AccountNumber) {
		fstream ClientsFile;
		clsBankClient BankClient = _GetEmptyClientObject();

		ClientsFile.open("Clients.txt", ios::in);

		if (ClientsFile.is_open()) {
			string Line;

			while (getline(ClientsFile, Line)) {
				BankClient = _ConvertLineToClientObject(Line);

				if (BankClient.GetAccountNumber() == AccountNumber) {
					ClientsFile.close();
					return BankClient;
				}
			}

			ClientsFile.close();
		}

		return _GetEmptyClientObject();
	}

	static clsBankClient Find(string AccountNumber, string PinCode) {
		clsBankClient BankClient = Find(AccountNumber);

		if (BankClient.isEmpty() || BankClient.PinCode != PinCode) {
			return _GetEmptyClientObject();
		}

		return BankClient;
	}

	static bool IsClientExist(string AccountNumber) {
		return !Find(AccountNumber).isEmpty();
	}

	static clsBankClient GetAddNewClientObject(string AccountNumber) {
		return clsBankClient(enMode::AddNewMode, "", "", "", "", AccountNumber, "", 0.000000);
	}

	enum enSaveResults { svFailedEmptyObject = 0, svSucceeded = 1, svFailedAccountNumberExist = 2 };

	enSaveResults Save() {
		switch (_Mode) {
		case enMode::EmptyMode:
			if (isEmpty())
				return enSaveResults::svFailedEmptyObject;

		case enMode::UpdateMode: 
			_Update();
			return enSaveResults::svSucceeded;

		case enMode::AddNewMode:
			if (clsBankClient::IsClientExist(_AccountNumber))
				return enSaveResults::svFailedAccountNumberExist;

			_AddNew();
			_Mode = enMode::UpdateMode;

			return enSaveResults::svSucceeded;
		}

	}

	bool Delete() {
		vector<clsBankClient> Clients = _GetClientsData();

		for (clsBankClient& C : Clients) {
			if (C.GetAccountNumber() == GetAccountNumber()) {
				C._MarkedForDelete = true;
				break;
			}
		}

		_SaveClientRecordsToFile(Clients);
		*this = _GetEmptyClientObject();

		return true;
	}

	static vector<clsBankClient> GetClientsList() {
		return _GetClientsData();
	}

	static double GetTotalBalances() {
		double TotalBalance = 0;
		vector<clsBankClient> Clients = _GetClientsData();

		for (clsBankClient& C : Clients) {
			TotalBalance += C.Balance;
		}

		return TotalBalance;
	}
};

