#include <iostream>
using namespace std;

struct stOwner {
	string Fullname;
	string Phone;
};

struct Car {
	string Brand;
	string Model;
	int Year;
	stOwner CarOwner;
};

int main()
{
	Car Car1 = { "Toyota", "Prius", 2019, {"Abdelrahman Alfar", "+962786067097"} };


	cout << Car1.Brand << endl;
	cout << Car1.Model << endl;
	cout << Car1.Year << endl;
	cout << Car1.CarOwner.Fullname << endl;
	cout << Car1.CarOwner.Phone << endl;


	return 0;
}
