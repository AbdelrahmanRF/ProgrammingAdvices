#pragma once

#include "clsCurrency.h"
#include "clsScreen.h"

class clsListCurrenciesScreen : protected clsScreen
{
    static void _PrintCurrencyRecord(clsCurrency Currency) {
        cout << setw(8) << left << "" << "| " << setw(30) << left << Currency.GetCountry();
        cout << "| " << setw(8) << left << Currency.GetCode();
        cout << "| " << setw(45) << left << Currency.GetName();
        cout << "| " << setw(10) << left << Currency.GetRate();
    }

public:

	static void ShowListCurrenciesScreen()
	{
        vector<clsCurrency> vCurrencies = clsCurrency::GetCurrenciesList();
        string Title = "\t  Currencies List Screen";
        string SubTitle = "\t    (" + to_string(vCurrencies.size()) + ") Currency.";

        _DrawScreenHeader(Title, SubTitle);

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "______________________________________________\n" << endl;

        cout << setw(8) << left << "" << "| " << left << setw(30) << "Country";
        cout << "| " << left << setw(8) << "Code";
        cout << "| " << left << setw(45) << "Name";
        cout << "| " << left << setw(10) << "Rate/(1$)";
        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "______________________________________________\n" << endl;

        if (vCurrencies.size() == 0)
            cout << "\t\t\t\tNo Currencies Available In the System!";
        else

            for (clsCurrency Currency : vCurrencies)
            {
                _PrintCurrencyRecord(Currency);
                cout << endl;
            }

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "______________________________________________\n" << endl;
	}
};

