#pragma once
#include <iostream>
#include <iomanip>
#include "clsUtil.h"
#include "clsInputValidate.h"
#include "clsScreen.h"
#include "clsBankClient.h"

class clsTransferScreen : protected clsScreen
{
    static void _PrintClient(clsBankClient BankClient)
    {
        cout << "\nClient Card:\n";
        cout << "------------------------------------------------\n";
        cout << "FullName                  : " << BankClient.GetFullName() << endl;
        cout << "Acc. Number               : " << BankClient.GetAccountNumber() << endl;
        cout << "Balance                   : " << BankClient.Balance << endl;
        cout << "------------------------------------------------\n";
    }

    static string _ReadAccountNumber(string TransferDirection)
    {
        string AccountNumber = "";

        cout << "\nPlease Enter client Account Number To Transfer " << TransferDirection << ": ";
        AccountNumber = clsInputValidate::ReadString();

        while (!clsBankClient::IsClientExist(AccountNumber)) {
            cout << "\nAccount number is not found, choose another one: ";
            AccountNumber = clsInputValidate::ReadString();
        }

        return AccountNumber;
    }

    static float ReadAmount(clsBankClient SourceClient)
    {
        float Amount;

        cout << "Enter Transfer Amount? ";
        Amount = clsInputValidate::ReadNumber<float>();

        while (Amount > SourceClient.Balance) {
            cout << "\nAmount Exceeds the available Balance, Enter another: ";
            Amount = clsInputValidate::ReadNumber<float>();
        }

        return Amount;
    }

public:

    static bool ShowTransferScreen()
    {
        _DrawScreenHeader("\t Transfer Screen");

        string FromAccountNumber = "";
        string ToAccountNumber = "";
        float Amount;
        char Confirm = 'n';


        FromAccountNumber = _ReadAccountNumber("From");
        clsBankClient SourceClient = clsBankClient::Find(FromAccountNumber);
        _PrintClient(SourceClient);

        ToAccountNumber = _ReadAccountNumber("To");
        clsBankClient DestinationClient = clsBankClient::Find(ToAccountNumber);
        _PrintClient(DestinationClient);

        Amount = ReadAmount(SourceClient);

        cout << "\nAre you sure you want to perform this transaction? ";
        cin >> Confirm;

        if (!(Confirm == 'Y' || Confirm == 'y'))
        {
            cout << "\nOperation cancelled\n";
            return false;
        };

        if (SourceClient.Transfer(Amount, DestinationClient))
        {
            cout << "\nTransfer Done Successfully.\n";
        }
        else
        {
            cout << "\nTransfer Failed.\n";
        }

        _PrintClient(SourceClient);
        _PrintClient(DestinationClient);

    }

};

