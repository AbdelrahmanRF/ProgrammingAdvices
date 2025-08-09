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


void FillArrayWithRandomNumbers(int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		Arr[i] = RandomNumber(1, 100);
	}
}

void PrintArray(int Arr[100], int Length) {
	cout << "\nArray Elements:\n";
	for (int i = 0; i < Length; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}

int FindNumber(int Number, int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		if (Arr[i] == Number)
			return i;
	}
	return -1;
}

int main()
{
	srand(time(0));
	int Arr[100], NumberOfElements, NumberToSearch, Index;
	NumberOfElements = ReadPositiveNumber("Enter How Many Elements:");
	FillArrayWithRandomNumbers(Arr, NumberOfElements);

	PrintArray(Arr, NumberOfElements);

	NumberToSearch = ReadPositiveNumber("\nPlease Enter Number To Search:");
	Index = FindNumber(NumberToSearch, Arr, NumberOfElements);
	cout << "\nNumber You Are Looking for is: " << NumberToSearch << endl;

	if (Index != -1) {
		cout << "The number found at position : " << Index << endl;
		cout << "The number found its order : " << Index + 1 << endl;
	}
	else {
		cout << "The number is not found :-(" << endl;

	}

}
