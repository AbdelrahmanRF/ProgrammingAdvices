#pragma once

#include <iomanip>
#include <iostream>
#include "clsInputValidate.h"
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsDepositScreen.h"
#include "clsWithdrawScreen.h"
#include "clsTotalBalancesScreen.h"
#include "clsTransferScreen.h"
#include "clsTransferLogScreen.h"

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

    static void _ShowTotalBalancesScreen()
    {
        clsTotalBalancesScreen::ShowTotalBalancesScreen();
    }

    static void _ShowTransferScreen()
    {
        clsTransferScreen::ShowTransferScreen();
    }

    static void _ShowTransferLogScreen()
    {
        clsTransferLogScreen::ShowTransferLogScreen();
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
        short Option = clsInputValidate::ReadNumberBetween(1, 6);

        return Option;
    }

    enum enTransactionsMenuOptions
    {
        eDeposit = 1,
        eWithdraw = 2,
        eShowTotalBalances = 3,
        eTransfer = 4,
        eTransferLog = 5,
        eShowMainMenu = 6,
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

        case eShowTotalBalances:
            system("cls");
            _ShowTotalBalancesScreen();
            _BackToTransactionMenu();
            break;

        case eTransfer:
            system("cls");
            _ShowTransferScreen();
            _BackToTransactionMenu();
            break;

        case eTransferLog:
            system("cls");
            _ShowTransferLogScreen();
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

        _DrawScreenHeader("\tTransactions Screen");

        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\tTransactions Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1] Deposit.\n";
        cout << setw(37) << left << "" << "\t[2] Withdraw.\n";
        cout << setw(37) << left << "" << "\t[3] Total Balances.\n";
        cout << setw(37) << left << "" << "\t[4] Transfer.\n";
        cout << setw(37) << left << "" << "\t[5] Transfer Log.\n";
        cout << setw(37) << left << "" << "\t[6] Main Menu.\n";
        cout << setw(37) << left << "" << "===========================================\n";

        _PerformTransactionsMenuOption((enTransactionsMenuOptions)_ReadUserOption("What Do You Want To Do? [1 to 6]? "));
    }
};

