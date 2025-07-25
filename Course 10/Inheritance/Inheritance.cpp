#include <iostream>  
using namespace std;  

class clsPerson
{
    int _ID;
    string _FirstName;
    string _LastName;
    string _Email;
    string _Phone;

public:
    clsPerson(int ID, string FirstName, string LastName, string Email, string Phone) {
        _ID = ID;
        _FirstName = FirstName;
        _LastName = LastName;
        _Email = Email;
        _Phone = Phone;
    }

    int GetID() {
        return _ID;
    }

    void SetFirstName(string FirstName) {
        _FirstName = FirstName;
    }

    string GetFirstName() {
        return _FirstName;
    }

    void SetLastName(string LastName) {
        _LastName = LastName;
    }

    string GetLastName() {
        return _LastName;
    }

    void SetEmail(string Email) {
        _Email = Email;
    }

    string GetEmail() {
        return _Email;
    }

    void SetPhone(string Phone) {
        _Phone = Phone;
    }

    string GetPhone() {
        return _Phone;
    }

    string FullName() {
        return _FirstName + " " + _LastName;
    }


    void Print() {
        cout << "\nInfo:\n";
        cout << "------------------------------------------------\n";
        cout << "\ID                        : " << _ID << endl;
        cout << "FirstName                 : " << _FirstName << endl;
        cout << "LastName                  : " << _LastName << endl;
        cout << "FullName                  : " << FullName() << endl;
        cout << "Email                     : " << _Email << endl;
        cout << "Phone                     : " << _Phone << endl;
        cout << "------------------------------------------------\n";
    }

    void SendEmail(string Subject, string Body) {
        cout << "\nThe following message sent successfully to email: " << _Email << endl;
        cout << "Subject: " << Subject << endl;
        cout << "Body: " << Body << endl;
    }

    void SendSMS(string Message) {
        cout << "\nThe following SMS sent successfully to phone: " << _Phone << endl;
        cout << Message << endl;
    }
};

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
        //clsPerson::Print();

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

class clsDeveloper : public clsEmployee {
    string _MainProgrammingLanguage;

public:

    clsDeveloper(int ID, string FirstName, string LastName, string Email, string Phone, string Title, string Department, float Salary, string MainProgrammingLanguage)
        : clsEmployee(ID, FirstName, LastName, Email, Phone, Title, Department, Salary) {
        _MainProgrammingLanguage = MainProgrammingLanguage;
    }

    void SetMainProgrammingLanguage(string MainProgrammingLanguage) {
        _MainProgrammingLanguage = MainProgrammingLanguage;
    }

    string GetMainProgrammingLanguage() {
        return _MainProgrammingLanguage;
    }

    void Print() {
        //clsEmployee::Print();
        cout << "\nInfo:\n";
        cout << "------------------------------------------------\n";
        cout << "\ID                        : " << GetID() << endl;
        cout << "FirstName                 : " << GetFirstName() << endl;
        cout << "LastName                  : " << GetLastName() << endl;
        cout << "FullName                  : " << FullName() << endl;
        cout << "Email                     : " << GetEmail() << endl;
        cout << "Phone                     : " << GetPhone() << endl;
        cout << "Title                     : " << GetTitle() << endl;
        cout << "Department                : " << GetDepartment() << endl;
        cout << "Salary                    : " << GetSalary() << endl;
        cout << "Main Programming Language : " << _MainProgrammingLanguage << endl;
        cout << "------------------------------------------------\n";
    }
};

class clsA { 
private:  
int V1; 
    int Fun1() { 
    return 1; 
    } 

protected: 
    int V2; 
    int Fun2() { 
        return 2; 
    } 

public: 
    int V3; 
    int Fun3() { 
        return 3; 
    } 
};

class clsB : private clsA{

protected:
    int V4;
    int Fun4() {
        return 2;
    }

public:
    int V5;
    int Fun5() {
        return 3;
    }
};

class clsC : private clsB {

protected:
    int V6;
    int Fun6() {
        return 5;
    }

public:
    int V7;
    int Fun7() {
        return 6;
    }
};


class clsPersonExample {
public: 
    string FullName = "Basel Dawood"; 

    virtual void Print() {
        cout << "Hi, I'm a Person\n";
    }
}; 

class clsEmployeeExample : public clsPersonExample {
public: 
    string Title = "Software Developer"; 

    void Print() {
        cout << "Hi, I'm a Employee\n";
    }
};

class clsStudentExample : public clsPersonExample {
public: 
    void Print() { 
        cout << "Hi, I'm a Student\n"; 
    } 
};

int main()  
{  
    clsEmployeeExample Employee;
    clsStudentExample Student;
    //Early-Static Binding: at compilation time
    Employee.Print();
    Student.Print();


    clsPersonExample* Person1 = &Employee;
    clsPersonExample* Person2 = &Student;

    //Late-Dynamic Binding: at runtime
    Person1->Print();
    Person2->Print();

    //clsEmployeeExample Employee1;

    //cout << Employee1.FullName << endl;

    ////Upcasting
    //clsPersonExample* Person1 = &Employee1;

    //cout << Person1->FullName << endl;

    //clsDeveloper Developer1(10, "Basel", "Dawood", "bd@gmail.com", "0781234567", "Software Developer", "Software", 7878, "C++");

    //Developer1.Print();

    //clsEmployee Employee1(10, "Basel", "Dawood", "bd@gmail.com", "0781234567", "Software Developer", "Software", 7878);

    //Employee1.Print();


}
