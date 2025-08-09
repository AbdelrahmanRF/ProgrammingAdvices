#include <iostream>
#include <format>
using namespace std;

int main()
{
	int FirstNum, SecondNum, ThirdNumber;
	cout << "Please Enter The First Number?\n";
	cin >> FirstNum;
	cout << "Please Enter The Second Number?\n";
	cin >> SecondNum;
	cout << "Please Enter The Third Number?\n";
	cin >> ThirdNumber;
	cout << '\n';

	cout << format("{}+{}+{}={}", FirstNum, SecondNum, ThirdNumber, FirstNum + SecondNum + ThirdNumber);

	return 0;
}
