#include <iostream>
#include <format>
#include <numbers>
using namespace std;


void ReadRadius(float& Radius) {
	cout << "Please Enter The Radius?\n";
	cin >> Radius;

}

float CalculateArea(float Radius) {
	return numbers::pi * pow(Radius, 2);
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float Radius;

	ReadRadius(Radius);
	PrintArea("The Area of the Circle is:", CalculateArea(Radius));
	return 0;
}
