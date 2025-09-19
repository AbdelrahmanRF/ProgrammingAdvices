#pragma once

#include <iostream>
#include <queue>
#include <stack>
#include "clsDate.h"

using namespace std;

class clsQueueLine
{
	
	string _Prefix;
	int _AverageServeTime;

	class clsTicket
	{
		string _Prefix;
		int _Number;
		string _DateTime;
		int _WaitingClients;
		int _AverageServeTime;
		int _ExpectedServingTime;

	public:

		clsTicket(string TicketPrefix, int Number, int WaitingClients, int AverageServeTime)
		{
			_Prefix = TicketPrefix;
			_Number = Number;
			_WaitingClients = WaitingClients;
			_AverageServeTime = AverageServeTime;
			_ExpectedServingTime = _AverageServeTime * _WaitingClients;
			_DateTime = clsDate::GetSystemDateTimeString();
		}

		string TicketPrefix()
		{
			return _Prefix;
		}

		int Number()
		{
			return _Number;
		}

		string FullNumber()
		{
			return _Prefix + to_string(_Number);
		}

		string DateTime()
		{
			return _DateTime;
		}

		int WaitingClients()
		{
			return _WaitingClients;
		}

		int ServingTime()
		{
			return _AverageServeTime;
		}

		int ExpectedServingTime()
		{
			return _ExpectedServingTime;
		}

		void Print()
		{
			cout << "\n\t\t\t  _______________________\n";
			cout << "\n\t\t\t\t    " << FullNumber();
			cout << "\n\n\t\t\t    " << _DateTime;
			cout << "\n\t\t\t    Waiting Clients = " << _WaitingClients;
			cout << "\n\t\t\t      Serve Time In";
			cout << "\n\t\t\t       " << _ExpectedServingTime << " Minutes.";
			cout << "\n\t\t\t  _______________________\n";
		}
	};

	int _TotalTickets;

public:
	
	queue<clsTicket> QueueTickets;

	clsQueueLine(string Prefix, int AverageServeTime)
	{
		_Prefix = Prefix;
		_AverageServeTime = AverageServeTime;
		_TotalTickets = 0;
	}

	void IssueTicket()
	{
		++_TotalTickets;

		clsTicket NewTicket(_Prefix, _TotalTickets, WaitingClients(), _AverageServeTime);

		QueueTickets.push(NewTicket);
	}

	int WaitingClients()
	{
		return QueueTickets.size();
	}

	int ServedClients()
	{
		return _TotalTickets - QueueTickets.size();
	}

	void PrintInfo()
	{
		cout << "\n\t\t\t _________________________\n";
		cout << "\n\t\t\t\tQueue Info";
		cout << "\n\t\t\t _________________________\n";
		cout << "\n\t\t\t    Prefix   = " << _Prefix;
		cout << "\n\t\t\t    Total Tickets   = " << _TotalTickets;
		cout << "\n\t\t\t    Served Clients  = " << ServedClients();
		cout << "\n\t\t\t    Waiting Clients  = " << WaitingClients(); ;
		cout << "\n\t\t\t _________________________\n";
		cout << "\n";
	}

	string WhoIsNext()
	{
		if (QueueTickets.empty())
			return "No Clients Left.";
		else
			return QueueTickets.front().FullNumber();
	}

	void PrintTicketsLineRTL()
	{
		if (QueueTickets.empty())
			cout << "\n\t\tTickets: No Tickets.";
		else
			cout << "\n\t\tTickets: ";

		queue<clsTicket> tempQueue = QueueTickets;


		while (!tempQueue.empty())
		{
			cout << " " << tempQueue.front().FullNumber() << " <-- ";

			tempQueue.pop();
		}

		cout << endl;
	}

	void PrintTicketsLineLTR()
	{
		if (QueueTickets.empty())
			cout << "\n\t\tTickets: No Tickets.";
		else
			cout << "\n\t\tTickets: ";

		stack<clsTicket> tempStack;
		queue<clsTicket> tempQueue = QueueTickets;


		while (!tempQueue.empty())
		{
			tempStack.push(tempQueue.front());

			tempQueue.pop();
		}

		while (!tempStack.empty())
		{
			cout << " " << tempStack.top().FullNumber() << " --> ";

			tempStack.pop();
		}

		cout << endl;
	}

	void PrintAllTickets()
	{
		cout << "\n\n\t\t\t       ---Tickets---";

		if (QueueTickets.empty())
			cout << "\n\n\t\t\t     ---No Tickets---\n";

		queue<clsTicket> tempQueue = QueueTickets;


		while (!tempQueue.empty())
		{
			tempQueue.front().Print();
			tempQueue.pop();
		}

	}

	bool ServeNextClient()
	{
		if (QueueTickets.empty())
			return false;

		QueueTickets.pop();
		return true;
	}
};

