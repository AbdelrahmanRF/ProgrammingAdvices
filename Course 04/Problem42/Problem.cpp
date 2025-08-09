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

strTaskDuration ReadTaskDuration() {
	strTaskDuration TaskDuration;

	TaskDuration.Days = ReadPositiveNumber("Enter Total Days?");
	TaskDuration.Hours = ReadPositiveNumber("Enter Total Hours?");
	TaskDuration.Minutes = ReadPositiveNumber("Enter Total Minutes?");
	TaskDuration.Seconds = ReadPositiveNumber("Enter Total Seconds?");

	return TaskDuration;
}

int TaskDurationInSeconds(strTaskDuration TaskDuration) {
	int DurationInSeconds = 0;
	//return (TaskDuration.Days * 24 * 60 * 60) + (TaskDuration.Hours * 60 * 60)
	//	+ (TaskDuration.Minutes * 60) + TaskDuration.Seconds;
	DurationInSeconds = TaskDuration.Days * 24 * 60 * 60;
	DurationInSeconds += TaskDuration.Hours * 60 * 60;
	DurationInSeconds += TaskDuration.Minutes * 60;
	DurationInSeconds += TaskDuration.Seconds;


	return DurationInSeconds;
}

int main()
{

	cout << format("\nTotal Duration in Seconds = {}\n", TaskDurationInSeconds(ReadTaskDuration())) << endl;


	return 0;
}
