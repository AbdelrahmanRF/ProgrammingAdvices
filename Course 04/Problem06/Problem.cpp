#include <iostream>
#include <format>
using namespace std;

struct strInfo
{
	string FirstName;
	string LastName;
};
strInfo ReadInfo() {
	strInfo Info;
	cout << "Please Enter Your FirstName?" << endl;
	cin >> Info.FirstName;
	cout << "Please Enter Your LastName?" << endl;
	cin >> Info.LastName;

	return Info;
}

string GetFullName(strInfo Info, bool isReversed) {
	return isReversed ? format("{} {}", Info.LastName, Info.FirstName) :
		format("{} {}", Info.FirstName, Info.LastName)
		;
}
void PrintFullName() {
	cout << GetFullName(ReadInfo(), false) << endl;
}

int main()
{
	PrintFullName();

	return 0;
}
