#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsUser.h"
#include "clsInputValidate.h"
#include "clsMainScreen.h"
#include "Global.h"
using namespace std;


class clsLoginScreen : protected clsScreen
{
	static bool _Login()
	{
		bool LoginFailed = false;
		short LoginTrials = 3;
		string Username, Password;
		do
		{
			if (LoginFailed)
			{
				--LoginTrials;
				cout << "\nInvalid Username/Password!\n";
				cout << "You Have " << LoginTrials << " trial(s) to Login\n\n";
			}

			if (LoginTrials == 0)
			{
				cout << "\nYour are Locked after 3 failed trails\n";
				return false;
			}

			cout << "Enter Username: ";
			Username = clsInputValidate::ReadString();

			cout << "Enter Password: ";
			Password = clsInputValidate::ReadString();

			CurrentUser = clsUser::Find(Username, Password);

			LoginFailed = CurrentUser.isEmpty();

		} while (LoginFailed);

		CurrentUser.LogRegister();
		clsMainScreen::ShowMainMenu();
		return true;
	}

public:

	static bool ShowLoginScreen()
	{
		system("cls");
		_DrawScreenHeader("\t  Login Screen");
		return _Login();
	}
};

