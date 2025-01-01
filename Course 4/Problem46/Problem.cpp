#include <iostream>
#include <format>
using namespace std;


void PrintAlphabets() {
	for (int i = 65; i <= 90; i++) {
		cout << char(i) << endl;
	};
}

int main()
{
	PrintAlphabets();
}
