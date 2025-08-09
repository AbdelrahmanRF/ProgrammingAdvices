#include <vector>
#include <iostream>
using namespace std;

void AskAndFillVector(vector <int>& vNumbers) {
	char continueAdd = 'y';
	int Number = 0;
	do {
		cout << "Please Enter a number: ";
		cin >> Number;
		vNumbers.push_back(Number);

		cout << "\nDo you want to add more? y or n\n";
		cin >> continueAdd;

	} while (continueAdd == 'y' || continueAdd == 'Y');
}

void PrintVector(vector <int>& vNumbers) {
	cout << "\nNumber Vectors:\n\n";
	for (int Number : vNumbers) {
		cout << Number << endl;
	}
}

int main()
{
	/*vector <int> vNumbers = { 1 , 2 , 3 , 4 };
	vNumbers.push_back(5);
	vNumbers.push_back(6);
	vNumbers.push_back(7);

	for (int& Number : vNumbers) {
		cout << Number << " ";
	}*/

	vector <int> vNumbers;
	AskAndFillVector(vNumbers);
	PrintVector(vNumbers);

}

