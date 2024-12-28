#include <iostream>
#include <numbers>
using namespace std;

int main()
{
	float SquareSideHeight;
	cout << "Please Enter The Square Side Height?\n";
	cin >> SquareSideHeight;
	cout << '\n';

	//cout << "Triangle Area is: " << 0.5 * TriHeight * TriWidth;
	cout << "Circle area inscribed in a square, is: " << (numbers::pi * pow(SquareSideHeight, 2)) / 4;

	return 0;
}
