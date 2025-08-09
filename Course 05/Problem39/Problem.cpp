#include <iostream>
using namespace std;

enum enPrimeNotPrime {
	Prime = 1,
	NotPrime = 2,
};

enPrimeNotPrime CheckPrime(int Num) {
	for (int i = 2; i < round(Num / 2); i++) {
		if (Num % i == 0) {
			return enPrimeNotPrime::NotPrime;
		}
	}
	return enPrimeNotPrime::Prime;
}

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}

void FillArrayWithRandomNumbers(int Arr[100], int& ArrayLength) {
	cout << "Enter How Many Number\n";
	cin >> ArrayLength;
	for (int i = 0; i < ArrayLength; i++) {
		Arr[i] = RandomNumber(1, 100);
	}
}

void AddArrayElement(int Number, int Arr[100], int& ArrayLength) {
	ArrayLength++;
	Arr[ArrayLength - 1] = Number;
}

void CopyPrimeNumbers(int srcArr[100], int distArr[100], int ArrayLength, int& Array2Length) {
	for (int i = 0; i < ArrayLength; i++) {
		if (CheckPrime(srcArr[i]) == enPrimeNotPrime::Prime) {
			AddArrayElement(srcArr[i], distArr, Array2Length);
		}
	}
}

void PrintArray(int Arr[100], int ArrayLength)
{
	for (int i = 0; i < ArrayLength; i++)
		cout << Arr[i] << " ";
	cout << "\n";
}


int main()
{
	srand((unsigned)time(NULL));
	int Arr[100], Arr2[100], ArrayLength = 0, Array2Length = 0;

	FillArrayWithRandomNumbers(Arr, ArrayLength);
	CopyPrimeNumbers(Arr, Arr2, ArrayLength, Array2Length);
	cout << "\nArray 1 elements:\n";
	PrintArray(Arr, ArrayLength);
	cout << "\nArray 2 Prime numbers:\n";
	PrintArray(Arr2, Array2Length);

}
