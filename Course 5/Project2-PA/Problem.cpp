#include <iostream>
using namespace std;

enum enQuestionsLevel {
	Easy = 1,
	Medium = 2,
	Hard = 3,
	Mixed = 4,
};

enum enOpType {
	Add = 1,
	Sub = 2,
	Mul = 3,
	Div = 4,
	Mix = 5,
};

string GetOperationType(enOpType OpType) {
	string OpTypes[5] = { "+", "-", "*", "/", "Mix" };
	return OpTypes[OpType - 1];
}

string GetQuestionLevel(enQuestionsLevel QuestionsLevel) {
	string arrQuestionsLevel[4] = { "Easy", "Medium", "Hard", "Mix" };
	return arrQuestionsLevel[QuestionsLevel - 1];
}

int RandomNumber(int From, int To) {
	return rand() % (To - From + 1) + From;
}

void SetScreenColor(bool Right) {
	if (Right)
		system("color 2f");
	else {
		system("color 4f");
		cout << "\a";
	}
}

void ResetScreen() {
	system("cls");
	system("color 0F");
}

short ReadHowManyQuestions() {
	short Number;
	do {
		cout << "How Many Questions Do You Want To Answer ? ";
		cin >> Number;

	} while (Number < 0);
	return Number;
}

enQuestionsLevel ReadQuestionsLevel() {
	int QuestionsLevel;
	do {
		cout << "Enter Questions Level [1] Easy, [2] Med, [3] Hard, [4] Mix ? ";
		cin >> QuestionsLevel;

	} while (QuestionsLevel < 0 || QuestionsLevel > 4);
	return (enQuestionsLevel)QuestionsLevel;
}

enOpType ReadOpType() {
	int OpType;
	do {
		cout << "Enter Operation Type [1] Add, [2] Sub, [3] Mul, [4] Div, [5] Mix ? ";
		cin >> OpType;

	} while (OpType < 0 || OpType > 5);
	return (enOpType)OpType;
}

struct stQuestion {
	int Number1 = 0;
	int Number2 = 0;
	enQuestionsLevel QuestionLevel;
	enOpType OpType;
	int PlayerAnswer = 0;
	int CorrectAnswer = 0;
	bool isCorrect = false;
};

struct stQuizz {
	stQuestion QuestionsList[100];
	short NumberOfQuestions;
	short NumberOfRightAnswers = 0;
	short NumberOfWrongAnswers = 0;
	enQuestionsLevel QuestionsLevel;
	enOpType OpType;
	bool isPass = false;
};

int CalculateAnswer(int Number1, int Number2, enOpType OpType) {
	switch (OpType)
	{
	case Add:
		return Number1 + Number2;
	case Sub:
		return Number1 - Number2;
	case Mul:
		return Number1 * Number2;
	case Div:
		return Number1 / Number2;
	default:
		return Number1 + Number2;
	}
}

enOpType GenerateRandomOperation() {
	return (enOpType)RandomNumber(1, 4);
}

stQuestion GenerateQuestion(enQuestionsLevel QuestionsLevel, enOpType OpType) {
	stQuestion Question;
	Question.OpType = OpType;

	if (QuestionsLevel == enQuestionsLevel::Mixed)
		QuestionsLevel = (enQuestionsLevel)RandomNumber(1, 3);

	if (OpType == enOpType::Mix)
		Question.OpType = GenerateRandomOperation();

	switch (QuestionsLevel)
	{
	case Easy:
		Question.Number1 = RandomNumber(1, 10);
		Question.Number2 = RandomNumber(1, 10);
		Question.QuestionLevel = QuestionsLevel;
		Question.CorrectAnswer = CalculateAnswer(Question.Number1, Question.Number2, Question.OpType);
		return Question;
	case Medium:
		Question.Number1 = RandomNumber(10, 50);
		Question.Number2 = RandomNumber(10, 50);
		Question.QuestionLevel = QuestionsLevel;
		Question.CorrectAnswer = CalculateAnswer(Question.Number1, Question.Number2, Question.OpType);
		return Question;
	case Hard:
		Question.Number1 = RandomNumber(50, 100);
		Question.Number2 = RandomNumber(50, 100);
		Question.QuestionLevel = QuestionsLevel;
		Question.CorrectAnswer = CalculateAnswer(Question.Number1, Question.Number2, Question.OpType);
		return Question;
	}
	return Question;
}

