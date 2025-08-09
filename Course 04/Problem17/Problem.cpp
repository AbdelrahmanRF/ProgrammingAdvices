#include <iostream>
#include <format>
using namespace std;


void ReadNumbers(float& Base, float& Height) {
	cout << "Please Enter The Base?\n";
	cin >> Base;

	cout << "Please Enter The Height?\n";
	cin >> Height;

}

float CalculateArea(float Base, float Height) {
	return (Base / 2) * Height;
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float Base, Height;

	ReadNumbers(Base, Height);
	PrintArea("The Area of Rectangle is:", CalculateArea(Base, Height));
	return 0;
}
