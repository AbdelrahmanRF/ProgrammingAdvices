#include <iostream>
#include <format>
using namespace std;

//enum enGrade {
//	A,
//	B,
//	C,
//	D,
//	E,
//	F
//};

//int ReadGrade() {
//	int Grade;
//	cout << "Please Enter Your Grade" << endl;
//	cin >> Grade;
//	return Grade;
//}

//enGrade CheckGrade(int Grade) {
//	if (Grade >= 90)
//		return enGrade::A;
//	else if (Grade >= 80)
//		return enGrade::B;
//	else if (Grade >= 70)
//		return enGrade::C;
//	else if (Grade >= 60)
//		return enGrade::B;
//	else if (Grade >= 50)
//		return enGrade::E;
//	else
//		return enGrade::F;
//}

//void PrintResult(enGrade Grade) {
//	switch (Grade)
//	{
//	case A:
//		cout << "A" << endl;
//		break;
//	case B:
//		cout << "B" << endl;
//		break;
//	case C:
//		cout << "C" << endl;
//		break;
//	case D:
//		cout << "D" << endl;
//		break;
//	case E:
//		cout << "E" << endl;
//		break;
//	case F:
//		cout << "F" << endl;
//		break;
//	}
//}

int ReadNumberInRange(int From, int To) {
	int Grade;

	do {
		cout << "Please Enter Number Between " << From << " and " << To << endl;
		cin >> Grade;
	} while (Grade < From || Grade > To);

	return Grade;
}
char GetGradeLetter(int Grade) {
	if (Grade >= 90)
		return 'A';
	else if (Grade >= 80)
		return 'B';
	else if (Grade >= 70)
		return 'C';
	else if (Grade >= 60)
		return 'B';
	else if (Grade >= 50)
		return 'E';
	else
		return 'F';
}
int main()
{
	//PrintResult(CheckGrade(ReadGrade()));

	cout << "Result = " << GetGradeLetter((ReadNumberInRange(0, 100)));
	return 0;
}
