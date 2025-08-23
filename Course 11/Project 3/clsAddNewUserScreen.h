#pragma once


#include <iomanip>
#include <iostream>
#include <string>
#include "clsScreen.h"
#include "clsInputValidate.h"
#include "clsUser.h"
using namespace std;

class clsAddNewUserScreen : protected clsScreen
{
    static int _ReadPermissionsSet()
    {
        int Permissions = 0;
        char Answer = 'n';

        cout << "\n\nDo you want to give full access? y/n? ";
        cin >> Answer;

        if (toupper(Answer) == 'Y') return -1;

        cout << "\nDo you want to give access to :" << endl;

        cout << "Show Client List? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pListClients;

        cout << "Add New Client? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pAddNewClient;

        cout << "Delete Client? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pDeleteClient;

        cout << "Update Client? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pUpdateClients;

        cout << "Find Client? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pFindClient;

        cout << "Transactions? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pTransactions;

        cout << "Manage Users? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pManageUsers;

        cout << "Login Register? y/n? ";
        cin >> Answer;
        if (toupper(Answer) == 'Y') Permissions += clsUser::enPermissions::pLoginRegister;

        return Permissions;
    }


    static void _ReadUserInfo(clsUser& User) 
    {
        cout << "\nEnter FirstName: ";
        User.FirstName = clsInputValidate::ReadString();

        cout << "\nEnter LastName: ";
        User.LastName = clsInputValidate::ReadString();

        cout << "\nEnter Email: ";
        User.Email = clsInputValidate::ReadString();

        cout << "\nEnter Phone: ";
        User.Phone = clsInputValidate::ReadString();

        cout << "\nEnter Password: ";
        User.Password = clsInputValidate::ReadString();

        User.Permissions = _ReadPermissionsSet();
    }

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

    static void ShowAddNewUserScreen()
    {
        _DrawScreenHeader("\t Add New User Screen");

        string Username = "";

        cout << "\nPlease Enter Username: ";
        Username = clsInputValidate::ReadString();

        while (clsUser::IsUserExist(Username)) {
            cout << "\nUsername is already used, choose another one: ";
            Username = clsInputValidate::ReadString();
        }

        clsUser NewUser = clsUser::GetAddNewUserObject(Username);

        _ReadUserInfo(NewUser);

        clsUser::enSaveResults SaveResults;

        SaveResults = NewUser.Save();

        switch (SaveResults) {
        case clsUser::enSaveResults::svSucceeded:
            cout << "\nAccount Added Successfully :-)\n";
            _PrintUser(NewUser);
            break;
        case clsUser::enSaveResults::svFailedEmptyObject:
            cout << "\nError account was not saved because it's Empty";
            break;

        case clsUser::enSaveResults::svFaildUserExists:
            cout << "\nError username is already used";
            break;
        }
    }

};

