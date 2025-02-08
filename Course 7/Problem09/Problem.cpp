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

void PrintMatrix(int Arr[3][3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			cout << setw(3) << Arr[i][j] << setw(9) << " ";
		}
		cout << endl;
	}
}

void PrintMiddleRowOfMatrix(int Arr[3][3], short Rows, short Cols) {
	int MiddleRow = Rows / 2;
	for (short i = 0; i < Cols; i++) {
		//cout << setw(3) << Arr[MiddleRow][i] << setw(9) << " ";
		printf(" %0*d	", 2, Arr[MiddleRow][i]);
	}
	cout << "\n";
}
void PrintMiddleColOfMatrix(int Arr[3][3], short Rows, short Cols) {
	int MiddleCol = Cols / 2;
	for (short j = 0; j < Rows; j++) {
		printf(" %0*d	", 2, Arr[j][MiddleCol]);
	}
	cout << "\n";
}

int main()
{
	srand((unsigned)time(NULL));
	int Arr[3][3];

	FillMatrix(Arr, 3, 3);
	cout << "Matrix1:\n";
	PrintMatrix(Arr, 3, 3);

	cout << "Middle Row of Matrix1 is:\n";
	PrintMiddleRowOfMatrix(Arr, 3, 3);
	cout << "Middle Col of Matrix1 is:\n";
	PrintMiddleColOfMatrix(Arr, 3, 3);
}
