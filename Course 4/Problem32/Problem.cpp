#include <iostream>
#include <format>
using namespace std;


void ReadNumbers(int& N, int& M) {
	cout << "Please Enter Number" << endl;
	cin >> N;
	cout << "Please Enter Power" << endl;
	cin >> M;
}

int PowOfM(int N, int M) {
	if (M == 0)
		return 1;

	int Total = 1;
	for (int i = 1; i <= M; i++)
		Total = Total * N;

	return Total;
}

int main()
{
	int N, M;
	ReadNumbers(N, M);
	cout << PowOfM(N, M) << endl;
	return 0;
}
