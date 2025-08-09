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

int MinNumberInMatrix(int Matrix[3][3], int Rows, int Cols) {
	int Min = Matrix[0][0];
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			Min = Matrix[i][j] < Min ? Matrix[i][j] : Min;
		}
	}
	return Min;
}

int MaxNumberInMatrix(int Matrix[3][3], int Rows, int Cols) {
	int Max = Matrix[0][0];
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols; j++) {
			Max = Matrix[i][j] > Max ? Matrix[i][j] : Max;
		}
	}
	return Max;
}

int main()
{

	int Matrix1[3][3] = { {77,5,12},{22,20,6},{14,3,9} };

	cout << "\nMatrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	cout << "\nMinimum Number is: ";
	cout << MinNumberInMatrix(Matrix1, 3, 3);

	cout << "\n\nMax Number is: ";
	cout << MaxNumberInMatrix(Matrix1, 3, 3);

}
