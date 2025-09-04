#pragma once

#include <iostream>
using namespace std;


template <class T>
class Calculator
{
	T _Number1, _Number2;

public:

	Calculator(T N1, T N2)
	{
		_Number1 = N1;
		_Number2 = N2;
	}

	void PrintResults()
	{
		cout << "Numbers: " << _Number1 << " And " << _Number2 << endl;
		cout << _Number1 << " + " << _Number2 << " = " << Add() << endl;
		cout << _Number1 << " - " << _Number2 << " = " << Subtract() << endl;
		cout << _Number1 << " * " << _Number2 << " = " << Multiply() << endl;
		cout << _Number1 << " / " << _Number2 << " = " << Divide() << endl;
	}

	T Add()
	{
		return _Number1 + _Number2;
	}

	T Subtract()
	{
		return _Number1 - _Number2;
	}

	T Multiply()
	{
		return _Number1 * _Number2;
	}

	T Divide()
	{
		return _Number1 / _Number2;
	}
};

