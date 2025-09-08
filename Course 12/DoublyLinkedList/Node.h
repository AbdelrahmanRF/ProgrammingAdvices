#pragma once

#include <iostream>
using namespace std;

template <class Type>
class Node
{

public:
	Type Value;
	Node* Next;
	Node* Prev;


	static void InsertAtBeginning(Node* &head, Type value)
	{
		Node* new_node = new Node();

		new_node->Value = value;

		new_node->Prev = NULL;
		new_node->Next = head;

		if (head != NULL)
		{
			head->Prev = new_node;
		}

		head = new_node;
	}

	static void PrintNodeDetails(Node* head)
	{

		if (head->Prev != NULL)
			cout << head->Prev->Value;
		else
			cout << "NULL";

		cout << " <--> " << head->Value << " <--> ";

		if (head->Next != NULL)
			cout << head->Next->Value << "\n";
		else
			cout << "NULL";

	}

	static void PrintList(Node* head)
	{
		cout << "NULL <--> ";
		while (head != NULL) {
			cout << head->Value << " <--> ";
			head = head->Next;
		}
		cout << "NULL";
	}

	static void PrintListDetails(Node* head)
	{
		cout << "\n\n";
		while (head != NULL) {
			PrintNodeDetails(head);
			head = head->Next;
		}
	}

	static Node* Find(Node* head, Type value) 
	{

		while (head != NULL)
		{
			if (head->Value == value)
			{
				return head;
			}

			head = head->Next;
		}

		return NULL;
	}

	static void InsertAfter(Node* prevNode, Type value)
	{
		if (prevNode == NULL)
		{
			cout << "The given previous node cannot be NULL\n";
		}

		Node* new_node = new Node();

		new_node->Value = value;
		new_node->Prev = prevNode;

		if (prevNode->Next != NULL)
			prevNode->Next->Prev = new_node;

		prevNode->Next = new_node;

	}

	static void InsertAtTheEnd(Node*& head, Type value)
	{
		Node* new_node = new Node();
		new_node->Value = value;
		new_node->Next = NULL;

		if (head == NULL)
		{
			new_node->Prev = NULL;
			head = new_node;
			return;
		}

		Node* current_node = head;
		while (current_node->Next != NULL)
		{
			current_node = current_node->Next;
		}

		current_node->Next = new_node;
		new_node->Prev = current_node;
	}

	static void DeleteNode(Node*& head, Node*& NodeToDelete)
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

		delete NodeToDelete;
	}

	static void DeleteFirstNode(Node*& head)
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

		delete temp;
	}

	static void DeleteLastNode(Node*& head)
	{
		if (head == NULL)
		{
			return;
		}

		if (head->Next == NULL)
		{
			delete head;
			head = NULL;
			return;
		}

		Node* current_node = head;

		// Search for before last node
		while (current_node->Next->Next != NULL)
		{
			current_node = current_node->Next;
		}

		Node* temp = current_node->Next;
		current_node->Next = NULL;

		delete temp;
	}
};

