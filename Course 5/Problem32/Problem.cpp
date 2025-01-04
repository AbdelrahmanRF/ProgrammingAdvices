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

void FillArrayRandomly(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		Arr[i] = RandomNumber(1, 100);
	}
}
void PrintArray(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

//void ReverseArray(int Arr[100], int Length) {
//	for (int i = 0; i < floor(Length / 2); i++) {
//		swap(Arr[i], Arr[Length - i - 1]);
//	}
//}

void CopyArrayInReverseOrder(int srcArr[100], int distArr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		distArr[i] = srcArr[Length - i - 1];
	}
}

int main()
{
	srand(time(0));
	int Arr[100], RevArr[100], NumberOfElements;
	NumberOfElements = ReadPositiveNumber("Enter How Many Elements to Fill:");
	FillArrayRandomly(Arr, NumberOfElements);

	cout << "\nOriginal Array:\n";
	PrintArray(Arr, NumberOfElements);

	CopyArrayInReverseOrder(Arr, RevArr, NumberOfElements);
	cout << "\nReversed Array:\n";
	PrintArray(RevArr, NumberOfElements);

}
