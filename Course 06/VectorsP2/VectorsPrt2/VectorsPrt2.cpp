#include <iostream>
#include <vector>
using namespace std;

int main()
{
	vector<int> Nums{ 1,2,3,4 };

	cout << "Element at Index 0: " << Nums.at(0) << endl;
	cout << "Element at Index 1: " << Nums.at(1) << endl;
	cout << "Element at Index 2: " << Nums.at(2) << endl;
	cout << "Element at Index 3: " << Nums.at(3) << endl << endl;

	cout << "Element at Index 0: " << Nums[0] << endl;
	cout << "Element at Index 1: " << Nums[1] << endl;
	cout << "Element at Index 2: " << Nums[2] << endl;
	cout << "Element at Index 3: " << Nums[3] << endl << endl;


	cout << "\nUpdating vector elements\n";
	Nums.at(0) = 10;
	Nums[3] = 40;

	cout << "\nPrint vector elements\n";
	for (const int& i : Nums) {
		cout << i << " ";
	}
	cout << endl << endl;

	cout << "\nPrint vector elements using vector iterator\n";

	vector<int>::iterator iter;

	for (iter = Nums.begin(); iter != Nums.end(); iter++) {
		cout << *iter << " ";
	}


	//for (int& i : Nums) {
	//	i = 20;
	//	cout << i << " ";
	//}
}
