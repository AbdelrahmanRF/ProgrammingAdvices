#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To)
{
	return rand() % (To - From + 1) + From;
}
void FillMatrix(int Arr[3][3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			Arr[i][j] = RandomNumber(1, 100);
		}
	}
}

int RowSum(int Arr[3][3], short Rows, short Cols) {
	int Sum = 0;
	for (short i = 0; i < Cols; i++) {
		Sum += Arr[Rows][i];
	}
	return Sum;
}

void FillArrayWithRowSum(int Arr[3][3], int SumArr[3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		SumArr[i] = RowSum(Arr, i, 3);
	}
}

void PrintEachRowSum(int SumArr[3], short Length) {
	for (short i = 0; i < Length; i++) {
		printf("Row %d sum = %d \n", i + 1, SumArr[i]);
	}
}


void PrintMatrix(int Arr[3][3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			cout << setw(3) << Arr[i][j] << setw(9) << " ";
		}
		cout << endl;
	}
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[3][3], SumArr[3];

	FillMatrix(Arr, 3, 3);
	cout << "The Following is 3x3 Matrix:\n";
	PrintMatrix(Arr, 3, 3);

	FillArrayWithRowSum(Arr, SumArr, 3, 3);
	cout << "The the following are the sum Of each row in the matrix:\n";
	PrintEachRowSum(SumArr, 3, 3);
}
