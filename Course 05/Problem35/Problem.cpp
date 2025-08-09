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

bool NumberIsInArray(int Number, int Arr[100], int Length) {
	for (int i = 0; i < Length; i++) {
		if (Arr[i] == Number)
			return 1;
	}
	return 0;
}

int main()
{
	srand(time(0));
	int Arr[100], NumberOfElements, NumberToSearch;
	NumberOfElements = ReadPositiveNumber("Enter How Many Elements:");
	FillArrayWithRandomNumbers(Arr, NumberOfElements);

	PrintArray(Arr, NumberOfElements);

	NumberToSearch = ReadPositiveNumber("\nPlease Enter Number To Search:");
	cout << "\nNumber You Are Looking for is: " << NumberToSearch << endl;

	if (NumberIsInArray(NumberToSearch, Arr, NumberOfElements)) {
		cout << "Yes, The number is found :-)" << endl;
	}
	else {
		cout << "No, The number is not found :-(" << endl;
	}

}
