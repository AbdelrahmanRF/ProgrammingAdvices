#include <iostream>
#include <cstdlib>
//#include <ctime>  
using namespace std;


int RandomNumber(int From, int To) {
	// Range + Offset -> ex. (0-6) + 15 (will give 15-20 because of shifting the offsite) 
	int RandomNum = rand() % (To - From + 1) + From;
	return RandomNum;
}
int main()
{
	//Seeds the random number generator in C++, called only once
	srand((unsigned)time(NULL));
	//	srand(time(0));
	cout << RandomNumber(15, 20) << endl;
	cout << RandomNumber(22, 100) << endl;
	cout << RandomNumber(1, 3) << endl;
	return 0;
}
