#include <iostream>
#include "Node.h"
using namespace std;


int main()
{
    // ******************************************************************** // 

    //Node<short>* head = NULL;

    //Node<short>::InsertAtBeginning(head, 5);
    //Node<short>::InsertAtBeginning(head, 4);
    //Node<short>::InsertAtBeginning(head, 3);
    //Node<short>::InsertAtBeginning(head, 2);
    //Node<short>::InsertAtBeginning(head, 1);

    //cout << "\nLinked List Content:\n";
    //Node<short>::PrintList(head);
    //Node<short>::PrintListDetails(head);

    //Node<short>* N1 = Node<short>::Find(head, 5);
    //Node<short>::InsertAfter(N1, 6);

    //cout << "\nLinked List Content:\n";
    //Node<short>::PrintList(head);

    // ******************************************************************** // 


    Node<short>* head = NULL;

    Node<short>::InsertAtTheEnd(head, 5);
    Node<short>::InsertAtTheEnd(head, 4);
    Node<short>::InsertAtTheEnd(head, 3);
    Node<short>::InsertAtTheEnd(head, 2);
    Node<short>::InsertAtTheEnd(head, 1);

    Node<short>* N1 = Node<short>::Find(head, 3);
    Node<short>::DeleteNode(head, N1);
    Node<short>::DeleteFirstNode(head);
    Node<short>::DeleteLastNode(head);
    cout << "\nLinked List Content:\n";
    Node<short>::PrintList(head);



    return 0;
}

