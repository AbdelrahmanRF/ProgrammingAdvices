#include <iostream>
#include <format>
using namespace std;


void ReadNumbers(float& Height, float& Width) {
	cout << "Please Enter The Height?\n";
	cin >> Height;
	cout << "Please Enter The Width?\n";
	cin >> Width;
}

float CalculateArea(float Height, float Width) {
	return Height * Width;
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float Num1, Num2;

	ReadNumbers(Num1, Num2);
	PrintArea("The Area of the rectangle is:", CalculateArea(Num1, Num2));
	return 0;
}
