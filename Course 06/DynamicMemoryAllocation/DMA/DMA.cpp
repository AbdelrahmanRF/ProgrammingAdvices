#include <iostream>
using namespace std;

int main()
{
	// declare an int pointer
	int* ptrX;

	// declare a float pointer
	float* ptrY;

	// dynamically allocate memory
	ptrX = new int;
	ptrY = new float;

	// assigning value to the memory
	*ptrX = 20;
	*ptrY = 30.54f;

	cout << *ptrX << endl;
	cout << *ptrY << endl;

	// deallocate the memory
	delete ptrX;
	delete ptrY;



	int NumberOfStudents;

	cout << "Please Enter Number of Students: ";
	cin >> NumberOfStudents;

	float* Grades = new float[NumberOfStudents];

	for (int i = 0; i < NumberOfStudents; i++) {
		cout << "Student " << i + 1 << " Grade: ";
		cin >> *(Grades + i);
	}
	cout << "\nDisplaying Grades of Students:\n";

	for (int i = 0; i < NumberOfStudents; i++) {
		cout << "Student " << i + 1 << " Grade: " << *(Grades + i) << endl;
	}

	delete[] Grades;
}

