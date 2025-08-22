#pragma once


#include <iostream>
#include <iomanip>
#include "clsUtil.h"
#include "clsScreen.h"
#include "clsBankClient.h"

class clsTotalBalancesScreen : protected clsScreen
{
	static void _PrintClientRecordBalanceLine(clsBankClient BankClient) {
        cout << setw(25) << left << "" << "| " << setw(15) << left << BankClient.GetAccountNumber();
		cout << "| " << left << setw(40) << BankClient.GetFullName();
		cout << "| " << left << setw(12) << BankClient.Balance;
	}

public:

	static void ShowTotalBalancesScreen()
	{
        vector <clsBankClient> vClients = clsBankClient::GetClientsList();
        double TotalBalances = clsBankClient::GetTotalBalances();

        string Title = "\t  Total Balances Screen";
        string SubTitle = "\t    (" + to_string(vClients.size()) + ") Client(s).";

        _DrawScreenHeader(Title, SubTitle);

        cout << setw(25) << left << "" << "\n\t\t_______________________________________________________";
        cout << "__________________________\n" << endl;

        cout << setw(25) << left << "" << "| " << left << setw(15) << "Accout Number";
        cout << "| " << left << setw(40) << "Client Name";
        cout << "| " << left << setw(12) << "Balance";
        cout << setw(25) << left << "" << "\t\t_______________________________________________________";
        cout << "__________________________\n" << endl;

        if (vClients.size() == 0)
            cout << "\t\t\tNo Clients Available In the System!";
        else

            for (clsBankClient Client : vClients)
            {
                _PrintClientRecordBalanceLine(Client);
                cout << endl;
            }

        cout << setw(25) << left << "" << "\n\t\t_______________________________________________________";
        cout << "__________________________\n" << endl;


        cout << setw(8) << left << "" << "\t\t\t\t     Total Balances = " << TotalBalances << endl;
        cout << setw(8) << left << "" << "\t\t     ( " << clsUtil::ConvertNumberToText(TotalBalances) << ")";

	}

};

