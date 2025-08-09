#include <iostream>
#include <format>
using namespace std;


void Read3Marks(int& Num1, int& Num2, int& Num3) {
	cout << "Please Enter The First Number?\n";
	cin >> Num1;
	cout << "Please Enter The Second Number?\n";
	cin >> Num2;
	cout << "Please Enter The Third Number?\n";
	cin >> Num3;
}

int SumOf3Marks(int Num1, int Num2, int Num3) {
	return Num1 + Num2 + Num3;
}

float CalculateAverageOf3Marks(int Num1, int Num2, int Num3) {
	return (float)SumOf3Marks(Num1, Num2, Num3) / 3;
}

//float CalculateAverageOf3Numbers(int Num1, int Num2, int Num3) {
//	return (float)(Num1 + Num2 + Num3) / 3;
//}

void PrintResult(float Sum) {
	cout << format("\nThe Total Average of three numbers is {}\n", Sum);
}

int main()
{
	int Num1, Num2, Num3;

	Read3Marks(Num1, Num2, Num3);
	PrintResult(CalculateAverageOf3Marks(Num1, Num2, Num3));

	return 0;
}
