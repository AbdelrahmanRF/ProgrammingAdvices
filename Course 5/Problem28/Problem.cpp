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

void FillArray(int Arr[100], int& ArrayLength) {
	ArrayLength = ReadPositiveNumber("Enter How Many Elements to Fill (1 - 100): ");

	for (int i = 0; i < ArrayLength; i++)
		Arr[i] = RandomNumber(1, 100);
}

void PrintArray(int Arr[100], int ArrayLength) {
	for (int i = 0; i < ArrayLength; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

void CopyArray(int Arr1[100], int Arr2[100], int Array1Length) {

	for (int i = 0; i < Array1Length; i++) {
		Arr2[i] = Arr1[i];
	}

}

int main()
{
	srand((unsigned)time(NULL));

	int Arr1[100], ArrayLength, Arr2[100];
	FillArray(Arr1, ArrayLength);

	cout << "\nArray 1 Elements: ";
	PrintArray(Arr1, ArrayLength);

	CopyArray(Arr1, Arr2, ArrayLength);
	cout << "\nArray 2 Elements: ";
	PrintArray(Arr2, ArrayLength);
}
