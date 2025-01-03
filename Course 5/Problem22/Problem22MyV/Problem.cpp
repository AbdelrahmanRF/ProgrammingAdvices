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

void FillArrayElements(int Arr[100], int Length) {
	cout << "Enter Array Elements\n";
	for (int i = 0; i < Length; i++) {
		Arr[i] = ReadPositiveNumber(format("Element [{}]: ", i + 1));
	}
}

void PrintArray(int Arr[100], int Length) {
	cout << "Original Array: ";
	for (int i = 0; i < Length; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

void CheckRepeatedNumber(int Arr[100], int Length) {
	int NumberToCheck = ReadPositiveNumber("Enter The Number You Want to Check: ");
	int Counter = 0;

	for (int i = 0; i < Length; i++) {
		if (Arr[i] == NumberToCheck)
			Counter++;
	}

	PrintArray(Arr, Length);
	cout << format("{} is Repeated {} time(s)", NumberToCheck, Counter);
}

int main()
{
	int Arr[100], Length;

	Length = ReadPositiveNumber("Please Enter Array Length (1 - 100)");
	FillArrayElements(Arr, Length);
	CheckRepeatedNumber(Arr, Length);
}
