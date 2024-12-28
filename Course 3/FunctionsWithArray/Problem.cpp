#include <iostream>
#include <format>
using namespace std;

void ReadArrayData(int Arr[100], int& Length) {
	cout << "How many numbers do you want to enter? 1 to 100" << endl;
	cin >> Length;

	for (int i = 0; i < Length; i++) {
		cout << format("Please enter Number {}\n", i + 1);
		cin >> Arr[i];
	}
}
void PrintArrayData(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		cout << format("Number[{}] : {}\n", i + 1, Arr[i]);
	}
}
int CalculateArraySum(int Arr[100], int Length) {
	int sum = 0;
	for (int i = 0; i < Length; i++) {
		sum += Arr[i];
	}
	return sum;
}
float CalculateArrayAverage(int Arr[100], int Length) {
	return CalculateArraySum(Arr, Length) / Length;
}




int main()
{
	int Arr1[100], Length = 0;
	ReadArrayData(Arr1, Length);
	PrintArrayData(Arr1, Length);

	cout << "****************************\n";
	cout << format("Sum = {}\n", CalculateArraySum(Arr1, Length));
	cout << format("Average = {}\n", CalculateArrayAverage(Arr1, Length));


	return 0;
}
