#include <iostream>
using namespace std;

class clsPerson
{
private:
	int _ID = 10;

	string _FirstName;
	string _LastName;


public:
	// Read only property
	int GetID() {
		return _ID;
	}

	__declspec(property(get = GetID)) int ID;

	void SetFirstName(string FirstName) {
		_FirstName = FirstName;
	}

	string GetFirstName() {
		return _FirstName;
	}

	__declspec(property(get = GetFirstName, put = SetFirstName)) string FirstName;

	void SetLastName(string LastName) {
		_LastName = LastName;
	}

	string GetLastName() {
		return _LastName;
	}

	__declspec(property(get = GetLastName, put = SetLastName)) string LastName;


	string Fullname() {
		return _FirstName + " " + _LastName;
	}

};

int main()
{
	clsPerson Person1;
	clsPerson Person2;
	Person1.SetFirstName("Abdelrahman");
	Person1.SetLastName("Al-Far");

	cout << "ID               : " << Person1.GetID() << endl;
	cout << "Person1 FirstName: " << Person1.GetFirstName() << endl;
	cout << "Person1 LastName : " << Person1.GetLastName() << endl;
	cout << "Person1 Fullname : " << Person1.Fullname() << endl;



	Person2.FirstName = "Mahmoud";
	Person2.LastName = "Alfar";

	cout << "\nID               : " << Person2.ID << endl;
	cout << "Person2 FirstName: " << Person2.FirstName << endl;
	cout << "Person2 LastName : " << Person2.LastName << endl;
	cout << "Person2 Fullname : " << Person2.Fullname() << endl;
}
