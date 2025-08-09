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

int FindMax(int Arr[100], int ArrayLength) {
	int Max = Arr[0];

	for (int i = 1; i < ArrayLength; i++) {
		Max = max(Max, Arr[i]);
	}
	return Max;
}

int main()
{
	srand((unsigned)time(NULL));
	int Arr[100], ArrayLength;
	FillArray(Arr, ArrayLength);
	cout << "\nArray Elements:";
	PrintArray(Arr, ArrayLength);

	cout << "\nMax Number is : " << FindMax(Arr, ArrayLength);

}
