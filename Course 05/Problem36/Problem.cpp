#include <iostream>
using namespace std;

int ReadNumber() {
	int Num;
	cout << "Please Enter A Number:" << endl;
	cin >> Num;
	return Num;
}

void AddArrayElement(int Number, int Arr[100], int& Length) {
	Length++;
	Arr[Length - 1] = Number;
}
void InputUserNumbersInArray(int Arr[100], int& Length) {
	//int Counter = 0;
	//bool isFinished = 0;
	bool AddMore = 1;
	do {
		/*cout << "Please Enter A Number:" << endl;
		cin >> Arr[Counter];
		Counter++;*/
		AddArrayElement(ReadNumber(), Arr, Length);
		cout << "Do You want to Add More Numbers ? [0]:No, [1]:Yes" << endl;
		cin >> AddMore;
	} while (AddMore);
	//Length = Counter;
}

void PrintArray(int Arr[100], int Length) {
	cout << "\nArray Elements:\n";
	for (int i = 0; i < Length; i++) {
		cout << Arr[i] << " ";
	}
	cout << endl;
}


int main()
{
	srand(time(0));
	int Arr[100], Length = 0;

	InputUserNumbersInArray(Arr, Length);

	cout << "\nArray Length = " << Length << endl;
	PrintArray(Arr, Length);

}
