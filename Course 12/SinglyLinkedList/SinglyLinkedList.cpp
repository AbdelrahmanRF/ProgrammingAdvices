#include <iostream>
#include "Node.h"
using namespace std;

int main()
{

    //// Allocate 3 nodes in the head
    //Node<short>* Node1 = new Node<short>();
    //Node<short>* Node2 = new Node<short>();
    //Node<short>* Node3 = new Node<short>();

    //// Creating the head
    //Node<short>* Head = Node1;

    //// Assigning values
    //Node1->Value = 1;
    //Node2->Value = 2;
    //Node3->Value = 3;

    //// Connect Nodes
    //Node1->Next = Node2;
    //Node2->Next = Node3;
    //Node3->Next = NULL;

    //Node<short>::PrintList(Head);

    // ******************************************************************** // 
    //Node<short>* Head = NULL;

    //Node<short>::InsertAtTheBeginning(Head, 1);
    //Node<short>::InsertAtTheBeginning(Head, 2);
    //Node<short>::InsertAtTheBeginning(Head, 3);
    //Node<short>::InsertAtTheBeginning(Head, 4);
    //Node<short>::InsertAtTheBeginning(Head, 5);

    //Node<short>::PrintList(Head);

    //Node<short>* N1 = Node<short>::Find(Head, 2);

    //Node<short>::InsertAfter(N1, 500);

    //Node<short>::PrintList(Head);


    //if (N1 != NULL)
    //    cout << "Node Found :-)\n";
    //else
    //    cout << "Node Not Found :-(\n";

    // ******************************************************************** // 
    
    Node<short>* Head = NULL;

    Node<short>::InsertAtTheEnd(Head, 1);
    Node<short>::InsertAtTheEnd(Head, 2);
    Node<short>::InsertAtTheEnd(Head, 3);
    Node<short>::InsertAtTheEnd(Head, 4);

    Node<short>::PrintList(Head);

    //Node<short>::DeleteNode(Head, 4);
    Node<short>::DeleteFirstNode(Head);
    Node<short>::DeleteLastNode(Head);
    Node<short>::PrintList(Head);

    return 0;
}

