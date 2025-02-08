#include <iostream>
#include <format>
#include <string>
using namespace std;

string ReadUserName() {
	string Name;
	cout << "Please Enter Your name?" << endl;
	getline(cin, Name);

	return Name;
}

void PrintUserName(string Name) {
	cout << format("\nWelcome Mr/Mrs {}\n", Name);
}

int main()
{
	string Name = ReadUserName();
	PrintUserName(Name);
	//PrintUserName("Abdelrahman Alfar");

	return 0;
}
