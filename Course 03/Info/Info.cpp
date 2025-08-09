#include <iostream>
using namespace std;
#include <string>

struct stAddressInfo {
	string City;
	string Country;
};

enum enGender {
	Male = 0,
	Female = 1
};

enum enStatus {
	Single = 0,
	Married = 1
};

struct stBasicInfo{
	string Name;
	short int Age;
	enGender Gender;
	enStatus Status;
	float MonthlySalary;
	stAddressInfo Address;
};

int main() {
	
	stBasicInfo info;
	int GenderInput;
	int StateInput;


	cout << "Enter Your Name: "<< endl;
	getline(cin, info.Name);
	cout << "Enter Your Age: " << endl;
	cin >> info.Age;
	cout << "Enter Your City: " << endl;
	cin >> info.Address.City;
	cout << "Enter Your Country: " << endl;
	cin >> info.Address.Country;
	cout << "Enter Your Monthly Salary: " << endl;
	cin >> info.MonthlySalary;
	// Input for Gender
	cout << "Enter Your Gender (0 for Male, 1 for Female): " << endl;
	cin >> GenderInput;
	info.Gender = GenderInput ? enGender::Female : enGender::Male;
	cout << "Enter Your Status ? (0 for Single, 1 for Married) " << endl;
	cin >> StateInput;
	info.Status = StateInput ? enStatus::Married : enStatus::Single;





	cout << "*****************************" << endl;
	cout << "Name: " << info.Name << endl;
	cout << "Age: " << info.Age << endl;
	cout << "City: " << info.Address.City << endl;
	cout << "Country: " << info.Address.Country << endl;
	cout << "Monthly Salary: " << info.MonthlySalary << endl;
	cout << "Yearly Salry: " << info.MonthlySalary * 12 << endl;
	cout << "Gender: " << (info.Gender ? "Female" : "Male") << endl;
	cout << "Married: " << (info.Status ? "Married" : "Single") << endl;
	cout << "*****************************" << endl;

	return 0;

}