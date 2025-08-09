#include <iostream>
#include <format>
using namespace std;

enum enPassFail {
	Pass = 1,
	Fail = 2,
};

void Read3Marks(int& Num1, int& Num2, int& Num3) {
	cout << "Please Enter The First Mark?\n";
	cin >> Num1;
	cout << "Please Enter The Second Mark?\n";
	cin >> Num2;
	cout << "Please Enter The Third Mark?\n";
	cin >> Num3;
}

int SumOf3Marks(int Num1, int Num2, int Num3) {
	return Num1 + Num2 + Num3;
}

float CalculateAverageOf3Marks(int Num1, int Num2, int Num3) {
	return (float)SumOf3Marks(Num1, Num2, Num3) / 3;
}

enPassFail CheckAverage(float Average) {
	return Average >= 50 ? enPassFail::Pass : enPassFail::Fail;
}

void PrintResult(float Average, enPassFail Pass) {
	cout << format("\nYour Average: {}\n", Average);
	cout << format("\nYou Have: {}\n",
		Pass == enPassFail::Pass ? "Passed" : "Failed");
}

int main()
{
	int Num1, Num2, Num3;

	Read3Marks(Num1, Num2, Num3);
	float Average = CalculateAverageOf3Marks(Num1, Num2, Num3);
	PrintResult(Average, CheckAverage(Average));

	return 0;
}
