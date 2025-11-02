using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace DataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["HR_Database"].ConnectionString;

            DataSet ds = new DataSet();
            string Query = "SELECT TOP 10 * FROM Employees";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(Query, ConnectionString);

            // Automatically generate Insert/Update/Delete commands
            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(DataAdapter);

            // Fill the DataSet (no need to explicitly open connection)
            DataAdapter.Fill(ds, "Employees");


            // Get DataTable reference from DataSet
            DataTable EmployeesDT = ds.Tables["Employees"];

            Console.WriteLine("Before Update:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                $"\tGendor: {Row["Gendor"]}\tDate of Birth: {Row["DateOfBirth"]}\tSalary: {Row["MonthlySalary"]}");
            }

            DataRow[] ResultRows = EmployeesDT.Select("ID = 287");
            foreach(DataRow Row in ResultRows)
            {
                Row["MonthlySalary"] = 8500m;
                Row["BonusPerc"] = 0.1;
            }

            // Apply changes to the database
            // SqlCommandBuilder ensures the UpdateCommand is automatically generated
            DataAdapter.Update(ds, "Employees");

            Console.WriteLine("\nAfter Update:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                $"\tGendor: {Row["Gendor"]}\tDate of Birth: {Row["DateOfBirth"]}\tSalary: {Row["MonthlySalary"]}");
            }

        }
    }
}
