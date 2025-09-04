#pragma once

#include "clsCurrency.h"
#include "clsScreen.h"
#include "clsInputValidate.h"


class clsUpdateCurrencyRateScreen : protected clsScreen
{

	static void _PrintCurrency(clsCurrency Currency)
	{
		cout << "\nCurrency Card:\n";
		cout << "_____________________________\n";
		cout << "\nCountry    : " << Currency.GetCountry();
		cout << "\nCode       : " << Currency.GetCode();
		cout << "\nName       : " << Currency.GetName();
		cout << "\nRate(1$) = : " << Currency.GetRate();

		cout << "\n_____________________________\n";
	}

public:

	static void ShowUpdateCurrencyRateScreen()
	{
		_DrawScreenHeader("\t  Update Currency Screen");

        string CurrencyCode = "";
        char Confirm = 'n';

        cout << "\nPlease Currency Code: ";
        CurrencyCode = clsInputValidate::ReadString();

        while (!clsCurrency::IsCurrencyExist(CurrencyCode)) {
            cout << "\nCurrency is not found, choose another one: ";
            CurrencyCode = clsInputValidate::ReadString();
        }

        clsCurrency Currency = clsCurrency::FindByCode(CurrencyCode);
        _PrintCurrency(Currency);

        cout << "\nAre You sure you want to update the rate of this Currency? (y/n) ";
        cin >> Confirm;

        if (Confirm == 'Y' || Confirm == 'y')
        {
            cout << "\n\nUpdate Currency Rate:";
            cout << "\n____________________\n";
            cout << "\nEnter New Rate: ";

            float NewRate = clsInputValidate::ReadNumber<float>();

            Currency.UpdateRate(NewRate);

            cout << "\nCurrency Updated Succssfuly :-)\n";
            _PrintCurrency(Currency);

        }

	}
};

