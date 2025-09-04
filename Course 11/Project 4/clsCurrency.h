#pragma once

#include <iostream>
#include <vector>  
#include <string>  
#include <fstream> 
#include "clsString.h"

using namespace std;


class clsCurrency
{
	enum enMode { EmptyMode = 0, UpdateMode = 1 };

	enMode _Mode;

	string _Country;
	string _Code;
	string _Name;
	float _Rate;

	static clsCurrency _ConvertLineToCurrencyObject(string Line, string Separator = "#//#")
	{
		vector<string> vCurrency = clsString::Split(Line, Separator);

		return clsCurrency(UpdateMode, vCurrency[0], vCurrency[1], vCurrency[2], stof(vCurrency[3]));
	}

	static string _ConvertCurrencyObjectToLine(clsCurrency Currency, string Separator = "#//#")
	{
		string CurrencyDataLine = "";

		CurrencyDataLine += Currency.GetCountry() + Separator;
		CurrencyDataLine += Currency.GetCode() + Separator;
		CurrencyDataLine += Currency.GetName() + Separator;
		CurrencyDataLine += to_string(Currency.GetRate());

		return CurrencyDataLine;
	}

	static vector<clsCurrency> _LoadCurrenciesData()
	{
		fstream CurrenciesFile;
		vector<clsCurrency> Currencies;

		CurrenciesFile.open("Currencies.txt", ios::in);

		if (CurrenciesFile.is_open())
		{
			string Line;

			while (getline(CurrenciesFile, Line))
			{
				Currencies.push_back(_ConvertLineToCurrencyObject(Line));
			}

			CurrenciesFile.close();
		}

		return Currencies;
	}

	static void _SaveCurrenciesToFile(vector<clsCurrency>& Currencies)
	{
		fstream CurrenciesFile;

		CurrenciesFile.open("Currencies.txt", ios::out);

		if (CurrenciesFile.is_open())
		{
			for (clsCurrency& Currency : Currencies)
			{
				CurrenciesFile << _ConvertCurrencyObjectToLine(Currency) << endl;
			}

			CurrenciesFile.close();
		}
	}

	void _Update()
	{
		vector<clsCurrency> Currencies = _LoadCurrenciesData();

		for (clsCurrency& Currency : Currencies)
		{
			if (Currency.GetCode() == GetCode())
			{
				Currency = *this;
				_SaveCurrenciesToFile(Currencies);
				break;
			}
		}
	}

	static clsCurrency _GetEmptyCurrencyObject()
	{
		return clsCurrency(EmptyMode, "", "", "", 0.000000);
	}

public:

	clsCurrency(enMode Mode, string Country, string Code, string Name, float Rate)
	{
		_Mode = Mode;
		_Country = Country;
		_Code = Code;
		_Name = Name;
		_Rate = Rate;
	}

	bool IsEmpty()
	{
		return  _Mode == enMode::EmptyMode;
	}

	string GetCountry()
	{
		return _Country;
	}

	string GetCode()
	{
		return _Code;
	}

	string GetName()
	{
		return _Name;
	}

	void UpdateRate(float NewRate) {
		_Rate = NewRate;
		_Update();
	}

	float GetRate()
	{
		return _Rate;
	}

	static vector<clsCurrency> GetAllUSDRates()
	{
		return _LoadCurrenciesData();
	}

	static clsCurrency FindByCode(string CurrencyCode)
	{
		fstream CurrenciesFile;
		CurrencyCode = clsString::UpperAllString(CurrencyCode);
		clsCurrency Currency = _GetEmptyCurrencyObject();

		CurrenciesFile.open("Currencies.txt", ios::in);

		if (CurrenciesFile.is_open())
		{
			string Line;

			while (getline(CurrenciesFile, Line))
			{
				Currency = _ConvertLineToCurrencyObject(Line);

				if (Currency.GetCode() == CurrencyCode)
				{
					CurrenciesFile.close();
					return Currency;
				}
			}

			CurrenciesFile.close();
		}

		return  _GetEmptyCurrencyObject();
	}

	static clsCurrency FindByCountry(string Country)
	{
		fstream CurrenciesFile;
		Country = clsString::UpperAllString(Country);
		clsCurrency Currency = _GetEmptyCurrencyObject();

		CurrenciesFile.open("Currencies.txt", ios::in);

		if (CurrenciesFile.is_open())
		{
			string Line;

			while (getline(CurrenciesFile, Line))
			{
				Currency = _ConvertLineToCurrencyObject(Line);

				if (clsString::UpperAllString(Currency.GetCountry()) == Country)
				{
					CurrenciesFile.close();
					return Currency;
				}
			}

			CurrenciesFile.close();
		}

		return  _GetEmptyCurrencyObject();
	}

	static bool IsCurrencyExist(string CurrencyCode)
	{
		return !FindByCode(CurrencyCode).IsEmpty();
	}

	static vector<clsCurrency> GetCurrenciesList()
	{
		return _LoadCurrenciesData();
	}

	float ConvertToUsd(float Amount)
	{
		return  (float)(Amount / GetRate());
	}

	float ConvertToOtherCurrency(float Amount, clsCurrency Currency2)
	{
		return  (float)(ConvertToUsd(Amount) * Currency2.GetRate());
	}

};

