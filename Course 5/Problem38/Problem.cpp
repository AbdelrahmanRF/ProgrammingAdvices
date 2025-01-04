#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}

void AddArrayElement(int Number, int Arr[100], int& ArrayLength) {
	ArrayLength++;
	Arr[ArrayLength - 1] = Number;
}

void FillArrayWithRandomNumbers(int Arr[100], int ArrayLength) {
	for (int i = 0; i < ArrayLength; i++) {
		Arr[i] = RandomNumber(1, 100);
	}
}

void CopyOddNumbersFromArray(int srcArr[100], int distArr[100], int ArrayLength, int& Array2Length) {
	for (int i = 0; i < ArrayLength; i++) {
		if (srcArr[i] % 2 != 0)
			AddArrayElement(srcArr[i], distArr, Array2Length);
	}
}
void PrintArray(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

int main()
{
	int Arr[100], Arr2[100], ArrayLength = 0, Array2Length = 0;
	ArrayLength = ReadPositiveNumber("Please Enter Array Length:");

	cout << "\nArray 1 Elements:\n";
	FillArrayWithRandomNumbers(Arr, ArrayLength);
	PrintArray(Arr, ArrayLength);

	cout << "\nArray 2 Elements:\n";
	CopyOddNumbersFromArray(Arr, Arr2, ArrayLength, Array2Length);
	PrintArray(Arr2, Array2Length);


}
