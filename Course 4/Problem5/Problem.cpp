#include <iostream>
#include <format>
#include <string>
using namespace std;

struct strInfo {
	int Age;
	bool hasDriverLicense;
	bool hasRecommendation;
};


strInfo ReadUserInfo() {
	strInfo Info;
	cout << "Please Enter Your Age?" << endl;
	cin >> Info.Age;
	cout << "Please Enter If You Have Driver License? (1 yes , 0 No)" << endl;
	cin >> Info.hasDriverLicense;
	cout << "Please Enter If You Have Recommendation? (1 yes , 0 No)" << endl;
	cin >> Info.hasRecommendation;
	return Info;
}

bool isAccepted(strInfo Info) {
	//if (Info.hasRecommendation || (Info.Age > 21 && Info.hasDriverLicense))
	//	return true;
	//else
	//	return false;

	return Info.hasRecommendation || (Info.Age > 21 && Info.hasDriverLicense);

	//if (Info.hasRecommendation)
	//	return true;
	//else
	//	return (Info.Age > 21 && Info.hasDriverLicense);
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
