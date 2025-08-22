#pragma once

#include <iomanip>
#include <iostream>
#include <string>
#include "clsScreen.h"
#include "clsInputValidate.h"
#include "clsUser.h"
using namespace std;


class clsDeleteUserScreen : protected clsScreen
{
    static void _PrintUser(clsUser User)
    {
        cout << "\nUser Card:\n";
        cout << "------------------------------------------------\n";
        cout << "FirstName                 : " << User.FirstName << endl;
        cout << "LastName                  : " << User.LastName << endl;
        cout << "FullName                  : " << User.GetFullName() << endl;
        cout << "Email                     : " << User.Email << endl;
        cout << "Phone                     : " << User.Phone << endl;
        cout << "Username                  : " << User.Username << endl;
        cout << "Password                  : " << User.Password << endl;
        cout << "Permissions               : " << User.Permissions << endl;
        cout << "------------------------------------------------\n";
    }

public:

	static void ShowDeleteUserScreen()
	{
        _DrawScreenHeader("\t Delete User Screen");

        string Username = "";
        char Confirm = 'n';

        cout << "\nPlease Enter Username: ";
        Username = clsInputValidate::ReadString();

        while (!clsUser::IsUserExist(Username)) {
            cout << "\nUsername is not found, choose another one: ";
            Username = clsInputValidate::ReadString();
        }

        clsUser User = clsUser::Find(Username);
        _PrintUser(User);

        cout << "\nAre You sure you want to delete this user? (y/n) ";
        cin >> Confirm;

        if (Confirm == 'Y' || Confirm == 'y')
        {
            if (User.Delete()) {
                cout << "\nUser Deleted Successfully :-)\n";
                _PrintUser(User);
            }
            else {
                cout << "\nError User Was not Deleted\n";
            }
        }
	}
};

