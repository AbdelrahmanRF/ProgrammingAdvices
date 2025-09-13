#pragma once

#include <iostream>
using namespace std;

template <class T>
class clsDynamicArray
{

protected:
	int _Size = 0;
	T* _TempArray;

public:
	T* _Array;

	clsDynamicArray(int Size = 0)
	{
		if (Size < 0)
			Size = 0;

		_Size = Size;
		_Array = new T[Size];
	}

	~clsDynamicArray()
	{
		delete[] _Array;
	}

	bool SetItem(int index, T Value)
	{
		if (index >= _Size || index < 0)
			return false;

		_Array[index] = Value;
		return true;
	}

	bool isEmpty()
	{
		return _Size == 0;
	}

	int Size()
	{
		return _Size;
	}

	void PrintList()
	{
		for (int i = 0; i < _Size; i++)
		{
			cout << _Array[i] << " ";
		}

		cout << "\n";
	}

	void Resize(int NewSize)
	{
		if (NewSize < 0)
			_Size = 0;

		_TempArray = new T[NewSize];

		if (NewSize < _Size)
			_Size = NewSize;

		for (int i = 0; i < _Size; i++)
		{
			_TempArray[i] = _Array[i];
		}

		_Size = NewSize;

		delete[] _Array;
		_Array = _TempArray;
	}

	T GetItem(int index)
	{
		return _Array[index];
	}

	void Reverse()
	{
		_TempArray = new T[_Size];

		for (int i = _Size - 1; i >= 0; i--)
		{
			_TempArray[i] = _Array[_Size - i - 1];
		}

		delete[] _Array;
		_Array = _TempArray;
	}

	void Clear()
	{
		_Size = 0;
		delete[] _Array;
		_Array = new T[_Size];
	}

	bool DeleteItemAt(int index)
	{
		if (index >= _Size || index < 0)
			return false;

		--_Size;
		_TempArray = new T[_Size];

		for (int i = 0; i < index; i++)
		{
			_TempArray[i] = _Array[i];
		}

		for (int i = index + 1 ; i < _Size + 1; i++)
		{
			_TempArray[i - 1] = _Array[i];
		}

		delete[] _Array;
		_Array = _TempArray;

		return true;
	}

	void DeleteFirstItem()
	{
		DeleteItemAt(0);
	}

	void DeleteLastItem()
	{
		DeleteItemAt(_Size - 1);
	}

	int Find(T Value)
	{
		for (int i = 0; i < _Size; i++)
		{
			if (_Array[i] == Value)
				return i;
		}

		return -1;
	}

	bool DeleteItem(T Value)
	{
		int index = Find(Value);

		if (index != -1)
		{
			DeleteItemAt(index);
			return true;
		}

		return false;
	}

	bool InsertAt(int index, T Value)
	{
		if (index > _Size || index < 0)
			return false;

		++_Size;
		_TempArray = new T[_Size];

		for (int i = 0; i < index; i++)
		{
			_TempArray[i] = _Array[i];
		}

		_TempArray[index] = Value;

		for (int i = index; i < _Size - 1; i++)
		{
			_TempArray[i + 1] = _Array[i];
		}

		delete[] _Array;
		_Array = _TempArray;

		return true;
	}

	bool InsertAtBeginning(T Value)
	{
		return InsertAt(0, Value);
	}

	bool InsertAtEnd(T Value)
	{
		return InsertAt(_Size, Value);
	}

	bool InsertBefore(int index, T Value)
	{
		if (index < 1)
			return InsertAt(0, Value);

		return InsertAt(--index, Value);
	}

	bool InsertAfter(int index, T Value)
	{
		if (index >= _Size)
			return InsertAt(_Size - 1, Value);

		return InsertAt(++index, Value);
	}
};

