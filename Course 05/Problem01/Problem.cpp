#include <iostream>
using namespace std;

//void PrintMultiplicationTable() {
//	cout << "\n			Multiplication Table from 1 to 10\n";
//	cout << "\n	1 	2 	3 	4 	5 	6 	7 	8 	9 	10\n";
//	cout << "-----------------------------------------------------------------------------------" << endl;
//
//	for (int i = 1; i <= 10; i++) {
//		if (i < 10)
//			cout << i << "  |	";
//		else
//			cout << i << " |	";
//		for (int j = 1; j <= 10; j++) {
//			cout << i * j << "	";
//		}
//		cout << endl;
//	}
//
//
//}

void PrintTableHeader() {
	cout << "\n\n\t\t\t Multiplication Table from 1 to 10\n\n";
	cout << "\t";
	for (int i = 1; i <= 10; i++) {
		cout << i << "\t";
	}
	cout << "\n-----------------------------------------------------------------------------------" << endl;
}
string ColumnSeparator(int i) {
	if (i < 10)
		return "  |";
	else
		return " |";
}
void PrintMultiplicationTable() {
	PrintTableHeader();
	for (int i = 1; i <= 10; i++) {
		cout << " " << i << ColumnSeparator(i) << "\t";
		for (int j = 1; j <= 10; j++) {
			cout << i * j << "	";
		}
		cout << endl;
	}
}

int main()
{
	PrintMultiplicationTable();

	return 0;
}
