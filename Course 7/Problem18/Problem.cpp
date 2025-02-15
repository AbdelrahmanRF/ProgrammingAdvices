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

bool IsNumberInMatrix(int Matrix[3][3], int NumberToCheck, int Rows, int Cols) {
	return CountNumberInMatrix(Matrix, NumberToCheck, 3, 3) > 0;
}

void PrintIntersectedNumbers(int Matrix1[3][3], int Matrix2[3][3], int Rows, int Cols) {
	int Number = 0;
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			Number = Matrix1[i][j];
			if (IsNumberInMatrix(Matrix2, Number, 3, 3))
				cout << setw(3) << Number << "      ";
		}
	}
}

int main()
{

	int Matrix1[3][3] = { {77,5,12},{22,20,1},{1,0,9} };
	int Matrix2[3][3] = { {5,80,90},{22,77,1},{10,8,33} };

	cout << "\nMatrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	cout << "\nMatrix2:\n";
	PrintMatrix(Matrix2, 3, 3);

	cout << "\nIntersected Numbers are: \n\n";
	PrintIntersectedNumbers(Matrix1, Matrix2, 3, 3);

}
