#include <iostream>
using namespace std;

void FillArray(int Arr[100], int& ArrayLength)
{
	ArrayLength = 10;
	Arr[0] = 20;
	Arr[1] = 10;
	Arr[2] = 10;
	Arr[3] = 50;
	Arr[4] = 50;
	Arr[5] = 70;
	Arr[6] = 70;
	Arr[7] = 70;
	Arr[8] = 70;
	Arr[9] = 90;
}

void PrintArray(int Arr[100], int ArrayLength)
{
	for (int i = 0; i < ArrayLength; i++)
		cout << Arr[i] << " ";
	cout << "\n";
}

void AddArrayElement(int Number, int Arr[100], int& ArrayLength) {
	ArrayLength++;
	Arr[ArrayLength - 1] = Number;
}

//bool isNumberInArray(int Number, int Arr[100], int ArrayLength) {
//	for (int i = 0; i < ArrayLength; i++) {
//		if (Arr[i] == Number)
//			return 1;
//	}
//	return 0;
//}

short FindNumberPositionInArray(int Number, int Arr[100], int ArrayLength) {
	for (int i = 0; i < ArrayLength; i++) {
		if (Arr[i] == Number)
			return i;
	}
	return -1;
}

bool isNumberInArray(int Number, int Arr[100], int ArrayLength) {
	return FindNumberPositionInArray(Number, Arr, ArrayLength) != -1;
}

void CopyArrayDistinctElements(int srcArr[100], int distArr[100], int ArrayLength, int& Array2Length) {
	for (int i = 0; i < ArrayLength; i++) {
		if (!isNumberInArray(srcArr[i], distArr, Array2Length)) {
			AddArrayElement(srcArr[i], distArr, Array2Length);
		}
	}
}
int main()
{
	int Arr[100], Arr2[100], ArrayLength = 0, Array2Length = 0;
	FillArray(Arr, ArrayLength);
	cout << "Array 1 elements:\n";
	PrintArray(Arr, ArrayLength);

	CopyArrayDistinctElements(Arr, Arr2, ArrayLength, Array2Length);
	cout << "\nArray 2 Distinct Elements:\n";
	PrintArray(Arr2, Array2Length);

}
