#include <iostream>
using namespace std;

enum enGameChoice {
	Stone = 1,
	Paper = 2,
	Scissors = 3
};
enum enWinner {
	Player1 = 1,
	Computer = 2,
	Draw = 3
};

struct stRoundInfo {
	short RoundNumber = 0;
	enGameChoice Player1Choice;
	enGameChoice ComputerChoice;
	enWinner Winner;
	string WinnerName = "";
};
struct stGameResults {
	short GameRounds;
	short Player1WinTimes;
	short ComputerWinTimes;
	short DrawTimes;
	enWinner Winner;
	string WinnerName = "";
};

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}
enGameChoice ReadPlayer1Choice() {
	short Choice;
	do {
		cout << "Your Choice : [1] : Stone, [2] : Paper, [3] : scissors ? ";
		cin >> Choice;
	} while (Choice < 1 || Choice > 3);
	return (enGameChoice)Choice;
}
enGameChoice GetComputerChoice() {
	return (enGameChoice)RandomNumber(1, 3);
}

enWinner WhoWonTheRound(stRoundInfo RoundInfo) {
	if (RoundInfo.Player1Choice == RoundInfo.ComputerChoice)
		return enWinner::Draw;

	switch (RoundInfo.Player1Choice)
	{
	case enGameChoice::Stone:
		if (RoundInfo.ComputerChoice == enGameChoice::Paper)
			return enWinner::Computer;
		break;
	case enGameChoice::Paper:
		if (RoundInfo.ComputerChoice == enGameChoice::Scissors)
			return enWinner::Computer;
		break;
	case enGameChoice::Scissors:
		if (RoundInfo.ComputerChoice == enGameChoice::Stone)
			return enWinner::Computer;
		break;
	}

	return enWinner::Player1;
}
string WinnerName(enWinner Winner) {
	string arrWinnerName[3] = { "Player1", "Computer", "No Winner" };
	return arrWinnerName[Winner - 1];
}

string ChoiceName(enGameChoice Choice) {
	string arrChoiceName[3] = { "Stone", "Paper", "Scissors" };
	return arrChoiceName[Choice - 1];
}

void SetScreenColor(enWinner Winner) {
	switch (Winner)
	{
	case Player1:
		system("color 2f");
		break;
	case Computer:
		system("color 4f");
		cout << "\a";
		break;
	case Draw:
		system("color 6f");
		break;
	}
}

void PrintRoundResult(stRoundInfo RoundInfo) {
	cout << "\n_________________Round [" << RoundInfo.RoundNumber << "] _________________\n\n";
	cout << "Player1 Choice :" << ChoiceName(RoundInfo.Player1Choice) << endl;
	cout << "Computer Choice:" << ChoiceName(RoundInfo.ComputerChoice) << endl;
	cout << "RoundWinner    :" << RoundInfo.WinnerName << endl;
	cout << "____________________________________________\n\n";

	SetScreenColor(RoundInfo.Winner);
}

enWinner WhoWonTheGame(short Player1WinTimes, short ComputerWinTimes) {
	if (Player1WinTimes > ComputerWinTimes)
		return enWinner::Player1;
	else if (ComputerWinTimes > Player1WinTimes)
		return enWinner::Computer;
	else
		return enWinner::Draw;
}
stGameResults FillGameResults(short HowManyRounds, short Player1WinTimes, short ComputerWinTimes, short DrawTimes) {
	stGameResults GameResults;

	GameResults.GameRounds = HowManyRounds;
	GameResults.Player1WinTimes = Player1WinTimes;
	GameResults.ComputerWinTimes = ComputerWinTimes;
	GameResults.DrawTimes = DrawTimes;
	GameResults.Winner = WhoWonTheGame(Player1WinTimes, ComputerWinTimes);
	GameResults.WinnerName = WinnerName(GameResults.Winner);

	return GameResults;
}
stGameResults PlayGame(short HowManyRounds) {
	stRoundInfo RoundInfo;
	short Player1WinTimes = 0, ComputerWinTimes = 0, DrawTimes = 0;

	for (short GameRound = 1; GameRound <= HowManyRounds; GameRound++) {
		cout << "\nRound [" << GameRound << "] Begins:\n\n";
		RoundInfo.RoundNumber = GameRound;
		RoundInfo.Player1Choice = ReadPlayer1Choice();
		RoundInfo.ComputerChoice = GetComputerChoice();
		RoundInfo.Winner = WhoWonTheRound(RoundInfo);
		RoundInfo.WinnerName = WinnerName(RoundInfo.Winner);

		if (RoundInfo.Winner == enWinner::Computer)
			ComputerWinTimes++;
		else if (RoundInfo.Winner == enWinner::Player1)
			Player1WinTimes++;
		else
			DrawTimes++;

		PrintRoundResult(RoundInfo);
	}
	return FillGameResults(HowManyRounds, Player1WinTimes, ComputerWinTimes, DrawTimes);
}

void ResetScreen() {
	system("cls");
	system("color 0F");
}

string Tabs(short NumOfTabs) {
	string Tabs = "";
	for (int i = 1; i < NumOfTabs; i++) {
		Tabs = Tabs + "\t";
		cout << Tabs;
	}
	return Tabs;
}

void ShowGameOverScreen() {
	cout << Tabs(2) << "__________________________________________________________\n\n";
	cout << Tabs(2) << "                   +++ G a m e O v e r +++\n";
	cout << Tabs(2) << "__________________________________________________________\n\n";
}
short ReadHowManyRounds() {
	short RoundsNumber;
	do {
		cout << "How many rounds 1 to 10 ?\n";
		cin >> RoundsNumber;
	} while (RoundsNumber < 1 || RoundsNumber > 10);
	return RoundsNumber;
}

void ShowFinalGameResults(stGameResults GameResults) {
	cout << Tabs(2) << "__________________________________________________________\n\n";
	cout << Tabs(2) << "______________________[Game Results]______________________\n";
	cout << Tabs(2) << "Game Rounds       : " << GameResults.GameRounds << endl;
	cout << Tabs(2) << "Player1 Won Times : " << GameResults.Player1WinTimes << endl;
	cout << Tabs(2) << "Computer Won Times: " << GameResults.ComputerWinTimes << endl;
	cout << Tabs(2) << "Draw Times        : " << GameResults.DrawTimes << endl;
	cout << Tabs(2) << "Final Winner      : " << GameResults.WinnerName << endl;
	cout << Tabs(2) << "__________________________________________________________\n\n";

	SetScreenColor(GameResults.Winner);
}
void StartGame() {
	char PlayAgain = 'Y';
	do {
		ResetScreen();
		stGameResults GameResults = PlayGame(ReadHowManyRounds());

		ShowGameOverScreen();
		ShowFinalGameResults(GameResults);

		cout << endl << Tabs(2) << "Do you want to play again? Y/N?";
		cin >> PlayAgain;

	} while (PlayAgain == 'Y' || PlayAgain == 'y');
}

int main()
{
	srand((unsigned)time(NULL));
	StartGame();
}
