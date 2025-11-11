using System;
using System.Text.RegularExpressions;

namespace DVLD.Global_Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string Email)
        {
            string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex Reg = new Regex(Pattern);

            return Reg.IsMatch(Email);
        }

        public static bool ValidateInteger(string Number)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateFloat(string Number)
        {
            throw new NotImplementedException();
        }

        public static bool IsNumber(string Number)
        {
            throw new NotImplementedException();
        }
    }
}
