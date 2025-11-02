using System;
using System.Data;
using System.Linq;

namespace Datatables
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataTable EmployeesDT = new DataTable();

            EmployeesDT.Columns.Add("ID", typeof(int));
            EmployeesDT.Columns.Add("FirstName", typeof(string));
            EmployeesDT.Columns.Add("LastName", typeof(string));
            EmployeesDT.Columns.Add("Country", typeof(string));
            EmployeesDT.Columns.Add("Salary", typeof(Double));
            EmployeesDT.Columns.Add("DOB", typeof(DateTime));

            // Make ID as PK
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = EmployeesDT.Columns["ID"];
            EmployeesDT.PrimaryKey = PrimaryKeyColumns;

            EmployeesDT.Rows.Add(1, "Fares", "Haddad", "Lebanon", 4500, new DateTime(1970, 1, 1));
            EmployeesDT.Rows.Add(2, "Leila", "Mansour", "Jordan", 3400, new DateTime(1985, 5, 20));
            EmployeesDT.Rows.Add(3, "Tariq", "Ali", "Egypt", 3100, new DateTime(1992, 11, 15));
            EmployeesDT.Rows.Add(4, "Sara", "Khoury", "Jordan", 4000, new DateTime(1978, 3, 10));
            EmployeesDT.Rows.Add(5, "Omar", "Basha", "Syria", 2800, new DateTime(2000, 7, 25));

            Console.WriteLine("Employees List:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            EmployeesDT.DefaultView.Sort = "ID DESC";
            EmployeesDT = EmployeesDT.DefaultView.ToTable();
            Console.WriteLine("Employees List Sorted By ID DESC:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            EmployeesDT.DefaultView.Sort = "FirstName ASC";
            EmployeesDT = EmployeesDT.DefaultView.ToTable();
            Console.WriteLine("Employees List Sorted By Name ASC:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            DataRow[] FilteredRows;
            FilteredRows = EmployeesDT.Select("ID = 4");
            foreach (DataRow Row in FilteredRows)
            {
                // Mark for Delete
                Row.Delete();
            }
            EmployeesDT.AcceptChanges();

            Console.WriteLine("Employees List After Deletion:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            DataRow[] RowsToUpdate;

            RowsToUpdate = EmployeesDT.Select("ID = 3");

            foreach(DataRow Row in RowsToUpdate)
            {
                Row["LastName"] = "Maher";
                Row["Salary"] = "3200";
            }
            EmployeesDT.AcceptChanges();

            Console.WriteLine("Employees List After Updating Employee 3:");
            foreach (DataRow Row in EmployeesDT.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            int EmployeesCount = EmployeesDT.Rows.Count;
            double TotalEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("SUM(Salary)", string.Empty));
            double AverageEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("AVG(Salary)", string.Empty));
            double MinSalary = Convert.ToDouble(EmployeesDT.Compute("MIN(Salary)", string.Empty));
            double MaxSalary = Convert.ToDouble(EmployeesDT.Compute("MAX(Salary)", string.Empty));

            Console.WriteLine($"Count of Employees = {EmployeesCount}");
            Console.WriteLine($"Total Employee Salaries = {TotalEmployeeSalaries}");
            Console.WriteLine($"Average Employee Salaries = {AverageEmployeeSalaries}");
            Console.WriteLine($"Minimum Salary = {MinSalary}");
            Console.WriteLine($"Maximum Salary = {MaxSalary}");

            int ResultCount = 0;
            DataRow[] ResultRows;

            ResultRows = EmployeesDT.Select("Country = 'Jordan'");

            Console.WriteLine();
            Console.WriteLine("Employees List in Jordan:");
            foreach (DataRow Row in ResultRows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            EmployeesCount = ResultRows.Count();
            TotalEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("SUM(Salary)", "Country = 'Jordan'"));
            AverageEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("AVG(Salary)", "Country = 'Jordan'"));
            MinSalary = Convert.ToDouble(EmployeesDT.Compute("MIN(Salary)", "Country = 'Jordan'"));
            MaxSalary = Convert.ToDouble(EmployeesDT.Compute("MAX(Salary)", "Country = 'Jordan'"));

            Console.WriteLine($"Count of Employees = {EmployeesCount}");
            Console.WriteLine($"Total Employee Salaries = {TotalEmployeeSalaries}");
            Console.WriteLine($"Average Employee Salaries = {AverageEmployeeSalaries}");
            Console.WriteLine($"Minimum Salary = {MinSalary}");
            Console.WriteLine($"Maximum Salary = {MaxSalary}");

            ResultCount = 0;

            ResultRows = EmployeesDT.Select("Country = 'Jordan' OR Country = 'Egypt'");

            Console.WriteLine();
            Console.WriteLine("Employees List in Jordan & Egypt:");
            foreach (DataRow Row in ResultRows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();

            EmployeesCount = ResultRows.Count();
            TotalEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("SUM(Salary)", "Country = 'Jordan' OR Country = 'Egypt'"));
            AverageEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("AVG(Salary)", "Country = 'Jordan' OR Country = 'Egypt'"));
            MinSalary = Convert.ToDouble(EmployeesDT.Compute("MIN(Salary)", "Country = 'Jordan' OR Country = 'Egypt'"));
            MaxSalary = Convert.ToDouble(EmployeesDT.Compute("MAX(Salary)", "Country = 'Jordan' OR Country = 'Egypt'"));

            Console.WriteLine($"Count of Employees = {EmployeesCount}");
            Console.WriteLine($"Total Employee Salaries = {TotalEmployeeSalaries}");
            Console.WriteLine($"Average Employee Salaries = {AverageEmployeeSalaries}");
            Console.WriteLine($"Minimum Salary = {MinSalary}");
            Console.WriteLine($"Maximum Salary = {MaxSalary}");
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Clear DataTable 
            //EmployeesDT.Clear();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            DataTable EmployeesDataTable = new DataTable();

            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.ColumnName = "ID";
            dtColumn.DataType = typeof(int);
            dtColumn.AllowDBNull = false;
            dtColumn.Unique = true;
            dtColumn.Caption = "Employee ID";
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;
            dtColumn.ReadOnly = true;

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.ColumnName = "Name";
            dtColumn.DataType = typeof(string);
            dtColumn.AllowDBNull = false;
            dtColumn.Unique = false;
            dtColumn.Caption = "FullName";
            dtColumn.ReadOnly = false;

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.ColumnName = "Country";
            dtColumn.DataType = typeof(string);
            dtColumn.AllowDBNull = true;
            dtColumn.Caption = "Country of Residence";

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.ColumnName = "DOB";
            dtColumn.DataType = typeof(DateTime);
            dtColumn.AllowDBNull = false;
            dtColumn.Caption = "Date of Birth";

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.ColumnName = "Salary";
            dtColumn.DataType = typeof(decimal);
            dtColumn.AllowDBNull = false;
            dtColumn.Caption = "Annual Salary";

            EmployeesDataTable.Columns.Add(dtColumn);

            DataColumn[] PrimaryKeys = new DataColumn[1];
            PrimaryKeys[0] = EmployeesDataTable.Columns["ID"];
            EmployeesDataTable.PrimaryKey = PrimaryKeys;

            EmployeesDataTable.Rows.Add(null,"Fares Mohammad", "Jordan", new DateTime(1970,1,1), 3200);
            EmployeesDataTable.Rows.Add(null, "Amal Zaki", "Iraq", new DateTime(1980, 9, 5), 2400);

            DataRow foundRow = EmployeesDataTable.Rows.Find(1);
            Console.WriteLine(foundRow["Name"]);
            Console.WriteLine();

            Console.WriteLine("Employees List:");
            foreach (DataRow Row in EmployeesDataTable.Rows)
            {
                Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}" +
                    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
            }
            Console.WriteLine();
        }
    }
}
