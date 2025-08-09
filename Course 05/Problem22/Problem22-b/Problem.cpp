#include <iostream>
#include <format>
using namespace std;

int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

//void FillArrayElements(int Arr[100], int Length) {
//	cout << "Enter Array Elements\n";
//	for (int i = 0; i < Length; i++) {
//		Arr[i] = ReadPositiveNumber(format("Element [{}]: ", i + 1));
//	}
//}
void ReadArray(int Arr[100], int& ArrayLength) {
	ArrayLength = ReadPositiveNumber("Enter Number of Elements");
	cout << "\nEnter Array Elements:" << endl;
	for (int i = 0; i < ArrayLength; i++) {
		Arr[i] = ReadPositiveNumber(format("Element [{}]: ", i + 1));
	}
}

void PrintArray(int Arr[100], int ArrayLength) {
	for (int i = 0; i < ArrayLength; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

int CheckRepeatedNumber(int Arr[100], int ArrayLength, int NumberToCheck) {
	int Counter = 0;

	for (int i = 0; i < ArrayLength; i++) {
		if (Arr[i] == NumberToCheck)
			Counter++;
	}

	return Counter;
}

int main()
{
	int Arr[100], ArrayLength, NumberToCheck;
	ReadArray(Arr, ArrayLength);
	NumberToCheck = ReadPositiveNumber("Enter The Number You Want to Check: ");

	cout << "\nOriginal Array: ";
	PrintArray(Arr, ArrayLength);

	cout << format("\nNumber {} is Repeated {} time(s)\n", NumberToCheck, CheckRepeatedNumber(Arr, ArrayLength, NumberToCheck));
}
