#include <iostream>
#include <format>
using namespace std;

string ReadText(string Message) {
	string Text;
	cout << Message << endl;
	cin >> Text;
	return Text;
}

string EncryptText(string Text, short EncryptionKey) {
	string EncryptedText = "";

	for (int i = 0; i < Text.length(); i++) {
		EncryptedText = EncryptedText + (char)(Text[i] + EncryptionKey);
	}

	return EncryptedText;
}
string DecryptText(string EncryptedText, short EncryptionKey) {
	string DecryptedText = "";
	for (int i = 0; i < EncryptedText.length(); i++) {
		DecryptedText = DecryptedText + (char)(EncryptedText[i] - EncryptionKey);
	}
	return DecryptedText;
}

int main()
{
	const short EncryptionKey = 2;
	string Text = ReadText("Please Enter Text to Encrypt:");
	string EncryptedText = EncryptText(Text, EncryptionKey);
	string DecryptedText = DecryptText(EncryptedText, EncryptionKey);

	cout << format("Text Befor Encryption: {}", Text) << endl;
	cout << format("Text After Encryption: {}", EncryptedText) << endl;
	cout << format("Text Befor Encryption: {}", DecryptedText) << endl;
}
