using System;
using System.Data;
using System.Linq;

namespace Dataset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDT = new DataTable("EmployeesDT");
            EmployeesDT.Columns.Add("ID", typeof(int));
            EmployeesDT.Columns.Add("Name", typeof(string));
            EmployeesDT.Columns.Add("Country", typeof(string));
            EmployeesDT.Columns.Add("DOB", typeof(DateTime));
            EmployeesDT.Columns.Add("Salary", typeof(Double));

            EmployeesDT.Rows.Add(1, "Fares Haddad", "Lebanon", new DateTime(1970, 1, 1), 3000.00);
            EmployeesDT.Rows.Add(2, "Ahmad Al-Hassan", "Jordan", new DateTime(1990, 5, 15), 75000.50);
            EmployeesDT.Rows.Add(3, "Sara Khaled", "Jordan", new DateTime(1995, 11, 28), 62000.00);
            EmployeesDT.Rows.Add(4, "Omar Abdulaziz", "UAE", new DateTime(1985, 3, 10), 98500.25);
            EmployeesDT.Rows.Add(5, "Laila Hassan", "Egypt", new DateTime(1982, 7, 20), 45000.00);

            DataTable DepartmentsDT = new DataTable("DepartmentsDT");
            DepartmentsDT.Columns.Add("DeptID", typeof(int));
            DepartmentsDT.Columns.Add("DeptName", typeof(string));

            DepartmentsDT.Rows.Add(1, "Information Technology");
            DepartmentsDT.Rows.Add(2, "Human Resources");
            DepartmentsDT.Rows.Add(3, "Finance");

            Console.WriteLine("Employees List");
            foreach(DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}" +
                $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            Console.WriteLine("Departments List");
            foreach (DataRow Row in DepartmentsDT.Rows)
            {
                Console.WriteLine($"Department: ID: {Row["DeptID"]}\tName: {Row["DeptName"]}");
            }
            Console.WriteLine();

            DataSet ds = new DataSet();

            ds.Tables.Add(EmployeesDT);
            ds.Tables.Add(DepartmentsDT);

            Console.WriteLine("Employees List");
            foreach (DataRow Row in ds.Tables["EmployeesDT"].Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}" +
                $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();
        }
    }
}
