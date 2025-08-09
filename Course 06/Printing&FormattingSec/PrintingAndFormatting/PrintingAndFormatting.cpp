#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
	int Page = 1, TotalPages = 10;
	float PI = 3.14159265;

	printf("You are in page %d out of %d \n", Page, TotalPages);
	//printf("The page number = %0*d \n", 3, TotalPages);

	// Width of Number, if smaller than the specified width replace remaining with zeros
	printf("The page number = %0*d \n", 2, Page);

	cout << endl;
	//Precision specification
	printf("Precision specification of %.*f", 4, PI);

	float x = 7.0, y = 9.0;
	printf("\nThe float division is %.3f / %.3f = %.3f \n\n", x, y, x / y);

	double d = 12.45;
	printf("The double value is %.3f \n", d);
	printf("The double value is %.4f \n\n", d);


	char Name[] = "Abdelrahman";

	printf("Hello, %s \n\n", Name);

	char C = 'A';

	printf("Setting the width of c, %*c \n\n", 3, C);



	cout << "_________|____________________________________|_________|\n";
	cout << "   Code  |                Name                |   Mark  |\n";
	cout << "_________|____________________________________|_________|\n";
	cout << setw(9) << "C101" << "|" << setw(36) << "Intro To Theory and Algorithms" << "|" << setw(9) << "95" << "|" << endl;
	cout << setw(9) << "C102" << "|" << setw(36) << "Operating Systems" << "|" << setw(9) << "88" << "|" << endl;
	cout << setw(9) << "C10352" << "|" << setw(36) << "Network" << "|" << setw(9) << "75" << "|" << endl;
	cout << "_________|____________________________________|_________|\n";

}