#include <iostream>
#include <string>
#include <cctype>
using namespace std;

int main()
{
	string Str = "C++ is fast, powerful, and gives you incredible control...";

	cout << Str.length() << endl;
	cout << Str.at(4) << endl;

	Str.append(" but with great power comes great responsibility.");
	cout << Str << endl;

	Str.insert(0, "C++ is a compiled, statically-typed language.");
	cout << Str << endl;

	cout << Str.substr(0, 3) << endl;

	Str.pop_back();
	cout << Str << endl;

	Str.push_back('.');
	cout << Str << endl;

	cout << Str.find("typed") << endl;

	if (Str.find("Typed") == Str.npos) {
		cout << "Typed is not found" << endl;
	}

	Str.clear();
	cout << Str << endl << endl;



	char x, y;

	x = toupper('x');
	y = tolower('Y');

	cout << "x: " << x << ", y: " << y << endl;

	cout << "y is upper? " << (isupper(y) ? "Yes" : "No") << endl;
	cout << "X is upper? " << (isupper(x) ? "Yes" : "No") << endl << endl;

	cout << "y is lower? " << (islower(y) ? "Yes" : "No") << endl;
	cout << "X is lower? " << (islower(x) ? "Yes" : "No") << endl << endl;

	cout << "9 is didgit? " << (isdigit('9') ? "Yes" : "No") << endl;
	cout << "; is punct? " << (ispunct(';') ? "Yes" : "No") << endl;

}