using System;
using System.Data;
using System.Linq;

namespace Dataview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDT = new DataTable();
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

            //Console.WriteLine("Employees List:");
            //foreach (DataRow Row in EmployeesDT.Rows)
            //{
            //    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}"
            //    +$"\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            //}
            //Console.WriteLine();

            DataView EmployeesDV1 = EmployeesDT.DefaultView;
            Console.WriteLine("Employees List From DataView1:");
            foreach (DataRowView Row in EmployeesDV1)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}"
                + $"\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();


            EmployeesDV1.RowFilter = "Country = 'Jordan' OR Country = 'Egypt'";
            Console.WriteLine("Employees List in Jordan & Egypt:");
            foreach (DataRowView Row in EmployeesDV1)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}"
                + $"\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            EmployeesDV1.Sort = "Country ASC";
            Console.WriteLine("Employees List in Jordan & Egypt Sorted By Country Name:");
            foreach (DataRowView Row in EmployeesDV1)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}"
                + $"\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();
        }
    }
}
