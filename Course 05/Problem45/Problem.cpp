#include <iostream>
using namespace std;

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}

void FillArrayWithRandomNumbers(int Arr[100], int& ArrayLength)
{
	cout << "Please Enter How Many Elements:\n";
	cin >> ArrayLength;

	for (int i = 0; i < ArrayLength; i++) {
		Arr[i] = RandomNumber(-100, 100);
	}

}

int CountNigativeNumbersInArray(int Arr[100], int ArrayLength) {
	int Counter = 0;

	for (int i = 0; i < ArrayLength; i++) {
		if (Arr[i] < 0)
			Counter++;
	}
	return Counter;
}

void PrintArray(int Arr[100], int ArrayLength)
{
	for (int i = 0; i < ArrayLength; i++)
		cout << Arr[i] << " ";
	cout << "\n";
}

int main()
{
	int Arr[100], ArrayLength = 0;

	FillArrayWithRandomNumbers(Arr, ArrayLength);
	cout << "Array elements:\n";
	PrintArray(Arr, ArrayLength);

	cout << "\nNigative Numbers Count: " << CountNigativeNumbersInArray(Arr, ArrayLength) << endl;

}
