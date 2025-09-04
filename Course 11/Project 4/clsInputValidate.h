#pragma once

#include <iostream>
#include "clsDate.h"
using namespace std;


class clsInputValidate
{
public:
	static bool IsValidDate(clsDate Date)
	{
		return	clsDate::IsValidDate(Date);
	}

	static string ReadString()
	{
		string  S1 = "";
		getline(cin >> ws, S1);

		return S1;
	}

	template <typename Number>
	static bool isNumberBetween(Number N, Number From, Number To) {
		if (To < From)
			swap(To, From);

		return N >= From && N <= To;
	}

	static bool isDateBetween(clsDate Date, clsDate DateFrom, clsDate DateTo) {
		if (!(clsDate::IsValidDate(DateFrom) && IsValidDate(DateTo)))
		{
			cout << "The start or end date is invalid\n";
			return false;
		}

		if (clsDate::CompareDates(DateTo, DateFrom) == clsDate::Before)
			swap(DateTo, DateFrom);

		return (clsDate::CompareDates(Date, DateFrom) != clsDate::Before) && (clsDate::CompareDates(Date, DateTo) != clsDate::After);
	}

	template <typename Number>
	static Number ReadNumber(string Message = "Invalid Number, Enter again\n") {
		Number Num = 0;

		while (!(cin >> Num)) {
			// Ignore the error
			cin.clear();

			// Ignore all the inputted size until \n
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

			cout << Message;
		}
		return Num;
	}

	template <typename Number>
	static Number ReadNumberBetween(Number From, Number To, string Message = "Number is not within the range, Enter again\n") {
		Number Num = ReadNumber<Number>();

		while (!isNumberBetween<Number>(Num, From, To)) {
			cout << Message;
			Num = ReadNumber<Number>();
		}

		return Num;
	}
};

