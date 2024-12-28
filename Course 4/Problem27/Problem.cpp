#include <iostream>
#include <format>
using namespace std;


int ReadNumber() {
	int Num;
	cout << "Enter A Number To Print From?\n";
	cin >> Num;

	return Num;
}


void PrintNumbersFromN(int From) {
	for (int i = From; i >= 1; i--)
		cout << i << '\n';
}

int main()
{
	PrintNumbersFromN(ReadNumber());
	return 0;
}
