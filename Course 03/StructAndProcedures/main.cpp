#include <iostream>
#include <format>
using namespace std;

enum enGender {
	Male = 0,
	Female = 1,
};
enum enMartialStatus {
	Single = 0,
	Married = 1,
};
struct strAdress {
	string City;
	string Country;
};
struct strInfo {
	string FirstName;
	string LastName;
	int Age;
	string Phone;
	strAdress Adress;
	enGender Gender;
	enMartialStatus MartialStatus;
};


void ReadInfo(strInfo &Info) {
	int GenderInput, MartialStatusInput;

	cout << "Enter Your First Name:\n";
	cin >> Info.FirstName;

	cout << "Enter Your Last Name:\n";
	cin >> Info.LastName;

	cout << "Enter Your Age:\n";	
	cin >> Info.Age;

	cout << "Enter Your Phone Number:\n";
	cin >> Info.Phone;

	cout << "Enter Your Gender (0 for male, 1 for female):\n";
	cin >> GenderInput;
	Info.Gender = GenderInput ? enGender::Female : enGender::Male;

	cout << "Enter Your Martial Status (0 for Single, 1 for Married):\n";
	cin >> MartialStatusInput;
	Info.MartialStatus = MartialStatusInput ? enMartialStatus::Married : enMartialStatus::Single;

}
void PrintInfo(strInfo Info) {
	cout << "********************************\n";
	cout << format("Firstname: {}\n", Info.FirstName);
	cout << format("Lastname: {}\n", Info.LastName);
	cout << format("Age: {}\n", Info.Age);
	cout << format("Phone: {}\n", Info.Phone);
	cout << format("Gender: {}\n", Info.Gender ? "Female" :  "Male");
	cout << format("Martial Status: {}\n", Info.MartialStatus ? "Married" : "Single");
	cout << "********************************\n";
}


int main() {
	strInfo PersonInfo;

	ReadInfo(PersonInfo);
	PrintInfo(PersonInfo);
}