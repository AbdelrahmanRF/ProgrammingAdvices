#include <iostream>
#include <format>
using namespace std;


struct strTaskDuration {
	int Days, Hours, Minutes, Seconds;
};

int ReadPositiveNumber(string Message) {
	int Num;
	do {
		cout << Message << endl;
		cin >> Num;
	} while (Num <= 0);

	return Num;
}


strTaskDuration CalcTaskDuration(int TotalSeconds) {
	//strTaskDuration TaskDuration;
	//TaskDuration.Days = Seconds / (24 * 60 * 60);
	//TaskDuration.Hours = Seconds % (24 * 60 * 60) / (60 * 60);
	//TaskDuration.Minutes = Seconds % (24 * 60 * 60) % (60 * 60) / 60;
	//TaskDuration.Seconds = Seconds % (24 * 60 * 60) % (60 * 60) % 60;
	strTaskDuration TaskDuration;

	const int SecondsPerDay = 24 * 60 * 60;
	const int SecondsPerHour = 60 * 60;
	const int SecondsPerMinute = 60;

	int Remainder = 0;
	TaskDuration.Days = floor(TotalSeconds / SecondsPerDay);
	Remainder = TotalSeconds % SecondsPerDay;
	TaskDuration.Hours = floor(Remainder / SecondsPerHour);
	Remainder = Remainder % SecondsPerHour;
	TaskDuration.Minutes = floor(Remainder / SecondsPerMinute);
	Remainder = Remainder % SecondsPerMinute;
	TaskDuration.Seconds = Remainder;

	return TaskDuration;
}

int main()
{
	int TotalSeconds = ReadPositiveNumber("Please Enter Number of Seconds");
	strTaskDuration TaskDuration = CalcTaskDuration(TotalSeconds);

	cout << format("\nTotal Duration = {}:{}:{}:{}\n",
		TaskDuration.Days, TaskDuration.Hours, TaskDuration.Minutes, TaskDuration.Seconds) << endl;


	return 0;
}
