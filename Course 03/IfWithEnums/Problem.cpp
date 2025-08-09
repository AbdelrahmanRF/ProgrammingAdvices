#include <iostream>
using namespace std;

enum enScreenColor {
	Red = 1,
	Blue = 2,
	Green = 3,
	Yellow = 4,
};
int main()
{
	short ColorChoice;
	enScreenColor ScreenColor;
	cout << "************************************\n";
	cout << "Please Chose the number of your color?\n";
	cout << "(1) Red\n";
	cout << "(2) Blue\n";
	cout << "(3) Green\n";
	cout << "(4) Yellow\n";
	cout << "************************************\n\n";
	cout << "Your choice ?\n";

	cin >> ColorChoice;

	ScreenColor = (enScreenColor)ColorChoice;

	//if (ScreenColor == enScreenColor::Red) {
	//	system("color 4F");
	//}
	//else if (ScreenColor == enScreenColor::Blue) {
	//	system("color 1F");
	//}
	//else if (ScreenColor == enScreenColor::Green) {
	//	system("color 2F");
	//}
	//else {
	//	system("color 6F");
	//}
	switch (ScreenColor) {
	case enScreenColor::Red:
		system("color 4F");
		break;
	case enScreenColor::Blue:
		system("color 1F");
		break;
	case enScreenColor::Green:
		system("color 2F");
		break;

	default:
		system("color 6F");
		break;
	}


	return 0;
}
