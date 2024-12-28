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
	cout << FirstNum << '+' << SecondNum << '=' << FirstNum + SecondNum << endl;
	cout << FirstNum << '-' << SecondNum << '=' << FirstNum - SecondNum << endl;
	cout << FirstNum << '*' << SecondNum << '=' << FirstNum * SecondNum << endl;
	cout << FirstNum << '/' << SecondNum << '=' << FirstNum / SecondNum << endl;
	cout << FirstNum << '%' << SecondNum << '=' << FirstNum % SecondNum << endl;

	return 0;
}
