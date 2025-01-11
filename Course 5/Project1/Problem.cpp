#include <iostream>
using namespace std;

//enum enGameStatus {
//	Win = 1,
//	Draw = 2,
//	Lose = 3,
//};

enum enWinner {
	Player1 = 1,
	Computer = 2,
	Draw = 3
};

enum enGameChoices {
	Stone = 1,
	Paper = 2,
	Scissors = 3
};

struct stRoundInfo {
	short RoundNumber = 0;
	enGameChoices Player1Choice;
	enGameChoices ComputerChoice;
	enWinner Winner;
	string WinnerName;
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

//string RoundWinner(enGameChoices PlayerChoice, enGameChoices ComputerChoice) {
//	enGameStatus Result = GameOutcome(PlayerChoice, ComputerChoice);
//	ScreenOutcome(Result);
//
//	switch (Result)
//	{
//	case Win:
//		++Player1Wins;
//		return "Player 1";
//	case Draw:
//		++DrawTimes;
//		return "No Winner";
//	case Lose:
//		++ComputerWins;
//		return "Computer";
//	}
//}

string WinnerName(enWinner Winner) {
	string WinnerName[3] = { "Player1" , "Computer" , "No Winner" };

	return WinnerName[Winner - 1];
}

//enWinner GameOutcome(enGameChoices PlayerChoice, enGameChoices ComputerChoice) {
//	if (PlayerChoice == ComputerChoice)
//		return enGameStatus::Draw;
//	else if (PlayerChoice == enGameChoices::Paper && ComputerChoice == enGameChoices::Stone
//		|| PlayerChoice == enGameChoices::Stone && ComputerChoice == enGameChoices::Scissors
//		|| PlayerChoice == enGameChoices::Scissors && ComputerChoice == enGameChoices::Paper)
//		return enGameStatus::Win;
//	else
//		return enGameStatus::Lose;
//}

enWinner WhoWonTheRound(stRoundInfo RoundInfo) {
	if (RoundInfo.Player1Choice == RoundInfo.ComputerChoice)
		return enWinner::Draw;
	switch (RoundInfo.Player1Choice)
	{
	case enGameChoices::Stone:
		if (RoundInfo.ComputerChoice == enGameChoices::Paper)
			return enWinner::Computer;
		break;
	case enGameChoices::Paper:
		if (RoundInfo.ComputerChoice == enGameChoices::Scissors)
			return enWinner::Computer;
		break;
	case enGameChoices::Scissors:
		if (RoundInfo.ComputerChoice == enGameChoices::Stone)
			return enWinner::Computer;
		break;
	}

	return enWinner::Player1;
}

//string GameChoice(enGameChoices GameChoice) {
//	switch (GameChoice)
//	{
//	case Stone:
//		return "Stone";
//	case Paper:
//		return "Paper";
//	case Scissors:
//		return "Scissors";
//	}
//}

string ChoiceName(enGameChoices GameChoice) {
	string arrGameChoices[3] = { "Stone" , "Paper", "Scissors" };

	return arrGameChoices[GameChoice - 1];
}

//void ScreenOutcome(enWinner GameStatus) {
//	switch (GameStatus)
//	{
//	case Win:
//		system("color 2f");
//		break;
//	case Draw:
//		system("color 6f");
//		break;
//	case Lose:
//		system("color 4f");
//		cout << "\a";
//		break;
//	}
//}

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

//int RoundsNumber, Player1Wins = 0, ComputerWins = 0, DrawTimes = 0;
//bool isGameOver = false;

//void ShowRoundResult(int RoundNumber, enGameChoices PlayerChoice, enGameChoices ComputerChoice) {
//	cout << "\n_________________Round [" << RoundNumber << "] _________________\n\n";
//	cout << "Player 1 Choice: " << GameChoice(PlayerChoice) << endl;
//	cout << "Computer Choice: " << GameChoice(ComputerChoice) << endl;
//	cout << "Round Winner   : [" << RoundWinner(PlayerChoice, ComputerChoice) << "]" << endl;
//	cout << "____________________________________________\n\n";
//}

void PrintRoundResult(stRoundInfo RoundInfo) {
	cout << "\n_________________Round [" << RoundInfo.RoundNumber << "] _________________\n\n";
	cout << "Player 1 Choice: " << ChoiceName(RoundInfo.Player1Choice) << endl;
	cout << "Computer Choice: " << ChoiceName(RoundInfo.ComputerChoice) << endl;
	cout << "Round Winner   : [" << RoundInfo.WinnerName << "]" << endl;
	cout << "____________________________________________\n\n";

	SetScreenColor(RoundInfo.Winner);
}

//string GameWinner(int Player1Wins, int ComputerWins, int DrawTimes) {
//
//	if (Player1Wins == ComputerWins || Player1Wins == ComputerWins == DrawTimes) {
//		ScreenOutcome(enGameStatus::Draw);
//		return "No Winner";
//	}
//	else if (ComputerWins > Player1Wins) {
//		ScreenOutcome(enGameStatus::Lose);
//		return "Computer";
//	}
//	else {
//		ScreenOutcome(enGameStatus::Win);
//		return "Player1";
//	}
//}

enWinner WhoWonTheGame(short Player1WinTimes, short ComputerWinTimes) {

	if (Player1WinTimes == ComputerWinTimes) {
		return enWinner::Draw;
	}
	else if (Player1WinTimes > ComputerWinTimes) {
		return enWinner::Player1;
	}
	else {
		return enWinner::Computer;
	}
}

stGameResults FillGameResults(short GameRounds, short Player1WinTimes,
	short ComputerWinTimes, short DrawTimes) {

	stGameResults GameResults;
	GameResults.GameRounds = GameRounds;
	GameResults.Player1WinTimes = Player1WinTimes;
	GameResults.ComputerWinTimes = ComputerWinTimes;
	GameResults.DrawTimes = DrawTimes;
	GameResults.Winner = WhoWonTheGame(Player1WinTimes, ComputerWinTimes);
	GameResults.WinnerName = WinnerName(GameResults.Winner);

	return GameResults;
}

//int ReadNumberInRange(int From, int To, string Message) {
//	int Num;
//	do {
//		cout << Message << endl;
//		cin >> Num;
//	} while (Num < From || Num > To);
//	return Num;
//}

enGameChoices ReadPlayer1Choice() {
	int Choice;
	do {
		cout << "Your Choice : [1] : Stone, [2] : Paper, [3] : scissors ? ";
		cin >> Choice;

	} while (Choice < 1 || Choice > 3);

	return (enGameChoices)Choice;
}

enGameChoices GetComputerChoice() {
	return (enGameChoices)RandomNumber(1, 3);
}

stGameResults PlayGame(short HowManyRounds) {
	stRoundInfo RoundInfo;
	short Player1WinTimes = 0, ComputerWinTimes = 0, DrawTimes = 0;

	for (short GameRound = 1; GameRound <= HowManyRounds; GameRound++) {
		cout << "\nRound [" << GameRound << "] begins:\n\n";
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

	return FillGameResults(HowManyRounds, Player1WinTimes,
		ComputerWinTimes, DrawTimes);
}

string Tabs(short NumberOfTabs) {
	string t = "";
	for (int i = 1; i < NumberOfTabs; i++)
	{
		t = t + "\t";
		cout << t;
	}
	return t;
}

//void EndGame() {
//	char PlayAgain;
//	cout << "\t\t\t_______________________________________________________________________\n\n";
//	cout << "\t\t\t\t\t\t+++ G a m e O v e r +++\n\n";
//	cout << "\t\t\t_______________________________________________________________________\n\n";
//	cout << "\t\t\t_____________________________[Game Results ]____________________________\n\n";
//	cout << "\t\t\tGame Rounds        : " << RoundsNumber << "\n";
//	cout << "\t\t\tPlayer1 won times  : " << Player1Wins << "\n";
//	cout << "\t\t\tComputer won times : " << ComputerWins << "\n";
//	cout << "\t\t\tDraw Times         : " << DrawTimes << "\n";
//	cout << "\t\t\tFinal Winner       : " << GameWinner(Player1Wins, ComputerWins, DrawTimes) << "\n";
//	cout << "\t\t\t_______________________________________________________________________\n\n";
//	cout << "\t\t\tDo you want to play again? Y/N? \n";
//	cin >> PlayAgain;
//
//	if (PlayAgain == 'N' || PlayAgain == 'n') {
//		system("color 0F");
//		exit(0);
//	}
//	else {
//		system("color 0F");
//		isGameOver = false;
//		Player1Wins = 0;
//		ComputerWins = 0;
//		DrawTimes = 0;
//		RoundsNumber = ReadNumberInRange(1, 10, "How Many Rounds 1 to 10?");
//		StartGame(RoundsNumber);
//	}
//}

void ShowGameOverScreen() {
	cout << Tabs(2) << "__________________________________________________________\n\n";
	cout << Tabs(2) << "                   +++ G a m e O v e r +++\n";
	cout << Tabs(2) << "__________________________________________________________\n\n";
}

void ShowFinalGameResults(stGameResults GameResults) {
	cout << Tabs(2) << "__________________________________________________________\n\n";
	cout << Tabs(2) << "______________________[Game Results]______________________\n";
	cout << Tabs(2) << "Game Rounds        : " << GameResults.GameRounds << "\n";
	cout << Tabs(2) << "Player1 won times  : " << GameResults.Player1WinTimes << "\n";
	cout << Tabs(2) << "Computer won times : " << GameResults.ComputerWinTimes << "\n";
	cout << Tabs(2) << "Draw Times         : " << GameResults.DrawTimes << "\n";
	cout << Tabs(2) << "Final Winner       : " << GameResults.WinnerName << "\n";
	cout << Tabs(2) << "__________________________________________________________\n\n";

	SetScreenColor(GameResults.Winner);
}

short ReadHowManyRounds() {
	int RoundsNumber;
	do {
		cout << "How Many Rounds 1 to 10 ? \n";
		cin >> RoundsNumber;

	} while (RoundsNumber < 1 || RoundsNumber > 10);

	return RoundsNumber;
}

void ResetScreen()
{
	system("cls");
	system("color 0F");
}

//void StartGame() {
//	int RoundsNumber = ReadNumberInRange(1, 10, "How Many Rounds 1 to 10?");
//	int PlayerChoice;
//	for (int i = 1; i <= RoundsNumber; i++) {
//		cout << "\nRound [" << i << "] begins:\n\n";
//		cout << "Your Choice: [1]:Stone, [2]:Paper, [3]:scissors? ";
//		cin >> PlayerChoice;
//
//		ShowRoundResult(i, (enGameChoices)PlayerChoice, (enGameChoices)RandomNumber(1, 3));
//	}
//	isGameOver = true;
//}

void StartGame() {
	char PlayAgain = 'Y';

	do {
		ResetScreen();
		stGameResults GameResults = PlayGame(ReadHowManyRounds());
		ShowGameOverScreen();
		ShowFinalGameResults(GameResults);
		cout << endl << Tabs(2) << "Do you want to play again? Y/N? ";
		cin >> PlayAgain;
	} while (PlayAgain == 'y' || PlayAgain == 'Y');
}



int main()
{
	srand((unsigned)time(NULL));

	StartGame();

	//while (isGameOver) {
	//	EndGame();
	//}
}
