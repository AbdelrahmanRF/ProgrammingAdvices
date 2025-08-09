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

// only for 3*3 matrix
//bool IsPalindromeMatrix(int Matrix[3][3], int Rows, int Cols) {
//	for (int i = 0; i < Rows; i++) {
//		if (Matrix[i][i] != Matrix[i][Rows - i - 1])
//			return false;
//	}
//	return true;
//}

bool IsPalindromeMatrix(int Matrix[3][3], int Rows, int Cols) {
	for (int i = 0; i < Rows; i++) {
		for (int j = 0; j < Cols / 2; j++) {
			if (Matrix[i][j] != Matrix[i][Cols - j - 1])
				return false;
		}
	}

	return true;
}

int main()
{

	int Matrix1[3][3] = { {1,2,1},{5,5,5},{7,3,7} };

	cout << "Matrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	if (IsPalindromeMatrix(Matrix1, 3, 3))
	{
		cout << "\nYes: Matrix is Palindrome\n";
	}
	else
		cout << "\nNo: Matrix is NOT Palindrome\n";

}
