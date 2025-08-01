#include <iostream>
using namespace std;

class clsPerson {
	class clsAddress {
		string _AddressLine1;
		string _AddressLine2;
		string _City;
		string _Country;

	public:

		clsAddress(string AddressLine1, string AddressLine2, string City, string Country) {
			_AddressLine1 = AddressLine1;             
			_AddressLine2 = AddressLine2;            
			_City = City;             
			_Country = Country;
		}
		
		void setAddressLine1(string AddressLine1) {
			_AddressLine1 = AddressLine1;
		}

		string GetAddressLine1() {
			return _AddressLine1;
		}

		void setAddressLine2(string AddressLine2) {
			_AddressLine2 = AddressLine2;
		}

		string GetAddressLine2() {
			return _AddressLine2;
		}

		void setCity(string City) {
			_City = City;
		}

		string GetCity() {
			return _City;
		}

		void setCountry(string Country) {
			_Country = Country;
		}

		string GetCountry() {
			return _Country;
		}


		void Print() {
			cout << "\nAddress:\n";
			cout << _AddressLine1 << endl;
			cout << _AddressLine2 << endl;
			cout << _City << endl;
			cout << _Country << endl;
		}
	};


	string _FullName;

public:

	clsAddress Address = clsAddress("", "", "", "");

	clsPerson(string FullName, string AddressLine1, string AddressLine2, string City, string Country) 
	{
		_FullName = FullName;
		Address = clsAddress(AddressLine1, AddressLine2, City, Country);
	}

	void setFullName(string FullName) {
		_FullName = FullName;
	}

	string GetFullName() {
		return _FullName;
	}


};

int main()
{
	clsPerson Person1("Mohammed Dawood", "Building 11", "Al-Sha'b Street", "Amman", "Jordan");

	Person1.Address.Print();

}
