#include <iostream>
using namespace std;

int main()
{
	int FirstNum, SecondNum;
	cout << "Please Enter The First Number?\n";
	cin >> FirstNum;
	cout << "Please Enter The Second Number?\n";
	cin >> SecondNum;
	cout << '\n';

	cout << FirstNum << '\n' << SecondNum;

	//int Temp = FirstNum;
	//FirstNum = SecondNum;
	//SecondNum = Temp;

	FirstNum = FirstNum + SecondNum;
	SecondNum = FirstNum - SecondNum;
	FirstNum = FirstNum - SecondNum;

	cout << "\n\n";
	cout << FirstNum << '\n' << SecondNum;

	return 0;
}
