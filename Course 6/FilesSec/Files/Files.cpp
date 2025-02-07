#include <iostream>
#include <fstream>
#include <vector>
#include <string>
using namespace std;



void LoadDataFromFileToVector(string FileName, vector <string>& vFileContent) {
	fstream File;
	File.open(FileName, ios::in);

	if (File.is_open()) {
		string Line;
		while (getline(File, Line)) {
			vFileContent.push_back(Line);
		}

		File.close();
	}
}

void SaveVectorToFile(string FileName, vector<string>& vFileContent) {
	fstream MyFile;

	//MyFile.open(FileName, ios::out | ios::app);
	MyFile.open(FileName, ios::out);

	if (MyFile.is_open()) {

		for (string& Line : vFileContent) {
			if (Line != "")
				MyFile << Line << endl;
		}

		MyFile.close();
	}
}

void DeleteRecordFromFile(string FileName, string Record) {
	vector <string> vFileContent;
	LoadDataFromFileToVector(FileName, vFileContent);

	for (string& Line : vFileContent) {
		if (Line == Record) {
			Line = "";
		}
	}
	SaveVectorToFile(FileName, vFileContent);
}

void UpdateRecordInFile(string FileName, string Record, string UpdateTo) {
	vector<string> vFileContent;
	LoadDataFromFileToVector(FileName, vFileContent);

	for (string& Line : vFileContent) {
		if (Line == Record)
			Line = UpdateTo;
	}
	SaveVectorToFile(FileName, vFileContent);
}

void PrintFileContent(string FileName) {
	fstream MyFile;

	MyFile.open(FileName, ios::in);

	if (MyFile.is_open()) {
		string Line;

		while (getline(MyFile, Line)) {
			cout << Line << endl;
		}

		MyFile.close();
	}

}

int main()
{
	// Create file and add/Append string to file
	//fstream MyFile;

	//MyFile.open("MyFile.txt", ios::out | ios::app);

	//if (MyFile.is_open()) {
	//	MyFile << "Another Line\n";

	//	MyFile.close();
	//}

	// LoadDataFromFileToVector
	//PrintFileContent("MyFile.txt");

	//vector <string> vFileContent;

	//LoadDataFromFileToVector("MyFile.txt", vFileContent);

	//for (string& Line : vFileContent) {
	//	cout << Line << endl;
	//}

	// Save Vector to file
	//vector <string> vFileContent{ "Ali", "Shadi", "Rami", "Nedal" };
	//SaveVectorToFile("MyFile.txt", vFileContent);
	//PrintFileContent("MyFile.txt");


	cout << "File Content Before Delete\n";
	PrintFileContent("MyFile.txt");

	//DeleteRecordFromFile("MyFile.txt", "Ali");
	UpdateRecordInFile("MyFile.txt", "Ali", "Omar");

	cout << "\n\nFile Content After Delete\n";
	PrintFileContent("MyFile.txt");
}