CREATE TABLE #EmployeesTemp (
	EmployeeID INT,
	Name VARCHAR(250),
	Department VARCHAR(50)
);

INSERT INTO #EmployeesTemp 
VALUES (1, 'Rami', 'IT')

INSERT INTO #EmployeesTemp 
VALUES (2, 'Salem', 'Sales')

SELECT * FROM #EmployeesTemp;

DROP #EmployeesTemp;