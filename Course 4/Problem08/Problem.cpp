#include <iostream>
#include <format>
using namespace std;

enum enPassFail {
	Pass = 1,
	Fail = 2,
};

int ReadMark() {
	int Num;
	cout << "Please Enter a Mark?\n";
	cin >> Num;

	return Num;
}

//bool CheckMark(int Mark) {
//	return Mark >= 50;
//}

enPassFail CheckMark(int Mark) {
	return Mark >= 50 ? enPassFail::Pass : enPassFail::Fail;
}

void PrintResult(int Mark) {
	cout << format("\nYour Mark {} is {}\n", Mark,
		CheckMark(Mark) == enPassFail::Pass ? "Pass" : "Fail");
}

int main()
{

	PrintResult(ReadMark());

	return 0;
}
