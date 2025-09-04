#pragma once

#include "clsCurrency.h"
#include "clsScreen.h"
#include "clsInputValidate.h"
#include "clsString.h"


class clsCurrencyCalculatorScreen : protected clsScreen
{
	static float _ReadAmount()
	{
		cout << "\nEnter Amount to Exchange: ";
		float Amount = 0;

		Amount = clsInputValidate::ReadNumber<float>();
		return Amount;
	}

	static clsCurrency _GetCurrency(short CurrencyCodeNumber)
	{
		string CurrencyCode = "";

		cout << "\nPlease Enter Currency " << CurrencyCodeNumber << " Code:\n";
		CurrencyCode = clsInputValidate::ReadString();

		while (!clsCurrency::IsCurrencyExist(CurrencyCode)) {
			cout << "\nCurrency is not found, choose another one: ";
			CurrencyCode = clsInputValidate::ReadString();
		}

		clsCurrency Currency = clsCurrency::FindByCode(CurrencyCode);
		return Currency;
	}

	static void _PrintCurrency(clsCurrency Currency, string Message)
	{
		cout << "\n" << Message <<"\n";
		cout << "_____________________________\n";
		cout << "\nCountry    : " << Currency.GetCountry();
		cout << "\nCode       : " << Currency.GetCode();
		cout << "\nName       : " << Currency.GetName();
		cout << "\nRate(1$) = : " << Currency.GetRate();

		cout << "\n_____________________________\n";
	}

	static void _PrintCalculationsResults(float Amount, clsCurrency Currency1, clsCurrency Currency2)
	{
		cout << Amount << " " << Currency1.GetCode() << " = " << Currency1.ConvertToOtherCurrency(Amount, Currency2) <<
			" " << Currency2.GetCode() << endl;
	}

public:

	static void ShowCurrencyCalculatorScreen()
	{
		char PerformAnother = 'Y';
		float Amount = 0;

		do {
			system("cls");
			_DrawScreenHeader("\tCurrency Calculator Screen");

			clsCurrency Currency1 = _GetCurrency(1);

			clsCurrency Currency2 = _GetCurrency(2);

			Amount = _ReadAmount();

			if (Currency2.GetCode() != "USD" && Currency2.GetCode() != Currency1.GetCode())
			{
				clsCurrency USDCurrency = clsCurrency::FindByCode("USD");

				_PrintCurrency(Currency1, "Converting From:");
				_PrintCalculationsResults(Amount, Currency1, USDCurrency);

				_PrintCurrency(Currency2, "Converting From USD To:");
				_PrintCalculationsResults(Amount, Currency1, Currency2);
			}
			else
			{
				_PrintCurrency(Currency1, "Converting From:");
				_PrintCalculationsResults(Amount, Currency1, Currency2);
			}


			cout << "\nDo you want to perform another calculation? y/n ? ";
			cin >> PerformAnother;


		} while (toupper(PerformAnother) == 'Y');

	}
};

