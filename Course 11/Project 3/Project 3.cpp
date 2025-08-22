#include <iostream>
#include "clsMainScreen.h"
#include "clsLoginScreen.h"

using namespace std;

int main()
{
    while (true) 
    {
        clsLoginScreen::ShowLoginScreen();
    }

    return 0;
}
