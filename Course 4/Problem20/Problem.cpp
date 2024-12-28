#include <iostream>
#include <format>
#include <numbers>
using namespace std;


void ReadSquareSide(float& SquareSide) {
	cout << "Please Enter The Square Side?\n";
	cin >> SquareSide;

}

float CalculateArea(float SquareSide) {
	return (numbers::pi * pow(SquareSide, 2)) / 4;
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float SquareSide;

	ReadSquareSide(SquareSide);
	PrintArea("The Area of the Circle Inscribed in a Square is:", CalculateArea(SquareSide));
	return 0;
}