void GenerateQuizzQuestions(stQuizz& Quizz) {
	for (short QuestionNumber = 0; QuestionNumber < Quizz.NumberOfQuestions; QuestionNumber++) {
		Quizz.QuestionsList[QuestionNumber] = GenerateQuestion(Quizz.QuestionsLevel, Quizz.OpType);
	}
}

int ReadAnswer() {
	int Answer = 0;
	cin >> Answer;
	return Answer;
}

void PrintQuestion(stQuizz& Quizz, short QuestionNumber) {
	cout << "\nQuestion [" << QuestionNumber + 1 << "/" << Quizz.NumberOfQuestions << "]\n\n";
	cout << Quizz.QuestionsList[QuestionNumber].Number1 << endl;
	cout << Quizz.QuestionsList[QuestionNumber].Number2 << " "
		<< GetOperationType(Quizz.QuestionsList[QuestionNumber].OpType) << "\n";
	cout << "____________" << endl;
}
void CorrectTheQuestionAnswer(stQuizz& Quizz, short QuestionNumber) {
	if (Quizz.QuestionsList[QuestionNumber].PlayerAnswer != Quizz.QuestionsList[QuestionNumber].CorrectAnswer) {
		Quizz.QuestionsList[QuestionNumber].isCorrect = false;
		Quizz.NumberOfWrongAnswers++;
		cout << "Wrong Answer :-(\n";
		cout << "The Right Answer is : " << Quizz.QuestionsList[QuestionNumber].CorrectAnswer << "\n\n\n\n";
	}
	else {
		Quizz.QuestionsList[QuestionNumber].isCorrect = true;
		Quizz.NumberOfRightAnswers++;
		cout << "Right Answer :-)\n\n\n\n";
	}
	SetScreenColor(Quizz.QuestionsList[QuestionNumber].isCorrect);
}

void AskAndCorrectQuestionListAnswers(stQuizz& Quizz) {
	for (short QuestionNumber = 0; QuestionNumber < Quizz.NumberOfQuestions; QuestionNumber++) {
		PrintQuestion(Quizz, QuestionNumber);
		Quizz.QuestionsList[QuestionNumber].PlayerAnswer = ReadAnswer();
		CorrectTheQuestionAnswer(Quizz, QuestionNumber);
	}
	Quizz.isPass = Quizz.NumberOfRightAnswers >= Quizz.NumberOfWrongAnswers;
}

string GetFinalResultsText(bool isPass) {
	if (isPass)
		return "is Pass :-)";
	else
		return "is Fail :-(";
}

void PrintQuizzResults(stQuizz Quizz) {
	cout << "__________________________________________________________\n\n";
	cout << " Final Result is " << GetFinalResultsText(Quizz.isPass) << "\n";
	cout << "__________________________________________________________\n\n";
	cout << "Number of Questions    : " << Quizz.NumberOfQuestions << endl;
	cout << "Question Level         : " << GetQuestionLevel(Quizz.QuestionsLevel) << endl;
	cout << "OpType                 : " << GetOperationType(Quizz.OpType) << endl;
	cout << "Number of Right Answers: " << Quizz.NumberOfRightAnswers << endl;
	cout << "Number of Wrong Answers: " << Quizz.NumberOfWrongAnswers << endl;
	cout << "__________________________________________________________\n\n";

	SetScreenColor(Quizz.isPass);
}

void PlayGame() {
	stQuizz Quizz;
	Quizz.NumberOfQuestions = ReadHowManyQuestions();
	Quizz.QuestionsLevel = ReadQuestionsLevel();
	Quizz.OpType = ReadOpType();
	GenerateQuizzQuestions(Quizz);
	AskAndCorrectQuestionListAnswers(Quizz);
	PrintQuizzResults(Quizz);
}

void StartGame() {
	char PlayAgain = 'Y';
	do {
		ResetScreen();
		PlayGame();

		cout << endl << "Do you want to play again? Y/N?";
		cin >> PlayAgain;

	} while (PlayAgain == 'Y' || PlayAgain == 'y');
}


int main()
{
	srand((unsigned)time(NULL));
	StartGame();
}
