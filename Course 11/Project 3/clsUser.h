#pragma once

#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include "clsPerson.h"
#include "clsString.h"

using namespace std;

class clsUser : public clsPerson
{
	enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 };

	enMode _Mode;
	string _Username;
	string _Password;
	int _Permissions;
	bool _MarkedForDelete = false;

	static clsUser _GetEmptyUserObject()
	{
		return clsUser(EmptyMode, "", "", "", "", "", "", 0);
	}

	static clsUser _ConvertLineToUserObject(string Line, string Separator = "#//#")
	{
		vector<string> vUser = clsString::Split(Line, Separator);

		return clsUser(UpdateMode, vUser[0], vUser[1], vUser[2], vUser[3], vUser[4], vUser[5], stoi(vUser[6]));
	}

	static string _ConvertUserObjectToLine(clsUser User, string Separator = "#//#")
	{
		string UserDataLine = "";

		UserDataLine = UserDataLine + User.FirstName + Separator;
		UserDataLine = UserDataLine + User.LastName + Separator;
		UserDataLine = UserDataLine + User.Email + Separator;
		UserDataLine = UserDataLine + User.Phone + Separator;
		UserDataLine = UserDataLine + User.Username + Separator;
		UserDataLine = UserDataLine + User.Password + Separator;
		UserDataLine = UserDataLine + to_string(User.Permissions);

		return UserDataLine;
	}

	static  vector<clsUser> _LoadUsersDataFromFile()
	{
		vector<clsUser> Users;
		fstream UsersFile;

		UsersFile.open("Users.txt", ios::in);

		if (UsersFile.is_open())
		{
			string Line;

			while (getline(UsersFile, Line))
			{
				clsUser User = _ConvertLineToUserObject(Line);
				Users.push_back(User);
			}

			UsersFile.close();
		}

		return Users;
	}

	static void _SaveUsersDataToFile(vector<clsUser> Users)
	{
		fstream UsersFile;

		UsersFile.open("Users.txt", ios::out);

		if (UsersFile.is_open())
		{
			for (clsUser& User : Users) 
			{
				if (!User.MarkedForDelete())
				UsersFile << _ConvertUserObjectToLine(User) << endl;
			}

			UsersFile.close();
		}

	}

	void _Update() 
	{
		vector<clsUser> Users = _LoadUsersDataFromFile();

		for (clsUser& User : Users) {
			if (User.Username == Username) {
				User = *this;
				_SaveUsersDataToFile(Users);
				break;
			}
		}
	}

	static void _AddDataLineToFile(string Content)
	{
		fstream UsersFile;

		UsersFile.open("Users.txt", ios::out | ios::app);

		if (UsersFile.is_open())
		{
			UsersFile << Content << endl;

			UsersFile.close();
		}
	}

	void _AddNew() 
	{
		_AddDataLineToFile(_ConvertUserObjectToLine(*this));
	}

public:
	enum enPermissions
	{
		eAll = -1, pListClients = 1, pAddNewClient = 2, pDeleteClient = 4, 
		pUpdateClients = 8, pFindClient = 16, pTransactions = 32, pManageUsers = 64
	};

	clsUser(enMode Mode, string FirstName, string LastName, string Email, string Phone, string Username, string Password, int Permissions)
		: clsPerson(FirstName, LastName, Email, Phone) {

		_Mode = Mode;
		_Username = Username;
		_Password = Password;
		_Permissions = Permissions;
	}

	bool isEmpty() {
		return _Mode == enMode::EmptyMode;
	}

	bool MarkedForDelete() {
		return _MarkedForDelete;
	}

	void SetUsername(string Username) {
		_Username = Username;
	}

	string GetUsername()
	{
		return _Username;
	}

	__declspec(property(get = GetUsername, put = SetUsername)) string Username;

	void SetPassword(string Password) {
		_Password = Password;
	}

	string GetPassword()
	{
		return _Password;
	}

	__declspec(property(get = GetPassword, put = SetPassword)) string Password;

	void SetPermissions(int Permissions) {
		_Permissions = Permissions;
	}

	int GetPermissions()
	{
		return _Permissions;
	}

	__declspec(property(get = GetPermissions, put = SetPermissions)) int Permissions;

	static clsUser Find(string Username) 
	{
		fstream UsersFile;
		clsUser User = _GetEmptyUserObject();

		UsersFile.open("Users.txt", ios::in);

		if (UsersFile.is_open()) 
		{
			string Line;

			while (getline(UsersFile, Line)) 
			{
				User = _ConvertLineToUserObject(Line);
				if (User.Username == Username) 
				{
					UsersFile.close();
					return User;
				}

			}

			UsersFile.close();
		}

		return _GetEmptyUserObject();
	}

	static clsUser Find(string Username, string Password)
	{
		clsUser User = Find(Username);

		if (User.Password == Password) return User;

		return _GetEmptyUserObject();
	}


	static bool IsUserExist(string Username)
	{
		return !clsUser::Find(Username).isEmpty();
	}

	static clsUser GetAddNewUserObject(string Username)
	{
		return clsUser(AddNewMode, "", "", "", "", Username, "", 0);
	}

	enum enSaveResults { svFailedEmptyObject = 0, svSucceeded = 1, svFaildUserExists = 2 };

	enSaveResults Save()
	{
		switch (_Mode)
		{
			case EmptyMode:
				return svFailedEmptyObject;

			case UpdateMode:
				_Update();
				return svSucceeded;

			case AddNewMode:
				if (clsUser::IsUserExist(Username))
					return svFaildUserExists;

				_AddNew();
				_Mode = UpdateMode;

				return svSucceeded;
		}
	}

	bool Delete()
	{
		vector<clsUser> Users = _LoadUsersDataFromFile();

		for (clsUser& User : Users)
		{
			if (User.Username == Username)
			{
				User._MarkedForDelete = true;
				break;
			}
		}

		_SaveUsersDataToFile(Users);
		*this = _GetEmptyUserObject();

		return true;
	}


	static vector<clsUser> GetUsersList()
	{
		return _LoadUsersDataFromFile();
	}


};

