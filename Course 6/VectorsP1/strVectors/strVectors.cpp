#include <vector>
#include <iostream>
using namespace std;

struct stEmployee {
	string Firstname;
	string Lastname;
	float Salary;
};

void AskAndFillEmployeesVector(vector <stEmployee>& Employees) {
	char ReadMore = 'Y';
	stEmployee Employee;
	while (ReadMore == 'Y' || ReadMore == 'y') {
		cout << "Enter Employee Firstname: ";
		cin >> Employee.Firstname;
		cout << "\nEnter Employee Lastname: ";
		cin >> Employee.Lastname;
		cout << "\nEnter Employee Salary: ";
		cin >> Employee.Salary;

		Employees.push_back(Employee);

		cout << "\nDo you want to add more employess ? y or n\n";
		cin >> ReadMore;
	}
}

void PrintEmplyees(vector <stEmployee>& Employees) {
	Employees.size() > 0 ? cout << "\nEmployess vector:\n\n" : cout << "\nEmployess vector is empty\n\n";
	for (stEmployee& Employee : Employees) {
		cout << "Firstname: " << Employee.Firstname << endl;
		cout << "Lastname : " << Employee.Lastname << endl;
		cout << "Salary   : " << Employee.Salary << endl;
		cout << endl;
	}
}

int main()
{
	/*vector <stEmployee> vEmployees = {
		{ "Mohammad", "Waleed", 5000 } ,
		{ "Loay", "Wreikat", 700 },
		{ "Ali", "Smadi", 1000 }
	};

	cout << "Employess vectore:\n\n";
	for (stEmployee& Employee : vEmployees) {
		cout << "Firstname: " << Employee.Firstname << endl;
		cout << "Lastname : " << Employee.Lastname << endl;
		cout << "Salary   : " << Employee.Salary << endl;
		cout << endl;
	}*/
	vector <stEmployee> Employees;

	AskAndFillEmployeesVector(Employees);
	PrintEmplyees(Employees);

	//Employees.clear();

	if (Employees.size() > 0) {
		Employees.pop_back();
		cout << "Employess After removing last record:";
		PrintEmplyees(Employees);
	}

}
