#include <iostream>
#include <string>
#include <iomanip>
using namespace std;


void FillMatrix(int Arr[3][3], short Rows, short Cols) {
	int Num = 0;
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			Num++;
			Arr[i][j] = Num;
		}
	}
}

void PrintMatrix(int Arr[3][3], short Rows, short Cols) {
	for (short i = 0; i < Rows; i++) {
		for (short j = 0; j < Cols; j++) {
			cout << Arr[i][j] << setw(9) << " ";
		}
		cout << endl;
	}
}

int main()
{
	int Arr[3][3];

	FillMatrix(Arr, 3, 3);
	cout << "The Following is 3x3 ordered Matrix:\n";
	PrintMatrix(Arr, 3, 3);
}
