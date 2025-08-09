#include <iostream>
#include <format>
using namespace std;

enum enOperationType {
	Divide = '/',
	Multiply = '*',
	Add = '+',
	Subtract = '-'
};

float ReadNumber(string Message) {
	float Num;
	cout << Message << endl;
	cin >> Num;

	return Num;
}

enOperationType ReadOperationType() {
	char OperationType;
	cout << "Please Enter The Operation Type\n";
	cin >> OperationType;

	return (enOperationType)OperationType;
}

float Calculate(float Num1, float Num2, enOperationType OperationType) {
	switch (OperationType)
	{
	case Divide:
		return Num1 / Num2;
	case Multiply:
		return Num1 * Num2;
	case Add:
		return Num1 + Num2;
	case Subtract:
		Num1 - Num2;
	}
}
int main()
{
	float Num1 = ReadNumber("Please Enter The First Number?");
	float Num2 = ReadNumber("Please Enter The Second Number?");
	enOperationType OperationType = ReadOperationType();

	cout << "Result = " << Calculate(Num1, Num2, OperationType) << endl;
	return 0;
}
