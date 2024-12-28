#include <iostream>
#include <format>
using namespace std;


int* ReadThreeNumbers() {
	int Numbers[3];
	cout << "Please Enter The First Number?\n";
	cin >> Numbers[0];
	cout << "Please Enter The Second Number?\n";
	cin >> Numbers[1];
	cout << "Please Enter The Third Number?\n";
	cin >> Numbers[2];

	return Numbers;
}

int SumThreeNumbers(int* Numbers) {
	return Numbers[0] + Numbers[1] + Numbers[2];
}

void PrintResult(int* Numbers) {
	cout << format("\n{} + {} + {} is {}\n", Numbers[0], Numbers[1], Numbers[2], SumThreeNumbers(Numbers));
}

int main()
{

	PrintResult(ReadThreeNumbers());

	return 0;
}
