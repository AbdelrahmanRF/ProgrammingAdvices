#include <iostream>
using namespace std;

int main()
{
	float TriHeight, TriWidth;
	cout << "Please Enter The Height?\n";
	cin >> TriHeight;
	cout << "Please Enter The Width?\n";
	cin >> TriWidth;
	cout << '\n';

	//cout << "Triangle Area is: " << 0.5 * TriHeight * TriWidth;
	cout << "Triangle Area is: " << TriHeight/2 * TriWidth;

	return 0;
}
