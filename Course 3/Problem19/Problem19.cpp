#include <iostream>
#include <numbers>
using namespace std;

int main()
{
	float Diameter;
	cout << "Please Enter The Diameter?\n";
	cin >> Diameter;
	cout << '\n';

	//cout << "Triangle Area is: " << 0.5 * TriHeight * TriWidth;
	cout << "Circle Area is: " << (numbers::pi * pow(Diameter, 2))/4;

	return 0;
}
