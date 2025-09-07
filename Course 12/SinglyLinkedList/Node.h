#pragma once

#include <iostream>
using namespace std;

template <class Type>
class Node
{

public: 

	Type Value;
	Node* Next;

	static void InsertAtTheBeginning(Node* &head, Type value)
	{
		Node* node = new Node();

		node->Value = value;
		node->Next = head;

		head = node;
	}

	static void InsertAtTheEnd(Node*& head, Type value)
	{
		Node* new_node = new Node();

		new_node->Value = value;
		new_node->Next = NULL;

		if (head == NULL)
		{
			head = new_node;
			return;
		}

		Node* LastNode = head;

		while (LastNode->Next != NULL)
		{
			LastNode = LastNode->Next;
		}

		LastNode->Next = new_node;
		return;
	}

	static void PrintList(Node* head)
	{
		while (head != NULL)
		{
			cout << head->Value << endl;
			head = head->Next;
		}
	}

	static Node* Find(Node* head, Type value)
	{
		while (head != NULL)
		{
			if (head->Value == value)
				return head;
				
			head = head->Next;
		}

		return NULL;
	}

	static void InsertAfter(Node* prev_node, Type value)
	{
		if (prev_node == NULL)
		{
			cout << "The given previous node cannot be NULL\n";
		}

		Node* new_node = new Node();

		new_node->Value = value;
		new_node->Next = prev_node->Next;

		prev_node->Next = new_node;
	}

	static void DeleteNode(Node* &head, Type value)
	{
		Node* PrevNode = NULL, *CurrentNode = head;

		if (head == NULL)
		{
			return;
		}

		if (CurrentNode->Value == value)
		{
			head = CurrentNode->Next;
			delete CurrentNode;
			return;
		}

		while (CurrentNode != NULL && CurrentNode->Value != value)
		{
			PrevNode = CurrentNode;
			CurrentNode = CurrentNode->Next;
		}

		if (CurrentNode == NULL) return;

		PrevNode->Next = CurrentNode->Next;
		delete CurrentNode;
	}

	static void DeleteFirstNode(Node*& head)
	{
		if (head == NULL)
			return;

		Node* FirstNode = head;

		head = FirstNode->Next;
		delete FirstNode;
		return;
	}

	static void DeleteLastNode(Node*& head)
	{
		Node* PrevNode = NULL, * CurrentNode = head;

		if (head == NULL)
			return;

		if (CurrentNode->Next == NULL)
		{
			head = NULL;
			delete CurrentNode;
			return;
		}

		while (CurrentNode != NULL && CurrentNode->Next != NULL)
		{
			PrevNode = CurrentNode;
			CurrentNode = CurrentNode->Next;
		}

		PrevNode->Next = NULL;
		delete CurrentNode;
		return;
	}
};

