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

void PrintMatrix(int Arr[3][3], short Rows, short Cols) {
	printf("The Following is %dx%d Matrix\n", Rows, Cols);
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			cout << setw(3) << Arr[i][j] << setw(9) << " ";
		}
		cout << endl;
	}
}

int main()
{
	int Arr[3][3];
	srand((unsigned)time(NULL));
	FillMatrix(Arr, 3, 3);
	PrintMatrix(Arr, 3, 3);
}
