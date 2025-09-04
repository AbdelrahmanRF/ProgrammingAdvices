#pragma once

#include <iomanip>
#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"

class clsClientListScreen : protected clsScreen
{
    static void _PrintClientRecordLine(clsBankClient BankClient) {
        cout << setw(8) << left << "" << "| " << setw(15) << left << BankClient.GetAccountNumber();
        cout << "| " << setw(20) << left << BankClient.GetFullName();
        cout << "| " << setw(12) << left << BankClient.Phone;
        cout << "| " << setw(20) << left << BankClient.Email;
        cout << "| " << setw(10) << left << BankClient.PinCode;
        cout << "| " << setw(12) << left << BankClient.Balance;
    }

public:

    static void ShowClientsList()
    {
        vector <clsBankClient> vClients = clsBankClient::GetClientsList();
        string Title = "\t  Client List Screen";
        string SubTitle = "\t    (" + to_string(vClients.size()) + ") Client(s).";

        _DrawScreenHeader(Title, SubTitle);

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

        cout << setw(8) << left << "" << "| " << left << setw(15) << "Account Number";
        cout << "| " << left << setw(20) << "Client Name";
        cout << "| " << left << setw(12) << "Phone";
        cout << "| " << left << setw(20) << "Email";
        cout << "| " << left << setw(10) << "Pin Code";
        cout << "| " << left << setw(12) << "Balance";
        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

        if (vClients.size() == 0)
            cout << "\t\t\t\tNo Clients Available In the System!";
        else

            for (clsBankClient Client : vClients)
            {

                _PrintClientRecordLine(Client);
                cout << endl;
            }

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "_________________________________________\n" << endl;

    }

};

