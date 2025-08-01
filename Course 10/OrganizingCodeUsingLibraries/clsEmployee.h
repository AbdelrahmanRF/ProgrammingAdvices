#include <iostream>  
#include "clsPerson.h"  

using namespace std;

class clsEmployee : public clsPerson {
    string _Title;
    string _Department;
    float _Salary;

public:
    clsEmployee(int ID, string FirstName, string LastName, string Email, string Phone, string Title, string Department, float Salary)
        : clsPerson(ID, FirstName, LastName, Email, Phone) {

        _Title = Title;
        _Department = Department;
        _Salary = Salary;
    };

    void SetTitle(string Title) {
        _Title = Title;
    }

    string GetTitle() {
        return _Title;
    }

    void SetDepartment(string Department) {
        _Department = Department;
    }

    string GetDepartment() {
        return _Department;
    }

    void SetSalary(float Salary) {
        _Salary = Salary;
    }

    float GetSalary() {
        return _Salary;
    }

    void Print() {

        cout << "\nInfo:\n";
        cout << "------------------------------------------------\n";
        cout << "\ID                        : " << GetID() << endl;
        cout << "FirstName                 : " << GetFirstName() << endl;
        cout << "LastName                  : " << GetLastName() << endl;
        cout << "FullName                  : " << FullName() << endl;
        cout << "Email                     : " << GetEmail() << endl;
        cout << "Phone                     : " << GetPhone() << endl;
        cout << "Title                     : " << _Title << endl;
        cout << "Department                : " << _Department << endl;
        cout << "Salary                    : " << _Salary << endl;
        cout << "------------------------------------------------\n";
    }
};

