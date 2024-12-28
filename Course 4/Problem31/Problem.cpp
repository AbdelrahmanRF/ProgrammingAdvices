#include <iostream>
#include <format>
using namespace std;


int ReadNumber(string Message) {
	int Num;
	cout << Message << endl;
	cin >> Num;

	return Num;
}

void PowOf2_3_4(int Num) {
	cout << format("\n{}\n{}\n{}\n", pow(Num, 2), pow(Num, 3), pow(Num, 4));
}

int main()
{
	int Num = ReadNumber("Enter N");
	PowOf2_3_4(Num);
	return 0;
}
