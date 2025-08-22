#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"

class clsFindUserScreen : protected clsScreen
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

	static void ShowFindUserScreen()
	{
        _DrawScreenHeader("\t Find User Screen");

        string Username = "";
        char Confirm = 'n';

        cout << "\nPlease Enter Username: ";
        Username = clsInputValidate::ReadString();

        while (!clsUser::IsUserExist(Username)) {
            cout << "\nUsername is not found, choose another one: ";
            Username = clsInputValidate::ReadString();
        }

        clsUser User = clsUser::Find(Username);

        if (!User.isEmpty())
        {
            cout << "\nUser Found :-)\n";
        }
        else {
            cout << "\nUser is not Found :-(\n";

        }

        _PrintUser(User);
	}

};

