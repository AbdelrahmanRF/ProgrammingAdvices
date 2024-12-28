#include <iostream>
#include <format>
#include <numbers>
using namespace std;


void ReadDiameter(float& Diameter) {
	cout << "Please Enter The Diameter?\n";
	cin >> Diameter;

}

float CalculateArea(float Diameter) {
	return (numbers::pi * pow(Diameter, 2)) / 4;
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float Diameter;

	ReadDiameter(Diameter);
	PrintArea("The Area of the Circle through Diameter is:", CalculateArea(Diameter));
	return 0;
}
