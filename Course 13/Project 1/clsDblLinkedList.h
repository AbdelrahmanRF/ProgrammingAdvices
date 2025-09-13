#pragma once

#include <iostream>
//#include <stdexcept>
using namespace std;

template <class T>
class clsDblLinkedList
{

protected:
	int _Size = 0;

public:

	class Node
	{
	public:
		T Value;
		Node* Next;
		Node* Prev;
	};

	Node* head = NULL;

	void InsertAtBeginning(T Value)
	{
		Node* NewNode = new Node();

		NewNode->Value = Value;
		NewNode->Next = head;
		NewNode->Prev = NULL;

		if (head != NULL)
		{
			head->Prev = NewNode;
		}

		head = NewNode;
		++_Size;
	}

	void InsertAfter(Node* PrevNode, T Value)
	{
		if (PrevNode == NULL)
		{
			cout << "The given previous node cannot be NULL\n";
			return;
		}

		Node* NewNode = new Node();

		NewNode->Value = Value;
		NewNode->Next = PrevNode->Next;
		NewNode->Prev = PrevNode;

		if (PrevNode->Next != NULL)
		{
			PrevNode->Next->Prev = NewNode;
		}

		PrevNode->Next = NewNode;
		++_Size;
	}

	void InsertAtEnd(T Value)
	{
		Node* NewNode = new Node();
		NewNode->Value = Value;
		NewNode->Next =  NULL;

		if (head == NULL)
		{
			NewNode->Prev = NULL;

			head = NewNode;
		}
		else
		{
			Node* Current = head;

			while (Current->Next != NULL)
			{
				Current = Current->Next;
			}

			Current->Next = NewNode;
			NewNode->Prev = Current;
		}

		++_Size;
	}

	void DeleteNode(Node*& NodeToDelete)
	{
		if (head == NULL || NodeToDelete == NULL)
		{
			return;
		}

		if (head == NodeToDelete)
		{
			head = NodeToDelete->Next;
		}

		if (NodeToDelete->Next != NULL)
		{
			NodeToDelete->Next->Prev = NodeToDelete->Prev;
		}

		if (NodeToDelete->Prev != NULL)
		{
			NodeToDelete->Prev->Next = NodeToDelete->Next;
		}

		--_Size;
		delete NodeToDelete;
	}

	void DeleteFirstNode()
	{
		if (head == NULL)
		{
			return;
		}

		Node* temp = head;

		head = head->Next;

		if (head != NULL)
		{
			head->Prev = NULL;
		}

		--_Size;
		delete temp;
	}

	void DeleteLastNode()
	{
		if (head == NULL)
		{
			return;
		}

		if (head->Next == NULL)
		{
			delete head;
			head = NULL;
			--_Size;
			return;
		}

		Node* Current = head;

		while (Current->Next->Next != NULL)
		{
			Current = Current->Next;
		}

		Node* temp = Current->Next;
		Current->Next = NULL;
		--_Size;
		delete temp;
	}

	void PrintList()
	{
		Node* Current = head;

		while (Current != NULL)
		{
			cout << Current->Value << " ";
			Current = Current->Next;
		}

		cout << "\n";
	}

	Node* Find(T Value)
	{
		Node* Current = head;

		while (Current != NULL)
		{
			if (Current->Value == Value)
			{
				return Current;
			}

			Current = Current->Next;
		}

		return NULL;
	}

	int Size()
	{
		return _Size;
	}

	int isEmpty()
	{
		//return !_Size;
		return _Size == 0;
	}

	void Clear()
	{
		while (!isEmpty())
		{
			DeleteFirstNode();
		}
	}

	void Reverse()
	{
		Node* Current = head;
		Node* temp = nullptr;

		while (Current != NULL)
		{
			// swap pointers
			temp = Current->Prev;
			Current->Prev = Current->Next;
			Current->Next = temp;

			// move forward (which is Prev now)
			Current = Current->Prev;
		}

		// update head
		if (temp != nullptr)
		{
			head = temp->Prev;
		}
	}

	//Node* GetNode(int Index)
	//{
	//	int Counter = 0;
	//
	//	if (Index > _Size - 1 || Index < 0)
	//		return NULL;
	//
	//	Node* Current = head;
	//	while (Current != NULL && (Current->next != NULL)) {
	//
	//		if (Counter == Index)
	//			break;
	//
	//		Current = Current->next;
	//		Counter++;
	//	}
	//
	//	return Current;
	//}

	Node* GetNode(int index)
	{
		int Counter = 0;

		if (index > _Size - 1 || index < 0) return NULL;

		Node* Current = head;

		for (Counter; Counter < index; Counter++)
		{
			Current = Current->Next;
		}

		return Current;
	}

	T GetItem(int index)
	{
		Node* N = GetNode(index);

		if (N == NULL)
		{
			//throw std::out_of_range("Index out of range");
			return T{};
		}

		return N->Value;
	}

	bool UpdateItem(int index, T NewValue)
	{
		Node* N = GetNode(index);

		if (N == NULL)
			return false;

		N->Value = NewValue;
		return true;
	}

	bool InsertAfter(int index, T Value)
	{
		Node* N = GetNode(index);

		if (N == NULL)
			return false;

		InsertAfter(N, Value);
	}

};

