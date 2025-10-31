using System;
using System.Configuration;

namespace ContactsDataAccessLayer
{
    static class clsContactDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;
    }
}
