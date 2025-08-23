#pragma once
#include <iostream>
#include <iomanip>
#include "clsUtil.h"
#include "clsInputValidate.h"
#include "clsScreen.h"
#include "clsBankClient.h"


class clsTransferLogScreen : protected clsScreen
{
	static void _PrintTransferLogRecord(clsBankClient::stTransferLog TransferLog) {
		cout << setw(8) << left << "" << "| " << setw(25) << left << TransferLog.DateTime;
		cout << "| " << setw(10) << left << TransferLog.SourceAccNo;
		cout << "| " << setw(10) << left << TransferLog.DestinationAccNo;
		cout << "| " << setw(10) << left << TransferLog.Amount;
		cout << "| " << setw(12) << left << TransferLog.SourceBalance;
		cout << "| " << setw(12) << left << TransferLog.DestinationBalance;
		cout << "| " << setw(10) << left << TransferLog.Username;
	}

public:
	static void ShowTransferLogScreen()
	{
		vector <clsBankClient::stTransferLog> vTransferLog = clsBankClient::GetTransferLogsList();
		string Title = "\t Transfer Log List Screen";
		string SubTitle = "\t     (" + to_string(vTransferLog.size()) + ") Record(s).";

		_DrawScreenHeader(Title, SubTitle);

		cout << setw(8) << left << "" << "\n\t_______________________________________________________";
		cout << "______________________________________________\n" << endl;

		cout << setw(8) << left << "" << "| " << left << setw(25) << "Date/Time";
		cout << "| " << left << setw(10) << "s.Acct";
		cout << "| " << left << setw(10) << "d.Acct";
		cout << "| " << left << setw(10) << "Amount";
		cout << "| " << left << setw(12) << "s.Balance";
		cout << "| " << left << setw(12) << "d.Balance";
		cout << "| " << left << setw(10) << "User";
		cout << setw(8) << left << "" << "\n\t_______________________________________________________";
		cout << "______________________________________________\n" << endl;

		if (vTransferLog.size() == 0)
			cout << "\t\t\t\tNo Transfers Available In the System!";
		else
			for (clsBankClient::stTransferLog T : vTransferLog)
			{
				_PrintTransferLogRecord(T);
				cout << endl;
			}

		cout << setw(8) << left << "" << "\n\t_______________________________________________________";
		cout << "______________________________________________\n" << endl;
	}
};

