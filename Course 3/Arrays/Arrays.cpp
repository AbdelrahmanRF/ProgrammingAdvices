#include <iostream>
#include <format>
using namespace std;

void ReadGradesData(float Grades[3]) {
    cout << "Enter The First Grade" << endl;
    cin >> Grades[0];
    cout << "Enter The Second Grade" << endl;
    cin >> Grades[1];
    cout << "Enter The Third Grade" << endl;
    cin >> Grades[2];
}

float avg(float Grades[3]) {
     return (Grades[0] + Grades[1] + Grades[2]) / 3 ;
}

struct strInfo {
    string FirstName;
    string LastName;
    int Age;
    string Phone;
};


void ReadInfo(strInfo &Info) {
    cout << "Please Enter Person First Name" << endl;
    cin >> Info.FirstName;
    cout << "Please Enter Person Last Name" << endl;
    cin >> Info.LastName;
    cout << "Please Enter Person Age" << endl;
    cin >> Info.Age;
    cout << "Please Enter Person Phone Number" << endl;
    cin >> Info.Phone;
    cout << '\n';
}
void PrintInfo(strInfo Info) {
    cout << "*********************************" << endl;
    cout << format("Firstname: {}\n", Info.FirstName);
    cout << format("Lastname: {}\n", Info.LastName);
    cout << format("Age: {}\n", Info.Age);
    cout << format("Phone Number: {}\n", Info.Phone);
    cout << "*********************************" << endl;
};
void ReadPersonsData(strInfo Persons[2]) {
    ReadInfo(Persons[0]);
    ReadInfo(Persons[1]);
}
void PrintPersonsData(strInfo Persons[2]) {
    cout << "\n********************************************\n";
    PrintInfo(Persons[0]);
    PrintInfo(Persons[1]);
}
int main()
{
    //strInfo Persons[3] = { {"Abdelrahman", "Alfar", 23, "0786067097"},
    //{"Waleed", "Alfar", 44, "0794567891"},
    //{"Mahmoud", "Alfar", 14, "0797897894"} 
    //};
    strInfo Persons[2];
    ReadPersonsData(Persons);
    PrintPersonsData(Persons);

    //float Grades[3];
    //ReadGradesData(Grades);
    //cout << "The Average of Grades is: " << avg(Grades) << endl;

   

    return 0;
}
