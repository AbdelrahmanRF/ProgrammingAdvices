#include <iostream>
using namespace std;

class clsPerson 
{
private:
	//only accessible inside this class
	int Variable1 = 40;

	int Function1() {
		return 40;
	}

protected:
	//only accessible inside this class and all classes inherits this class
	int Variable2 = 20;

	int Function2() {
		return 40;
	}

public:
	//accessible for everyone outside/inside/and classes inherits this class
	string FirstName;
	string LastName;

	string Fullname() {
		return FirstName + " " + LastName;
	}

	int Function3() {
		return Function1() * Variable1 * Variable2;
	}

};

int main()
{
	clsPerson Person1;
	Person1.FirstName = "Abdelrahman";
	Person1.LastName = "Al-Far";

	cout << "Person1: " << Person1.Fullname() << endl;
	cout << Person1.Function3() << endl;
}
