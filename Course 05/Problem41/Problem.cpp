#include <iostream>
using namespace std;

void FillArray(int Arr[100], int& ArrayLength)
{
	ArrayLength = 6;

	Arr[0] = 10;
	Arr[1] = 20;
	Arr[2] = 30;
	Arr[3] = 30;
	Arr[4] = 20;
	Arr[5] = 10;
}

void PrintArray(int Arr[100], int ArrayLength)
{
	for (int i = 0; i < ArrayLength; i++)
		cout << Arr[i] << " ";
	cout << "\n";
}

bool isArrayPalindrome(int Arr[100], int ArrayLength) {

	for (int i = 0; i < ArrayLength / 2; i++) {
		if (Arr[i] != Arr[ArrayLength - i - 1])
			return false;
	}
	return true;
}

int main()
{
	int Arr[100], ArrayLength = 0;

	FillArray(Arr, ArrayLength);
	cout << "Array elements:\n";
	PrintArray(Arr, ArrayLength);

	if (isArrayPalindrome(Arr, ArrayLength))
		cout << "\nYes Array is Palindrome\n";
	else
		cout << "\nNo Array is not Palindrome\n";


}
