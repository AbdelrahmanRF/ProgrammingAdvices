#pragma once

#include <iomanip>
#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"

class clsFindClientScreen : protected clsScreen
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
	static void ShowFindClientScreen() 
	{
		_DrawScreenHeader("\t Find Client Screen");

        string AccountNumber = "";

        cout << "\nPlease Enter client Account Number: ";
        AccountNumber = clsInputValidate::ReadString();

        while (!clsBankClient::IsClientExist(AccountNumber)) {
            cout << "\nAccount number is not found, choose another one: ";
            AccountNumber = clsInputValidate::ReadString();
        }

        clsBankClient BankClient = clsBankClient::Find(AccountNumber);

        if (!BankClient.isEmpty()) 
        {
            cout << "\nClient Found :-)\n";
        }
        else {
            cout << "\nClient is not Found :-(\n";

        }

        _PrintClient(BankClient);

	}
};

