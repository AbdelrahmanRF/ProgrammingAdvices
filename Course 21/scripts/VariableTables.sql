USE C21_DB1;

DECLARE @EmployeesTable TABLE (
	EmployeeID INT,
	Name VARCHAR(250),
	Department VARCHAR(50)
);

INSERT INTO @EmployeesTable (EmployeeId, Name, Department)
VALUES (10, 'Mohammed', 'Marketing');

INSERT INTO @EmployeesTable (EmployeeId, Name, Department)
VALUES (11, 'Ali', 'Sales');

SELECT * FROM @EmployeesTable WHERE EmployeeID = 10;