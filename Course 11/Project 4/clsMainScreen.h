#pragma once

#include <iomanip>
#include <iostream>
#include <vector>
#include "clsUtil.h"
#include "clsInputValidate.h"
#include "clsScreen.h"
#include "clsClientListScreen.h"
#include "clsBankClient.h"
#include "clsAddNewClientScreen.h"
#include "clsDeleteClientScreen.h"
#include "clsUpdateClientScreen.h"
#include "clsFindClientScreen.h"
#include "clsTransactionsScreen.h"
#include "clsManageUsersScreen.h"
#include "Global.h"
#include "clsUser.h"
#include "clsLoginRegisterScreen.h"
#include "clsCurrencyExchangeScreen.h"

class clsMainScreen : protected clsScreen
{
    static void _ShowAllClientsScreen()
    {
        clsClientListScreen::ShowClientsList();
    };

    static void _ShowAddNewClientsScreen()
    {
        clsAddNewClientScreen::ShowAddNewClientsScreen();
    };

    static void _ShowDeleteClientScreen()
    {
        clsDeleteClientScreen::ShowDeleteClientScreen();
    };

    static void _ShowUpdateClientScreen()
    {
        clsUpdateClientScreen::ShowUpdateClientScreen();
    };

    static void _ShowFindClientScreen()
    {
        clsFindClientScreen::ShowFindClientScreen();
    };

    static void _ShowTransactionsMenu()
    {
        clsTransactionsScreen::ShowTransactionsMenu();
    };

    static void _ShowManageUsersMenu()
    {
        clsManageUsersScreen::ShowManageUsersMenu();
    };

    static void _ShowLoginRegisterScreen()
    {
        clsLoginRegisterScreen::ShowLoginRegisterScreen();
    };

    static void _ShowCurrencyExchangeScreen()
    {
        clsCurrencyExchangeScreen::ShowCurrencyExchangeScreen();
    };

    static void _Logout()
    {
        CurrentUser = clsUser::Find("", "");
    }

    static void _ShowAccessDeniedScreen()
    {
        _DrawScreenHeader("Access Denied, Contact Your Admin.");
    }

    static void _BackToMainMenu()
    {
        cout << "\nPress Any Key To Go Back To Main Menu...";
        system("pause>0");
        ShowMainMenu();
    };

    static short _ReadUserOption(string Message)
    {
        cout << setw(37) << left << "" << Message;
        short Option = clsInputValidate::ReadNumberBetween(1, 10);

        return Option;
    }

    enum enMainMenuOptions
    {
        eListClient = 1,
        eAddNewClient = 2,
        eDeleteClient = 3,
        eUpdateClient = 4,
        eFindClient = 5,
        eOpenTransactionsMenu = 6,
        eManageUsers = 7,
        eLoginRegister = 8,
        eCurrencyExchange = 9,
        eLogout = 10
    };

    static clsUser::enPermissions GetRequiredPermission(enMainMenuOptions MainMenuOption) {
        switch (MainMenuOption) {
        case eListClient:
            return clsUser::enPermissions::pListClients;

        case eAddNewClient:
            return clsUser::enPermissions::pAddNewClient;

        case eDeleteClient:
            return clsUser::enPermissions::pDeleteClient;

        case eUpdateClient:
            return clsUser::enPermissions::pUpdateClients;

        case eFindClient:
            return clsUser::enPermissions::pFindClient;

        case eOpenTransactionsMenu:
            return clsUser::enPermissions::pTransactions;

        case eManageUsers:
            return clsUser::enPermissions::pManageUsers;

        case eCurrencyExchange:
            return clsUser::enPermissions::pCurrencyExchange;

        case eLoginRegister:
            return clsUser::enPermissions::pLoginRegister;

        default:
            return clsUser::enPermissions::eAll;
        }
        return clsUser::enPermissions::eAll;
    }

    static void _PerformMainMenuOption(enMainMenuOptions MainMenuOption)
    {
        clsUser::enPermissions RequiredPermission = GetRequiredPermission(MainMenuOption);

        if (MainMenuOption == eLogout || CurrentUser.Permissions == -1 || (CurrentUser.Permissions & RequiredPermission))
        {
            switch (MainMenuOption) {
            case eListClient:
                system("cls");
                _ShowAllClientsScreen();
                _BackToMainMenu();
                break;

            case eAddNewClient:
                system("cls");
                _ShowAddNewClientsScreen();
                _BackToMainMenu();
                break;

            case eDeleteClient:
                system("cls");
                _ShowDeleteClientScreen();
                _BackToMainMenu();
                break;

            case eUpdateClient:
                system("cls");
                _ShowUpdateClientScreen();
                _BackToMainMenu();
                break;

            case eFindClient:
                system("cls");
                _ShowFindClientScreen();
                _BackToMainMenu();
                break;

            case eOpenTransactionsMenu:
                system("cls");
                _ShowTransactionsMenu();
                _BackToMainMenu();
                break;

            case eManageUsers:
                system("cls");
                _ShowManageUsersMenu();
                _BackToMainMenu();
                break;

            case eLoginRegister:
                system("cls");
                _ShowLoginRegisterScreen();
                _BackToMainMenu();
                break;

            case eCurrencyExchange:
                system("cls");
                _ShowCurrencyExchangeScreen();
                _BackToMainMenu();
                break;

            case eLogout:
                system("cls");
                _Logout();
                break;
            }
        }
        else
        {
            system("cls");
            _ShowAccessDeniedScreen();
            _BackToMainMenu();
        }
    }

public:

    static void ShowMainMenu()
    {
        system("cls");

        _DrawScreenHeader("\t\tMain Screen");

        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\t\tMain Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1] Show Client List.\n";
        cout << setw(37) << left << "" << "\t[2] Add New Client.\n";
        cout << setw(37) << left << "" << "\t[3] Delete Client.\n";
        cout << setw(37) << left << "" << "\t[4] Update Client Info.\n";
        cout << setw(37) << left << "" << "\t[5] Find Client.\n";
        cout << setw(37) << left << "" << "\t[6] Transactions.\n";
        cout << setw(37) << left << "" << "\t[7] Manage Users.\n";
        cout << setw(37) << left << "" << "\t[8] Login Register.\n";
        cout << setw(37) << left << "" << "\t[9] Currency Exchange.\n";
        cout << setw(37) << left << "" << "\t[10] Logout.\n";
        cout << setw(37) << left << "" << "===========================================\n";

        _PerformMainMenuOption((enMainMenuOptions)_ReadUserOption("What Do You Want To Do? [1 to 10]? "));
    }
};

