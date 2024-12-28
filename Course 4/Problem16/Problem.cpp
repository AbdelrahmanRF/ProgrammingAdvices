#include <iostream>
#include <format>
using namespace std;


void ReadNumbers(float& SideArea, float& Diagonal) {
	cout << "Please Enter The SideArea?\n";
	cin >> SideArea;

	cout << "Please Enter The Diagonal?\n";
	cin >> Diagonal;

}

float CalculateArea(float SideArea, float Diagonal) {
	return SideArea * sqrt(pow(Diagonal, 2) - pow(SideArea, 2));
}

void PrintArea(string Message, float Area) {
	cout << format("\n{} {}\n", Message, Area);
}

int main()
{
	float SideArea, Diagonal;

	ReadNumbers(SideArea, Diagonal);
	PrintArea("The Area of Rectangle area Through Diagonal and Side Area is:",
		CalculateArea(SideArea, Diagonal));
	return 0;
}
