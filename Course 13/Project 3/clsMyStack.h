#pragma once

#include <iostream>
#include "clsMyQueue.h"
using namespace std;


template <class T>
class clsMyStack : public clsMyQueue<T>
{

public:

	void Push(T Value)
	{
		// or this->::_List.InsertAtBeginning(Value);
		clsMyQueue <T>::_List.InsertAtBeginning(Value);
	}

	T Top()
	{
		return clsMyQueue <T>::Front();
	}

	T Bottom()
	{
		return clsMyQueue <T>::Back();
	}
};

