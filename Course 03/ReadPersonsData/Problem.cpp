#include <iostream>
#include <format>
using namespace std;

struct strInfo {
	string FirstName;
	string LastName;
	short Age;
	string Phone;
};

void ReadInfo(strInfo& Person, short PersonNumber) {

	cout << format("Please Enter Person {} FirstName\n", PersonNumber);
	cin >> Person.FirstName;

	cout << format("Please Enter Person {} LastName\n", PersonNumber);
	cin >> Person.LastName;

	cout << format("Please Enter Person {} Age\n", PersonNumber);
	cin >> Person.Age;

	cout << format("Please Enter Person {} Phone Number\n", PersonNumber);
	cin >> Person.Phone;
}
void ReadPersonsInfo(strInfo Persons[10], short& PersonsNumber) {
	cout << "Please Enter How Many Persons? (0 - 10)\n";
	cin >> PersonsNumber;

	for (int i = 0; i < PersonsNumber; i++) {
		ReadInfo(Persons[i], i + 1);
		cout << endl;
	}

}
void PrintInfo(strInfo Person) {
	cout << "***************************************\n";
	cout << format("FirstName: {}\n", Person.FirstName);
	cout << format("LastName: {}\n", Person.LastName);
	cout << format("Age: {}\n", Person.Age);
	cout << format("Phone Number: {}\n", Person.Phone);
	cout << "***************************************\n\n";

}
void PrintPersonsInfo(strInfo Persons[10], short PersonsNumber) {
	for (int i = 0; i < PersonsNumber; i++) {
		cout << format("Person {} Info \n", i + 1);
		PrintInfo(Persons[i]);
	}
}


int main()
{
	strInfo Persons[10];
	short PersonsNumber = 0;

	ReadPersonsInfo(Persons, PersonsNumber);
	PrintPersonsInfo(Persons, PersonsNumber);

	return 0;
}
