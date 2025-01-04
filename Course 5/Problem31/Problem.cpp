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

void FillArrayInOrder(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		Arr[i] = i + 1;
	}
}
void PrintArray(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

void ShuffleArray(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		swap(Arr[RandomNumber(0, Length - 1)], Arr[RandomNumber(0, Length - 1)]);
	}
}

int main()
{
	srand(time(0));
	int Arr[100], NumberOfElements;
	NumberOfElements = ReadPositiveNumber("Enter How Many Elements to Fill:");
	FillArrayInOrder(Arr, NumberOfElements);

	cout << "\nArray Before Shuffle:\n";
	PrintArray(Arr, NumberOfElements);

	ShuffleArray(Arr, NumberOfElements);
	cout << "\nArray After Shuffle:\n";
	PrintArray(Arr, NumberOfElements);

}
