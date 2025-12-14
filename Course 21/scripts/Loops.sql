USE C21_DB1;

-- WHILE Loops

-- Example 1 - Simple Counter
DECLARE @Counter INT = 1;

WHILE @Counter <= 5
	BEGIN
		PRINT 'Counter = ' + CAST(@Counter AS VARCHAR);
		SET @Counter += 1; 
	END

PRINT '';
PRINT 'REVERSE:';
SET @Counter = 5;

WHILE @Counter > 0
	BEGIN
		PRINT 'Counter = ' + CAST(@Counter AS VARCHAR);
		SET @Counter -= 1; 
	END

-- Example 2: Iterating Over a Table
DECLARE @EmployeeID INT;
DECLARE @EmployeeName VARCHAR(50);
DECLARE @MaxID INT;

SELECT @EmployeeID = MIN(EmployeeID) FROM Employees;
SELECT @MaxID = MAX(EmployeeID) FROM Employees;

WHILE @EmployeeID IS NOT NULL AND @EmployeeID <= @MaxID
	BEGIN
		SELECT @EmployeeName = Name FROM Employees WHERE EmployeeID = @EmployeeID;
		PRINT @EmployeeName;
		SELECT @EmployeeID = MIN(EmployeeID) FROM Employees WHERE EmployeeID > @EmployeeID;
	END

-- Example 3 - Loop with Conditional Exit
DECLARE @Balance DECIMAL(10,2) = 950.00;
DECLARE @Withdrawal DECIMAL(10,2) = 100.00;

WHILE @Balance > 0
	BEGIN
		IF @Withdrawal > @Balance
			BEGIN
				PRINT 'Insufficient funds for withdrawal.';
				BREAK;
			END
		ELSE
			BEGIN
				SET @Balance = @Balance - @Withdrawal;
				PRINT 'New Balance: ' + CAST(@Balance AS VARCHAR);
			END
	END

-- Example 4 - Nested While Loops - 10 x 10 Multiplication Table
DECLARE @Row INT = 1;
DECLARE @Col INT = 1;

WHILE @Row <= 10
	BEGIN
		WHILE @Col <= 10
			BEGIN
				PRINT CAST(@Row AS VARCHAR) + ' * ' + CAST(@Col AS VARCHAR) + ' = ' + CAST((@Row * @Col) AS VARCHAR)
				SET @Col += 1;
			END

		PRINT '';
		SET @Row += 1;
		SET @Col = 1;
	END

-- Example 5 - 10 x 10 Matrix Multiplication Table
DECLARE @mRow INT = 1;
DECLARE @mCol INT = 1;
DECLARE @RowString VARCHAR(255);
DECLARE @HeaderString VARCHAR(255) = CHAR(9); -- Starting with a tab

WHILE @mCol <= 10
BEGIN
    SET @HeaderString = @HeaderString + CAST(@mCol AS VARCHAR) + CHAR(9);
    SET @mCol += 1;
END
PRINT @HeaderString;

WHILE @mRow <= 10
	BEGIN
		SET @mCol = 1;
		SET @RowString = CAST(@mRow AS VARCHAR) + CHAR(9);

		WHILE @mCol <= 10
			BEGIN
				SET @RowString = @RowString + CAST((@mRow * @mCol) AS VARCHAR) + CHAR(9);
				SET @mCol += 1;
			END

		PRINT @RowString;
		SET @mRow += 1;
	END

-- Example 6 - BREAK and CONTINUE Statements
DECLARE @I INT = 0;
WHILE @I < 10
	BEGIN
		SET @I += 1;

		IF @I % 2 = 0
			CONTINUE;
		
		PRINT 'Odd Number: ' + CAST(@I AS VARCHAR);
	END

PRINT '';
SET @I = 0;
WHILE @I < 10
	BEGIN
		SET @I += 1;

		IF @I = 4
			BREAK;
		
		PRINT 'Current Number: ' + CAST(@I AS VARCHAR);
	END
