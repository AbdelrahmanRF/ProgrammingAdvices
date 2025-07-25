#include <iostream>
using namespace std;

class clsPerson 
{

public:
    string FirstName;
    string LastName;

    string Fullname() {
        return FirstName + " " + LastName;
    }

};

int main()
{
    clsPerson Person1;

    Person1.FirstName = "Abdelrahman";
    Person1.LastName = "Alfar";

    cout << Person1.Fullname() << endl;

}

