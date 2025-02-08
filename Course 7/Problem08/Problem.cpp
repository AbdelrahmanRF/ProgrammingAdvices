#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}
void FillMatrix(int Arr[3][3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			Arr[i][j] = RandomNumber(1, 100);
		}
	}
}

void Multiply2Matrices(int Arr1[3][3], int Arr2[3][3], int arrMultiply[3][3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			arrMultiply[i][j] = Arr1[i][j] * Arr2[i][j];
		}
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
	int Arr1[3][3], Arr2[3][3], arrMultiply[3][3];

	FillMatrix(Arr1, 3, 3);
	cout << "Matrix1:\n";
	PrintMatrix(Arr1, 3, 3);

	FillMatrix(Arr2, 3, 3);
	cout << "Matrix2:\n";
	PrintMatrix(Arr2, 3, 3);

	Multiply2Matrices(Arr1, Arr2, arrMultiply, 3, 3);

	cout << "Results:\n";
	PrintMatrix(arrMultiply, 3, 3);
}
