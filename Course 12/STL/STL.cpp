#include <iostream>
#include <stack>
#include <queue>
#include <map>
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

    // *********************************************************************************** //

    //queue<int> NumbersQueue;

    //NumbersQueue.push(10);
    //NumbersQueue.push(20);
    //NumbersQueue.push(30);
    //NumbersQueue.push(40);
    //NumbersQueue.push(50);

    //cout << "Count: " << NumbersQueue.size() << endl;

    //cout << "\nNumbers are:\n";

    //while (!NumbersQueue.empty())
    //{
    //    cout << NumbersQueue.front() << endl;

    //    NumbersQueue.pop();
    //}

    // *********************************************************************************** //

    map<string, int> studentGrade;

    studentGrade["Ahamd"] = 77;
    studentGrade["Yazan"] = 85;
    studentGrade["Rami"] = 95;

    for (auto& pair : studentGrade)
    {
        cout << "Student: " << pair.first << ", Grade: " << pair.second << endl << endl;
    }

    string studentName = "Ahamd";


    if (studentGrade.find(studentName) != studentGrade.end())
    {
        cout << studentName << ", Grade: " << studentGrade[studentName] << endl;
    }
    else 
    {
        cout << "Grade not found" << endl;
    }

    // what find returns?
    // If the key exists: returns iterator to the element.
    // If the key does not exist: returns end() iterator.

    //cout << studentGrade.find(studentName)->first;


    return 0;
}

