#include <iostream>
#include <format>
using namespace std;


int ReadNumber(string Message) {
	int Num;
	cout << Message << endl;
	cin >> Num;

	return Num;
}


int CalculateSum() {
	int Num, Sum = 0, i = 1;
	do {
		Num = ReadNumber(format("Please Enter Number {}", i));
		if (Num == -99)
			break;

		Sum += Num;
		i++;
	} while (Num != 99);


	return Sum;
}
int main()
{

	cout << format("Result = {}", CalculateSum());

	return 0;
}
