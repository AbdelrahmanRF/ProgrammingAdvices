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

bool isPrimeNumber(int Num) {
	for (int i = 2; i <= round(Num / 2); i++) {
		if (Num % i == 0)
			return 0;
	}
	return 1;
}
void CopyPrimeNumbersToArray(int sourceArray[100], int destinationArray[100], int Array1Length, int& Array2Length) {
	int Counter = 0;
	for (int i = 0; i < Array1Length; i++) {
		if (isPrimeNumber(sourceArray[i])) {
			destinationArray[Counter] = sourceArray[i];
			Counter++;
		}
	}
	Array2Length = Counter;
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr1[100], Array1Length, Arr2[100], Array2Length;
	FillArray(Arr1, Array1Length);

	cout << "\nArray 1 Elements: ";
	PrintArray(Arr1, Array1Length);

	CopyPrimeNumbersToArray(Arr1, Arr2, Array1Length, Array2Length);
	cout << "\nArray 2 Elements: ";
	PrintArray(Arr2, Array2Length);
}
