#include <iostream>
#include "clsUtil.h";
using namespace std;

int main()
{
    clsUtil::Srand();

    cout << clsUtil::RandomNumber(7, 15) << endl;
    cout << clsUtil::GetRandomCharacter(clsUtil::MixChars) << endl;
    cout << clsUtil::GenerateWord(clsUtil::MixChars, 10) << endl;
    clsUtil::GenerateKeys(4, clsUtil::MixChars);

    cout << clsUtil::EncryptText("When one must, one can.", 4) << endl;
    cout << clsUtil::DecryptText("[lir$sri$qywx0$sri$ger2", 4) << endl;

}
