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

int main()
{

	int Matrix1[3][3] = { {9,1,12},{0,9,1},{0,9,9} }, NumberToCheck;

	cout << "Matrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	cout << "\nEnter the number to look for in matrix? ";
	cin >> NumberToCheck;

	if (IsNumberInMatrix(Matrix1, NumberToCheck, 3, 3))
		cout << "\nYes it is there.\n";
	else
		cout << "\nNo: It's NOT there.\n";

}
