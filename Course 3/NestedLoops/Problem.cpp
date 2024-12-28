#include <iostream>
#include <format>
using namespace std;

int ReadNumberInRange(int From, int To) {
	int Number;
	do {
		cout << format("Please Enter a Number between {} and {}", From, To) << endl;
		cin >> Number;
	} while (Number < From || Number > To);

	//while (true) {
	//	cout << format("Please Enter a Number between {} and {}", From, To) << endl;
	//	cin >> Number;

	//	if (!(Number < From || Number > To)) {
	//		break;
	//	}
	//}

	return Number;

}

int main()
{
	//for (int i = 1; i <= 10; i++) {
	//	cout << format("i={}\n", i);
	//	for (int j = 1; j <= 10; j++) {
	//		cout << format("{} * {} = {}\n", i, j, i * j);
	//	}
	//	cout << "***********************************" << endl;
	//}

	//for (int i = 10; i > 0; i--) {
	//	for (int j = 1; j <= i; j++) {
	//		cout << "*";
	//	}
	//	cout << "\n";
	//}

	//for (int i = 10; i > 0; i--) {
	//	for (int j = 1; j <= i; j++) {
	//		cout << j;
	//	}
	//	cout << "\n";
	//}

	//for (int i = 65; i <= 90; i++) {
	//	for (int j = 65; j <= 90; j++) {
	//		cout << (char)i << (char)j << '\n';
	//	}
	//	cout << endl;
	//}

	//int Number = ReadNumberInRange(1, 10);
	//cout << "\nThe Number is: " << Number << endl;

	//int Arr[10] = { 1,20,44,77,80,90,100, 8, 99, 101 };
	//int SearchFor = 77;

	//for (int i = 0; i < sizeof(Arr); i++) {
	//	cout << format("We are at iteration {}\n", i);

	//	if (Arr[i] == SearchFor) {
	//		cout << format("\n{} Found at iteration {}\n", SearchFor, i);
	//		break;
	//	}
	//}

	int Num[5], Sum = 0;

	for (int i = 0; i < 5; i++) {
		cout << format("Please Enter Number {}\n", i + 1);
		cin >> Num[i];
		if (Sum + Num[i] > 50) {
			cout << format("\nCurrent Number Will not be Added, Since sum will exceed 50 ({})\n\n", Sum + Num[i]);
			continue;
		}
		Sum += Num[i];
	}

	cout << format("The Total sum is: {}", Sum);

}
