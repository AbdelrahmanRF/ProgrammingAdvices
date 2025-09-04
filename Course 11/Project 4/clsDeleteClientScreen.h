#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"

class clsDeleteClientScreen : protected clsScreen
{
    static void _PrintClient(clsBankClient BankClient)
    {
        cout << "\nClient Card:\n";
        cout << "------------------------------------------------\n";
        cout << "FirstName                 : " << BankClient.FirstName << endl;
        cout << "LastName                  : " << BankClient.LastName << endl;
        cout << "FullName                  : " << BankClient.GetFullName() << endl;
        cout << "Email                     : " << BankClient.Email << endl;
        cout << "Phone                     : " << BankClient.Phone << endl;
        cout << "Acc. Number               : " << BankClient.GetAccountNumber() << endl;
        cout << "Pin Code                  : " << BankClient.PinCode << endl;
        cout << "Balance                   : " << BankClient.Balance << endl;
        cout << "------------------------------------------------\n";
    }

public:

    static void ShowDeleteClientScreen()
    {
        _DrawScreenHeader("\t Delete Client Screen");


        string AccountNumber = "";
        char Confirm = 'n';

        cout << "\nPlease Enter client Account Number: ";
        AccountNumber = clsInputValidate::ReadString();

        while (!clsBankClient::IsClientExist(AccountNumber)) {
            cout << "\nAccount number is not found, choose another one: ";
            AccountNumber = clsInputValidate::ReadString();
        }

        clsBankClient BankClient = clsBankClient::Find(AccountNumber);
        _PrintClient(BankClient);

        cout << "\nAre You sure you want to delete this client? (y/n) ";
        cin >> Confirm;

        if (Confirm == 'Y' || Confirm == 'y') {
            if (BankClient.Delete()) {
                cout << "\nClient Deleted Successfully :-)\n";
                _PrintClient(BankClient);
            }
            else {
                cout << "\nError Client Was not Deleted\n";
            }
        }
    }
};

