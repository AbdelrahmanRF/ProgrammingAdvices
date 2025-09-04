#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"

class clsUpdateClientScreen : protected clsScreen
{
    static void _ReadClientInfo(clsBankClient& BankClient) {
        cout << "\nEnter FirstName: ";
        BankClient.FirstName = clsInputValidate::ReadString();

        cout << "\nEnter LastName: ";
        BankClient.LastName = clsInputValidate::ReadString();

        cout << "\nEnter Email: ";
        BankClient.Email = clsInputValidate::ReadString();

        cout << "\nEnter Phone: ";
        BankClient.Phone = clsInputValidate::ReadString();

        cout << "\nEnter PinCode: ";
        BankClient.PinCode = clsInputValidate::ReadString();

        cout << "\nEnter Balance: ";
        BankClient.Balance = clsInputValidate::ReadNumber<float>();

    }

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

    static void ShowUpdateClientScreen()
    {
        _DrawScreenHeader("\t Update Client Screen");

        string AccountNumber = "";

        cout << "\nPlease Enter client Account Number: ";
        AccountNumber = clsInputValidate::ReadString();

        while (!clsBankClient::IsClientExist(AccountNumber)) {
            cout << "\nAccount number is not found, choose another one: ";
            AccountNumber = clsInputValidate::ReadString();
        }

        clsBankClient BankClient = clsBankClient::Find(AccountNumber);
        _PrintClient(BankClient);

        cout << "\n\nUpdate Client Info:";
        cout << "\n____________________\n";


        _ReadClientInfo(BankClient);

        clsBankClient::enSaveResults SaveResults;

        SaveResults = BankClient.Save();

        switch (SaveResults) {
        case clsBankClient::enSaveResults::svSucceeded:
            cout << "\nAccount Updated Successfully :-)\n";
            _PrintClient(BankClient);
            break;
        case clsBankClient::enSaveResults::svFailedEmptyObject:
            cout << "\nError account was not saved because it's Empty";
            break;
        }
    }

};

