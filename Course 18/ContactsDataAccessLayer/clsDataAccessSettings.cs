using System;
using System.Configuration;

namespace ContactsDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;
    }
}
