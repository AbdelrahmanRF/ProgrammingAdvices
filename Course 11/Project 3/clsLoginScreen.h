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
	static void _Login()
	{
		bool LoginFailed = false;
		string Username, Password;
		do
		{
			if (LoginFailed) 
			{
				cout << "\nInvalid Username/Password!\n\n";
			}

			cout << "Enter Username: ";
			Username = clsInputValidate::ReadString();

			cout << "Enter Password: ";
			Password = clsInputValidate::ReadString();

			CurrentUser = clsUser::Find(Username, Password);
			
			LoginFailed = CurrentUser.isEmpty();
			

		} while (LoginFailed);

		clsMainScreen::ShowMainMenu();

	}

public:

	static void ShowLoginScreen()
	{
		system("cls");
		_DrawScreenHeader("\t  Login Screen");
		_Login();
	}
};

