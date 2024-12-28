#include <iostream>
#include <format>
#include <string>
using namespace std;

struct strInfo {
	int Age;
	bool hasDriverLicense;
};

//void ReadUserInfo(strInfo& Info) {
//	cout << "Please Enter Your Age?" << endl;
//	cin >> Info.Age;
//	cout << "Please Enter If You Have Driver License? (1 yes , 0 No)" << endl;
//	cin >> Info.hasDriverLicense;
//}


//void PrintHireStatus(strInfo Info) {
//	if (Info.Age > 21 && Info.hasDriverLicense)
//		cout << "\nHired\n";
//	else
//		cout << "\nRejected\n";
//}

strInfo ReadUserInfo() {
	strInfo Info;
	cout << "Please Enter Your Age?" << endl;
	cin >> Info.Age;
	cout << "Please Enter If You Have Driver License? (1 yes , 0 No)" << endl;
	cin >> Info.hasDriverLicense;

	return Info;
}

bool isAccepted(strInfo Info) {
	if (Info.Age > 21 && Info.hasDriverLicense)
		return true;
	else
		return false;
}

void PrintResult(strInfo Info) {
	if (isAccepted(Info))
		cout << "\nHired\n";
	else
		cout << "\nRejected\n";
}

int main()
{
	//strInfo Info;
	//ReadUserInfo(Info);
	PrintResult(ReadUserInfo());


	return 0;
}
