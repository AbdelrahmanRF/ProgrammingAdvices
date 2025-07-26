#include <iostream>  
using namespace std;  

//Abstract Class / Interface
class clsMobile 
{
    virtual void Dial(string PhoneNumber) = 0;
    virtual void SendSMS(string PhoneNumber, string Text) = 0;
    virtual void TakePicture() = 0;
}; 


class clsSamsung : public clsMobile {
public: 
    void Dial(string PhoneNumber) {

    }

    void SendSMS(string PhoneNumber, string Text) {

    }

    void TakePicture() {

    }
};

int main()  
{  

}
