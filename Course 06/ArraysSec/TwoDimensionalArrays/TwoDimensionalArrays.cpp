#include <iostream>
using namespace std;


void FillMultiplicationTable(int x[10][10]) {
	//for (int i = 1; i <= 10; i++) {
	//	for (int j = 1; j <= 10; j++) {
	//		x[i - 1][j - 1] = i * j;
	//	}
	//}
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 10; j++) {
			x[i][j] = (i + 1) * (j + 1);
		}
	}
}

void PrintMultiplicationTable(int x[10][10]) {
	FillMultiplicationTable(x);

	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 10; j++) {
			printf("%0*d ", 2, x[i][j]);
		}
		cout << endl;
	}
}

int main()
{
	//int x[3][4] = {
	//	{1,2,3,4},
	//	{5,6,7,8},
	//	{9,10,11,12},
	//};

	//for (int i = 0; i < 3; i++) {
	//	for (int j = 0; j < 4; j++) {
	//		cout << x[i][j] << " ";
	//	}
	//	cout << endl;
	//}

	int x[10][10];
	PrintMultiplicationTable(x);
}
