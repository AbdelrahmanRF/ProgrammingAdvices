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

int SumMatrix(int Arr[3][3], short Rows, short Cols) {
	int Sum = 0;
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			Sum += Arr[i][j];
		}
	}
	return Sum;
}

int main()
{
	srand((unsigned)time(NULL));
	int Arr[3][3];

	FillMatrix(Arr, 3, 3);
	cout << "Matrix1:\n";
	PrintMatrix(Arr, 3, 3);

	cout << "Sum of matrix1 is: " << SumMatrix(Arr, 3, 3);

}
