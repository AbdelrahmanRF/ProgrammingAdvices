#pragma once

#include <iostream>
#include "clsDynamicArray.h"
using namespace std;

template <class T>
class clsMyQueueArr
{

protected:
	clsDynamicArray <T> _MyQueue;

public:

	void Push(T Value)
	{
		_MyQueue.InsertAtEnd(Value);
	}

	void Pop()
	{
		_MyQueue.DeleteFirstItem();
	}

	void Print()
	{
		_MyQueue.PrintList();
	}

	bool isEmpty()
	{
		return _MyQueue.isEmpty();
	}

	int Size()
	{
		return _MyQueue.Size();
	}

	T Front()
	{
		return _MyQueue.GetItem(0);
	}

	T Back()
	{
		return _MyQueue.GetItem(_MyQueue.Size() - 1);
	}

	T GetItem(int index)
	{
		return _MyQueue.GetItem(index);
	}

	void Reverse()
	{
		_MyQueue.Reverse();
	}

	bool UpdateItem(int index, T Value)
	{
		return _MyQueue.SetItem(index, Value);
	}

	bool InsertAfter(int index, T Value)
	{
		return _MyQueue.InsertAfter(index, Value);
	}

	bool InsertAtFront(T Value)
	{
		return _MyQueue.InsertAtBeginning(Value);
	}

	bool InsertAtBack(T Value)
	{
		return _MyQueue.InsertAtEnd(Value);
	}

	void Clear()
	{
		_MyQueue.Clear();
	}
};

