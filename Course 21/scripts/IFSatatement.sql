Use C21_DB1;

Declare @Year INT = 2001;

IF @Year >= 2000
	BEGIN
		PRINT '21st century'
	END
ELSE
	BEGIN
		PRINT '20th century or earlier'
	END

-- Nested IF

DECLARE @IsActive BIT = 1;
DECLARE @YearsOfExperience INT = 6;
DECLARE @PerformanceRating INT = 4; -- 1 to 5
DECLARE @BonusPercentage DECIMAL(4,2);

IF @IsActive = 1
	BEGIN
		IF @YearsOfExperience >= 5
			BEGIN
				IF @PerformanceRating >= 4
					BEGIN
						SET @BonusPercentage = 0.20;
						PRINT 'Excellent employee: 20% bonus';
					END

				ELSE
					BEGIN
						SET @BonusPercentage = 0.10;
						PRINT 'Experienced employee: 10% bonus';
					END
			END
		ELSE
			BEGIN
				IF @PerformanceRating >= 4
					BEGIN
						SET @BonusPercentage = 0.05;
						PRINT 'High performer, low experience: 5% bonus';
					END

				ELSE
					BEGIN
						SET @BonusPercentage = 0.00;
						PRINT 'No bonus eligibility';
					END
			END
	END
ELSE
	BEGIN
		SET @BonusPercentage = 0.00;
		PRINT 'Inactive employee: no bonus';
	END


-- Using IF Statement with AND/OR/NOT
DECLARE @Age INT = 25;
DECLARE @Salary DECIMAL(10,2) = 5000; 

IF @Age > 18 AND @Salary >= 5000
	BEGIN
		PRINT 'Eligible for the loan';
	END
ELSE
	BEGIN
		PRINT 'Illegible for the loan';
	END
--------------------------
DECLARE @Grade CHAR(1) = 'B';
DECLARE @AttendancePercentage INT = 75; 

IF @Grade = 'A' OR @AttendancePercentage > 70
	BEGIN
		PRINT 'Qualified for extra-curricular activities';
	END
ELSE
	BEGIN
		PRINT 'Not qualified for extra-curricular activities';
	END
--------------------------
DECLARE @CustomerStatus NVARCHAR(10) = 'Inactive';

IF NOT (@CustomerStatus = 'Active')
	BEGIN
		PRINT 'Send re-engagement email';
	END
ELSE
	BEGIN
		PRINT 'Customer is active';
	END


-- Error Handling (Legacy)
DECLARE @ErrorNumber INT;

INSERT INTO Employees (Name) VALUES ('Test Test');

SET @ErrorNumber = @@ERROR;

IF @ErrorNumber <> 0
BEGIN
    PRINT 'An error occurred with error number: ' + CAST(@ErrorNumber AS VARCHAR);
END

-- IF with EXISTS
IF EXISTS (SELECT * FROM Employees WHERE Name = 'Abdelrahman Alfar')
	BEGIN
		PRINT 'Yes, Abdelrahman Alfar is there.'
	END
ELSE
	BEGIN
		PRINT 'No, Abdelrahman Alfar is there.'
	END

