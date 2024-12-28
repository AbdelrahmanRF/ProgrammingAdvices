#include <iostream>
#include <format>
#include <numbers>
using namespace std;


void ReadTriangleBaseSides(float& Base, float& Side1, float& Side2) {
	cout << "Please Enter The Triangle Base?\n";
	cin >> Base;
	cout << "Please Enter The Triangle First Side?\n";
	cin >> Side1;
	cout << "Please Enter The Triangle Second Side?\n";
	cin >> Side2;

}

float CalculateArea(float Base, float Side1, float Side2) {
	float Perimeter = (Base + Side1 + Side2) / 2;
	float Area = numbers::pi *
		(pow((Base * Side1 * Side2) / (4 * sqrt(Perimeter * (Perimeter - Base) * (Perimeter - Side1) * (Perimeter - Side2))), 2));
	return Area;
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float Base, Side1, Side2;

	ReadTriangleBaseSides(Base, Side1, Side2);
	PrintArea("The Area of the Circle described around an arbitrary triangle is:", CalculateArea(Base, Side1, Side2));
	return 0;
}
