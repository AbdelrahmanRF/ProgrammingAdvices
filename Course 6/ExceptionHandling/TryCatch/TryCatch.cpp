#include <iostream>
#include <vector>
using namespace std;

int main()
{
	vector <int> Nums{ 1,2,3,4,5 };

	try
	{
		cout << Nums.at(5);
	}
	catch (...) {
		cout << "Out of bound";
	}

}
