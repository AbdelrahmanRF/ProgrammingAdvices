#include <iostream>
#include <format>
#include <numbers>
using namespace std;


float ReadCircumference() {
	float Circumference;
	cout << "Please Enter The Circumference?\n";
	cin >> Circumference;
	return Circumference;
}

float CalculateArea(float circumference) {
	return pow(circumference, 2) / (4 * numbers::pi);
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{

	PrintArea("The Area of the Circle Along the Circumference is:", CalculateArea(ReadCircumference()));
	return 0;
}
