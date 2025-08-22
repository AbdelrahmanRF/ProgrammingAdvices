#pragma once

#include <iomanip>
#include <iostream>
#include "clsInputValidate.h"
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsDepositScreen.h"
#include "clsWithdrawScreen.h"
#include "clsTotalBalancesScreen.h"
//#include "clsMainScreen.h"


class clsTransactionsScreen : protected clsScreen
{
    static void _ShowDepositScreen() 
    {
        clsDepositScreen::ShowDepositScreen();
    }

    static void _ShowWithdrawScreen() 
    {
        clsWithdrawScreen::ShowWithdrawScreen();
    }

    static void _ViewTotalBalancesScreen() 
    {
        clsTotalBalancesScreen::ShowTotalBalancesScreen();
    }

    static void _BackToTransactionMenu() 
    {
        cout << "\nPress Any Key To Go Back To Transactions Menu...";
        system("pause>0");
        ShowTransactionsMenu();
    }

    static short _ReadUserOption(string Message)
    {
        cout << setw(37) << left << "" << Message;
        short Option = clsInputValidate::ReadNumberBetween(1, 8);

        return Option;
    }

    enum enTransactionsMenuOptions
    {
        eDeposit = 1,
        eWithdraw = 2,
        eShowTotalBalances = 3,
        eShowMainMenu = 4,
    };

    static void _PerformTransactionsMenuOption(enTransactionsMenuOptions TransactionsMenuOption)
    {
        switch (TransactionsMenuOption) {
        case eDeposit:
            system("cls");
            _ShowDepositScreen();
            _BackToTransactionMenu();
            break;

        case eWithdraw:
            system("cls");
            _ShowWithdrawScreen();
            _BackToTransactionMenu();
            break;

        case eShowTotalBalances :
            system("cls");
            _ViewTotalBalancesScreen();
            _BackToTransactionMenu();
            break;

        case eShowMainMenu:
            break;
        }
    }


public:

	static void ShowTransactionsMenu()
	{
        system("cls");

        _DrawScreenHeader("\t\tTransactions Screen");

        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\t\tTransactions Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1] Deposit.\n";
        cout << setw(37) << left << "" << "\t[2] Withdraw.\n";
        cout << setw(37) << left << "" << "\t[3] Total Balances.\n";
        cout << setw(37) << left << "" << "\t[4] Main Menu.\n";
        cout << setw(37) << left << "" << "===========================================\n";

        _PerformTransactionsMenuOption((enTransactionsMenuOptions)_ReadUserOption("What Do You Want To Do? [1 to 4]? "));
	}
};

