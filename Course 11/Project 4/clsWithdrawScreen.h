#pragma once

#include <iostream>
#include "clsInputValidate.h"
#include "clsScreen.h"
#include "clsBankClient.h"

class clsWithdrawScreen : protected clsScreen
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

    static string _ReadAccountNumber()
    {
        string AccountNumber = "";
        cout << "\nPlease enter Account Number? ";
        cin >> AccountNumber;

        return AccountNumber;
    }

public:
    static bool ShowWithdrawScreen()
    {
        _DrawScreenHeader("\tWithdraw Screen");

        string AccountNumber = _ReadAccountNumber();

        while (!clsBankClient::IsClientExist(AccountNumber)) {
            cout << "\nClient With [" << AccountNumber << "] Doesn\'t Exists.\n";
            AccountNumber = _ReadAccountNumber();
        }

        clsBankClient BankClient = clsBankClient::Find(AccountNumber);
        _PrintClient(BankClient);

        double Amount = 0;
        cout << "\nPlease Enter Withdraw Amount? ";
        Amount = clsInputValidate::ReadNumber<double>();

        char Confirm = 'n';
        cout << "\nAre you sure you want to perform this transaction? ";
        cin >> Confirm;

        if (!(Confirm == 'Y' || Confirm == 'y'))
        {
            cout << "\nOperation cancelled\n";
            return false;
        };


        if (BankClient.Withdraw(Amount)) {
            cout << "\nAmount Withdrawn Successfully.\n";
            cout << "\nNew Balance Is: " << BankClient.Balance << endl;
        }
        else
        {
            cout << "\nCannot withdraw, Insufficient Balance!\n";
            cout << "\nAmount to withdraw is: " << Amount << endl;
            cout << "Your Balance is: " << BankClient.Balance << endl;
        }

    }
};

