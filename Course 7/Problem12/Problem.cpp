#include <iostream>
using namespace std;

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}

void FillMatrixWithRandomNumbers(int Matrix[3][3], int Rows, int Cols) {
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			Matrix[i][j] = RandomNumber(1, 10);
		}
	}
}

void PrintMatrix(int Matrix[3][3], int Rows, int Cols) {
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			printf("%*d    ", 0, Matrix[i][j]);
		}
		cout << "\n";
	}
}


bool areTypicalMatrices(int Matrix1[3][3], int Matrix2[3][3], int Rows, int Cols) {
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			if (Matrix1[i][j] != Matrix2[i][j])
				return false;
		}
	}
	return true;
}
int main()
{
	srand((unsigned)time(NULL));

	int Matrix1[3][3], Matrix2[3][3];
	FillMatrixWithRandomNumbers(Matrix1, 3, 3);
	cout << "\nMatrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	FillMatrixWithRandomNumbers(Matrix2, 3, 3);
	cout << "\nMatrix2:\n";
	PrintMatrix(Matrix2, 3, 3);


	if (areTypicalMatrices(Matrix1, Matrix2, 3, 3))
		cout << "\nYES: both martices are Typical.";
	else
		cout << "\nNo: martices are NOT Typical.";
}
