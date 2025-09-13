#pragma once

#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;

template <class T>
class clsMyQueue
{

protected:
	clsDblLinkedList <T> _List;

public:

	void Push(T Value)
	{
		_List.InsertAtEnd(Value);
	}

	void Pop()
	{
		_List.DeleteFirstNode();
	}

	void Print()
	{
		_List.PrintList();
	}

	T Front()
	{
		if (_List.isEmpty()) return T{};

		return _List.GetItem(0);
	}

	T Back()
	{
		if (_List.isEmpty()) return T{};

		return _List.GetItem(_List.Size() - 1);
	}

	bool isEmpty()
	{
		return _List.isEmpty();
	}

	int Size()
	{
		return _List.Size();
	}

	T GetItem(int index)
	{
		return _List.GetItem(index);
	}

	void Reverse()
	{
		_List.Reverse();
	}

	bool UpdateItem(int index, T NewValue)
	{
		return _List.UpdateItem(index, NewValue);
	}

	void InsertAfter(int index, T Value)
	{
		_List.InsertAfter(index, Value);
	}

	void InsertAtFront(T Value)
	{
		_List.InsertAtBeginning(Value);
	}

	void InsertAtBack(T Value)
	{
		_List.InsertAfter(_List.Size() - 1, Value);
	}

	void Clear()
	{
		_List.Clear();
	}
};

