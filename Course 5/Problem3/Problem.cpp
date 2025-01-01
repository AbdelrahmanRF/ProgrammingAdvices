#include <iostream>
using namespace std;

//enum enPerfectNotPerfect {
//	Perfect = 1,
//	NotPerfect = 2
//};
int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);
	return Num;
}

//int SumDivisors(int Num) {
//	int Sum = 0;
//	for (int i = 1; i < Num; i++) {
//		if (Num % i == 0)
//			Sum += i;
//	}
//	return Sum;
//}

//enPerfectNotPerfect CheckPerfect(int N) {
//	if (SumDivisors(N) == N)
//		return enPerfectNotPerfect::Perfect;
//	else
//		return enPerfectNotPerfect::NotPerfect;
//}

bool isPerfect(int Num) {
	int Sum = 0;
	for (int i = 1; i < Num; i++) {
		if (Num % i == 0)
			Sum += i;
	}
	return Sum == Num;
}

void PrintResult(int N) {
	if (isPerfect(N))
		cout << N << " is a Perfect Number" << endl;
	else
		cout << N << " is not a Perfect Number" << endl;

}
// 
//void PrintResult(int N) {
//	if (CheckPerfect(N) == enPerfectNotPerfect::Perfect)
//		cout << N << " is a Perfect Number" << endl;
//	else
//		cout << N << " is not a Perfect Number" << endl;
//
//}
int main()
{
	PrintResult(ReadPositiveNumber("Please Enter a Positive Number"));
}
