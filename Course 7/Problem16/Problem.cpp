#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int Matrix[3][3], int Rows, int Cols) {
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			cout << setw(3) << Matrix[i][j] << "      ";
		}
		cout << "\n";
	}
}

int CountNumberInMatrix(int Matrix[3][3], int NumberToCheck, int Rows, int Cols) {
	int counter = 0;
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			if (Matrix[i][j] == NumberToCheck)
				counter++;
		}
	}
	return counter;
}

bool IsSparseMatrix(int Matrix[3][3], int Rows, int Cols) {
	short MatrixSize = Rows * Cols;
	return CountNumberInMatrix(Matrix, 0, 3, 3) >= ceil((float)MatrixSize / 2);
}

int main()
{

	int Matrix1[3][3] = { {0,0,12},{9,0,1},{0,0,9} };

	cout << "\nMatrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	if (IsSparseMatrix(Matrix1, 3, 3))
		cout << "\nYes: It is Sparse\n";
	else
		cout << "\nNo: It's NOT Sparse\n";
}
