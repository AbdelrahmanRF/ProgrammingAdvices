USE C21_DB1;

SELECT * FROM Teachers;

CREATE FUNCTION dbo.GetAverageGrade(@Subject NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @AverageGrade INT;

	SELECT @AverageGrade = AVG(Grade) FROM Students
	WHERE Subject = @Subject;

	RETURN @AverageGrade;
END

---------------------------------------------------------------------
CREATE FUNCTION dbo.CalculateBonus(@PerformanceRating INT, @Salary INT)
RETURNS INT
AS
BEGIN
	DECLARE @Bonus INT;

	IF @PerformanceRating >= 5
		SET @Bonus = @Salary * 0.1;
	ELSE
		SET @Bonus = @Salary * 0.05;
	
	RETURN @Bonus;
END

---------------------------------------------------------------------
SELECT Name, Subject, dbo.GetAverageGrade(Subject) AS AverageGrade
FROM Teachers;

---------------------------------------------------------------------
DECLARE @Salary INT = 2500;
DECLARE @PerformanceRating INT = 5;
DECLARE @Bonus INT = dbo.CalculateBonus(@PerformanceRating, @Salary);

SELECT @Salary AS Salary, @Bonus AS Bonus, @Salary + @Bonus AS UpdatedSalary;