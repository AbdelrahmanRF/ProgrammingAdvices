#pragma once

#include <iomanip>
#include <iostream>
#include "clsScreen.h"
#include "clsUser.h"
using namespace std;


class clsLoginRegisterScreen : protected clsScreen
{

    static void _PrintLogRecord(clsUser::stLoginRegister Log) {
        cout << setw(8) << left << "" << "| " << setw(35) << left << Log.DateTime;
        cout << "| " << setw(20) << left << Log.Username;
        cout << "| " << setw(20) << left << Log.Password;
        cout << "| " << setw(10) << left << Log.Permissions;
    }

public:

    static void ShowLoginRegisterScreen()
    {
        vector <clsUser::stLoginRegister> vLogs = clsUser::GetLogsList();
        string Title = "\t Login Register List Screen";
        string SubTitle = "\t     (" + to_string(vLogs.size()) + ") Record(s).";

        _DrawScreenHeader(Title, SubTitle);

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "______________________________________________\n" << endl;

        cout << setw(8) << left << "" << "| " << left << setw(35) << "Date/Time";
        cout << "| " << left << setw(20) << "Username";
        cout << "| " << left << setw(20) << "Password";
        cout << "| " << left << setw(10) << "Permissions";
        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "______________________________________________\n" << endl;

        if (vLogs.size() == 0)
            cout << "\t\t\t\tNo Logins Available In the System!";
        else
            for (clsUser::stLoginRegister L : vLogs)
            {
                _PrintLogRecord(L);
                cout << endl;
            }

        cout << setw(8) << left << "" << "\n\t_______________________________________________________";
        cout << "______________________________________________\n" << endl;
    }
};

