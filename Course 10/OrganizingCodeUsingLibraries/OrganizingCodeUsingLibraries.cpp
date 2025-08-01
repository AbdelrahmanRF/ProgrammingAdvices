#include <iostream>  
#include "clsPerson.h"  
#include "clsEmployee.h"  

using namespace std;

int main()
{
    clsEmployee Employee1(10, "Mohammed", "Dawood", "MD@gmail.com", "454545", "SW", "Aramix", 700);

    Employee1.Print();
}
