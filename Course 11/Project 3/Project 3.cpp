#include <iostream>
#include <iomanip>
#include "clsBankClient.h"
#include "clsInputValidate.h"
#include "clsUtil.h"
using namespace std;

void ReadClientInfo(clsBankClient & BankClient) {
    cout << "\nEnter FirstName: ";
    BankClient.FirstName = clsInputValidate::ReadString();

    cout << "\nEnter LastName: ";
    BankClient.LastName = clsInputValidate::ReadString();

    cout << "\nEnter Email: ";
    BankClient.Email = clsInputValidate::ReadString();

    cout << "\nEnter Phone: ";
    BankClient.Phone = clsInputValidate::ReadString();

    cout << "\nEnter PinCode: ";
    BankClient.PinCode = clsInputValidate::ReadString();

    cout << "\nEnter Balance: ";
    BankClient.Balance = clsInputValidate::ReadNumber<float>();

}

void UpdateClient() {
    string AccountNumber = "";

    cout << "\nPlease Enter client Account Number: ";
    AccountNumber = clsInputValidate::ReadString();

    while (!clsBankClient::IsClientExist(AccountNumber)) {
        cout << "\nAccount number is not found, choose another one: ";
        AccountNumber = clsInputValidate::ReadString();
    }

    clsBankClient BankClient = clsBankClient::Find(AccountNumber);
    BankClient.Print();

    cout << "\n\nUpdate Client Info:";
    cout << "\n____________________\n";


    ReadClientInfo(BankClient);

    clsBankClient::enSaveResults SaveResults;

    SaveResults = BankClient.Save();

    switch (SaveResults) {
    case clsBankClient::enSaveResults::svSucceeded:
        cout << "\nAccount Updated Successfully :-)\n";
        BankClient.Print();
        break;
    case clsBankClient::enSaveResults::svFailedEmptyObject:
        cout << "\nError account was not saved because it's Empty";
        break;
    }

}

void AddNewClient() {
    string AccountNumber = "";

    cout << "\nPlease Enter client Account Number: ";
    AccountNumber = clsInputValidate::ReadString();

    while (clsBankClient::IsClientExist(AccountNumber)) {
        cout << "\nAccount number is already used, choose another one: ";
        AccountNumber = clsInputValidate::ReadString();
    } 

    clsBankClient NewClient = clsBankClient::GetAddNewClientObject(AccountNumber);

    ReadClientInfo(NewClient);

    clsBankClient::enSaveResults SaveResults;

    SaveResults = NewClient.Save();

    switch (SaveResults) {
    case clsBankClient::enSaveResults::svSucceeded:
        cout << "\nAccount Added Successfully :-)\n";
        NewClient.Print();
        break;
    case clsBankClient::enSaveResults::svFailedEmptyObject:
        cout << "\nError account was not saved because it's Empty";
        break;

    case clsBankClient::enSaveResults::svFailedAccountNumberExist:
        cout << "\nError account number is already used";
        break;
    }
}

void DeleteClient() {
    string AccountNumber = "";
    char Confirm = 'n';

    cout << "\nPlease Enter client Account Number: ";
    AccountNumber = clsInputValidate::ReadString();

    while (!clsBankClient::IsClientExist(AccountNumber)) {
        cout << "\nAccount number is not found, choose another one: ";
        AccountNumber = clsInputValidate::ReadString();
    }

    clsBankClient BankClient = clsBankClient::Find(AccountNumber);
    BankClient.Print();

    cout << "\nAre You sure you want to delete this client? (y/n) ";
    cin >> Confirm;

    if (Confirm == 'Y' || Confirm == 'y') {
        if (BankClient.Delete()) {
            cout << "\nCIient Deleted Successfully :-)\n";
            BankClient.Print();
        }
        else {
            cout << "\nError Client Was not Deleted\n";
        }
    }
}

void PrintClientRecordLine(clsBankClient BankClient){
    cout << "| " << setw(15) << left << BankClient.GetAccountNumber();
    cout << "| " << setw(20) << left << BankClient.GetFullName();
    cout << "| " << setw(12) << left << BankClient.Phone;
    cout << "| " << setw(25) << left << BankClient.Email;
    cout << "| " << setw(10) << left << BankClient.PinCode;
    cout << "| " << setw(12) << left << BankClient.Balance;
}

void ShowClientsList() {
    vector <clsBankClient> vClients = clsBankClient::GetClientsList();

    cout << "\n\t\t\t\t\tClient List (" << vClients.size() << ") Client(s).";
    cout << "\n___________________________________________________";
    cout << "_____________________________________________________\n" << endl;

    cout << "| " << left << setw(15) << "Account Number";
    cout << "| " << left << setw(20) << "Client Name";
    cout << "| " << left << setw(12) << "Phone";
    cout << "| " << left << setw(25) << "Email";
    cout << "| " << left << setw(10) << "Pin Code";
    cout << "| " << left << setw(12) << "Balance";
    cout << "\n___________________________________________________";
    cout << "_____________________________________________________\n" << endl;

    if (vClients.size() == 0)
        cout << "\t\t\t\tNo Clients Available In the System!";
    else

        for (clsBankClient Client : vClients)
        {
            PrintClientRecordLine(Client);
            cout << endl;
        }

    cout << "\n___________________________________________________";
    cout << "_____________________________________________________\n" << endl;
}

void PrintC1ientRecordBalanceLine(clsBankClient BankClient) {
    cout << "| " << left << setw(15) << BankClient.GetAccountNumber();
    cout << "| " << left << setw(30) << BankClient.GetFullName();
    cout << "| " << left << setw(12) << BankClient.Balance;
}

void ShowTotalBalances() {
    vector <clsBankClient> vClients = clsBankClient::GetClientsList();
    double TotalBalances = clsBankClient::GetTotalBalances();


    cout << "\n\t\t\tClient List (" << vClients.size() << ") Client(s).";
    cout << "\n_____________________________________";
    cout << "_______________________________________\n" << endl;

    cout << "| " << left << setw(15) << "Account Number";
    cout << "| " << left << setw(30) << "Client Name";
    cout << "| " << left << setw(12) << "Balance";
    cout << "\n_____________________________________";
    cout << "_______________________________________\n" << endl;

    if (vClients.size() == 0)
        cout << "\t\t\tNo Clients Available In the System!";
    else

        for (clsBankClient Client : vClients)
        {
            PrintC1ientRecordBalanceLine(Client);
            cout << endl;
        }

    cout << "\n_____________________________________";
    cout << "_______________________________________\n" << endl;

    cout << "\t\t\t   Total Balances = " << TotalBalances << endl;
    cout << "\t   ( " << clsUtil::ConvertNumberToText(TotalBalances) << ")";
}

int main()
{
    //clsBankClient Client1 = clsBankClient::Find("A102");
    //Client1.Print();

    //clsBankClient Client2 = clsBankClient::Find("A103", "1235");
    //Client2.Print();

    //cout << "\nIs Client Exist? " << clsBankClient::IsClientExist("A102") << endl;

    //UpdateClient();

    //AddNewClient();

    //DeleteClient();

    //ShowClientsList();
    
    ShowTotalBalances();

    return 0;
}
