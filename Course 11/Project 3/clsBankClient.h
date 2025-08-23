#pragma once

#include <iostream>  
#include <string>  
#include "clsString.h"
#include "clsPerson.h"
#include "Global.h"
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

	string _PrepareTransferLogLine(float Amount, clsBankClient DestinationClient, string Separator = "#//#")
	{
		string TransferLogLine = "";

		TransferLogLine += clsDate::GetSystemDateTimeString() + Separator;

		TransferLogLine += GetAccountNumber() + Separator;
		TransferLogLine += DestinationClient.GetAccountNumber() + Separator;
		TransferLogLine += to_string(Amount) + Separator;
		TransferLogLine += to_string(Balance) + Separator;
		TransferLogLine += to_string(DestinationClient.Balance) + Separator;
		TransferLogLine += CurrentUser.Username;

		return TransferLogLine;
	}

	void _LogTransfer(double Amount, clsBankClient DestinationClient)
	{
		fstream TransferLogFile;

		TransferLogFile.open("TransferLog.txt", ios::out | ios::app);

		string LogLine = _PrepareTransferLogLine(Amount, DestinationClient);

		if (TransferLogFile.is_open())
		{
			TransferLogFile << LogLine << endl;

			TransferLogFile.close();
		}
	}

public:

	struct stTransferLog {
		string DateTime;
		string SourceAccNo;
		string DestinationAccNo;
		float Amount;
		float SourceBalance;
		float DestinationBalance;
		string Username;
	};

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

	void Deposit(double Amount)
	{
		_Balance += Amount;
		Save();
	}

	bool Withdraw(double Amount)
	{
		if (Amount > _Balance) return false;

		_Balance -= Amount;
		Save();
	}

	bool Transfer(double Amount, clsBankClient& DestinationClient)
	{
		if (Amount > _Balance) return false;

		Withdraw(Amount);

		DestinationClient.Deposit(Amount);

		_LogTransfer(Amount, DestinationClient);

		return true;
	}

	static stTransferLog ConvertLineToTransferLogObject(string Line, string Separator = "#//#") 
	{
		vector<string> vTransferLogs = clsString::Split(Line, Separator);
		stTransferLog TransferLog;

		TransferLog.DateTime = vTransferLogs[0];
		TransferLog.SourceAccNo = vTransferLogs[1];
		TransferLog.DestinationAccNo = vTransferLogs[2];
		TransferLog.Amount = stof(vTransferLogs[3]);
		TransferLog.SourceBalance = stof(vTransferLogs[4]);
		TransferLog.DestinationBalance = stof(vTransferLogs[5]);
		TransferLog.Username = vTransferLogs[6];

		return TransferLog;
	}

	static vector<stTransferLog> GetTransferLogsList()
	{
		fstream TransferLogFile;
		vector<stTransferLog> TransferLogs;

		TransferLogFile.open("TransferLog.txt", ios::in);

		if (TransferLogFile.is_open())
		{
			string Line;

			while (getline(TransferLogFile, Line))
			{
				TransferLogs.push_back(ConvertLineToTransferLogObject(Line));
			}

			TransferLogFile.close();
		}

		return TransferLogs;
	}

};

