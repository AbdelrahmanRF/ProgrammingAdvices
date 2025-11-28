using System;
using System.Configuration;

namespace DVLD_DataAccess
{
    static class clsDataAccessingSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString;
    }
}
