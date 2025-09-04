#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsListCurrenciesScreen.h"
#include "clsFindCurrencyScreen.h"
#include "clsUpdateCurrencyRateScreen.h"
#include "clsCurrencyCalculatorScreen.h"

class clsCurrencyExchangeScreen : protected clsScreen
{

    static void _ShowListCurrenciesScreen()
    {
        clsListCurrenciesScreen::ShowListCurrenciesScreen();
    }

    static void _ShowFindCurrencyScreen()
    {
        clsFindCurrencyScreen::ShowFindCurrencyScreen();
    }

    static void _ShowUpdateRateScreen()
    {
        clsUpdateCurrencyRateScreen::ShowUpdateCurrencyRateScreen();
    }

    static void _ShowCurrencyCalculatorScreen()
    {
        clsCurrencyCalculatorScreen::ShowCurrencyCalculatorScreen();
    }

    static void _GoBackToCurrencyExchangeMenu()
    {
        cout << "\nPress Any Key To Go Back To Currency Exchange Menu...";
        system("pause>0");
        ShowCurrencyExchangeScreen();
    }


    static short _ReadUserOption(string Message)
    {
        cout << setw(37) << left << "" << Message;
        short Option = clsInputValidate::ReadNumberBetween(1, 5);

        return Option;
    }

    enum enCurrencyExchangeMenuOptions
    {
        eListCurrencies = 1, eFindCurrency = 2, eUpdateRate = 3,
        eCurrencyCalculator = 4, eMainMenu = 5
    };

    static void _PerformCurrencyExchangeMenuOption(enCurrencyExchangeMenuOptions CurrencyExchangeMenuOption)
    {
        switch (CurrencyExchangeMenuOption)
        {

        case eListCurrencies:
            system("cls");
            _ShowListCurrenciesScreen();
            _GoBackToCurrencyExchangeMenu();
            break;

        case eFindCurrency:
            system("cls");
            _ShowFindCurrencyScreen();
            _GoBackToCurrencyExchangeMenu();
            break;

        case eUpdateRate:
            system("cls");
            _ShowUpdateRateScreen();
            _GoBackToCurrencyExchangeMenu();
            break;

        case eCurrencyCalculator:
            system("cls");
            _ShowCurrencyCalculatorScreen();
            _GoBackToCurrencyExchangeMenu();
            break;

        case eMainMenu:
            break;
        }
    }

public:

    static void ShowCurrencyExchangeScreen()
    {
        system("cls");

        _DrawScreenHeader("   Currency Exchange Main Screen");

        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\tCurrency Exchange Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1] List Currencies.\n";
        cout << setw(37) << left << "" << "\t[2] Find Currency.\n";
        cout << setw(37) << left << "" << "\t[3] Update Rate.\n";
        cout << setw(37) << left << "" << "\t[4] Currency Calculator.\n";
        cout << setw(37) << left << "" << "\t[5] Main Menu.\n";
        cout << setw(37) << left << "" << "===========================================\n";

        _PerformCurrencyExchangeMenuOption((enCurrencyExchangeMenuOptions)_ReadUserOption("What Do You Want To Do? [1 to 5]? "));

    }
};

