#include <iostream>
#include <stack>
#include <queue>
using namespace std;

int main()
{
    //stack<int> stkNumbers;

    //stkNumbers.push(10);
    //stkNumbers.push(20);
    //stkNumbers.push(30);
    //stkNumbers.push(40);
    //stkNumbers.push(50);

    //cout << "Count: " << stkNumbers.size() << endl;

    //cout << "\nNumbers are:\n";

    //while (!stkNumbers.empty())
    //{
    //    cout << stkNumbers.top() << endl;

    //    stkNumbers.pop();
    //}


    queue<int> NumbersQueue;

    NumbersQueue.push(10);
    NumbersQueue.push(20);
    NumbersQueue.push(30);
    NumbersQueue.push(40);
    NumbersQueue.push(50);

    cout << "Count: " << NumbersQueue.size() << endl;

    cout << "\nNumbers are:\n";

    while (!NumbersQueue.empty())
    {
        cout << NumbersQueue.front() << endl;

        NumbersQueue.pop();
    }

    return 0;
}

