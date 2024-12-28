#include <iostream>
#include <numbers>
using namespace std;

int main()
{
	float IsoTriangleSideHeight, IsoTriangleBaseHeight;
	cout << "Please Enter The Triangle Side Height?\n";
	cin >> IsoTriangleSideHeight;
	cout << "Please Enter The Triangle Base Height?\n";
	cin >> IsoTriangleBaseHeight;
	cout << '\n';

	cout << "Circle Area Inscribed in an Isosceles Triangle, is: " << numbers::pi * (pow(IsoTriangleBaseHeight, 2) / 4) * ((2 * IsoTriangleSideHeight - IsoTriangleBaseHeight) / (2 * IsoTriangleSideHeight + IsoTriangleBaseHeight));
		

	return 0;
}
