#pragma once

#include "clsCurrency.h"
#include "clsScreen.h"
#include "clsInputValidate.h"

class clsFindCurrencyScreen : protected clsScreen
{
	static short _ReadUserOption(string Message)
	{
		cout << Message;
		short Option = clsInputValidate::ReadNumberBetween(1, 2);

		return Option;
	}

	static void _ShowResult(clsCurrency Currency)
	{
		if (!Currency.IsEmpty())
		{
			cout << "\nCurrency Found :-)\n";
		}
		else
		{
			cout << "\nCurrency Not Found :-(\n";
		}

		_PrintCurrency(Currency);
	}

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

	static void ShowFindCurrencyScreen()
	{
		_DrawScreenHeader("\t  Find Currency Screen");

		short UserChoice = _ReadUserOption("Find By: [1] Code or [2] Country ? ");

		if (UserChoice == 1)
		{
			cout << "\nPlease Enter Currency Code: ";
			string CountryCode = clsInputValidate::ReadString();

			clsCurrency Currency = clsCurrency::FindByCode(CountryCode);

			_ShowResult(Currency);
		}

		if (UserChoice == 2)
		{
			cout << "\nPlease Enter Country Name: ";
			string CountryName = clsInputValidate::ReadString();

			clsCurrency Currency = clsCurrency::FindByCountry(CountryName);

			_ShowResult(Currency);
		}
	}
};

