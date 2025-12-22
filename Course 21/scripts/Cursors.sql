USE C21_DB1;

--------------------------------------------------------------
DECLARE Static_Cursor CURSOR STATIC FOR 
SELECT StudentID, Name, Grade FROM dbo.Students;

OPEN Static_Cursor;

DECLARE @StudentID INT, @Name VARCHAR(50), @Grade INT;

FETCH NEXT FROM Static_Cursor INTO @StudentID , @Name, @Grade;

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT 'Student Name: ' + @Name + ', Grade: ' + CAST(@Grade AS NVARCHAR(10));

	FETCH NEXT FROM Static_Cursor INTO @StudentID , @Name, @Grade;
END

CLOSE Static_Cursor;
DEALLOCATE Static_Cursor;

--------------------------------------------------------------
DECLARE Dynamic_Cursor CURSOR DYNAMIC FOR
SELECT StudentID, Name, Grade FROM dbo.Students;

OPEN Dynamic_Cursor;

DECLARE @StudentID2 INT, @Name2 VARCHAR(50), @Grade2 INT;

FETCH NEXT FROM Dynamic_Cursor INTO @StudentID2 , @Name2, @Grade2;

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT 'Student Name: ' + @Name2 + ', Grade: ' + CAST(@Grade2 AS NVARCHAR(10));

	FETCH NEXT FROM Dynamic_Cursor INTO @StudentID2 , @Name2, @Grade2;
END

CLOSE Dynamic_Cursor;
DEALLOCATE Dynamic_Cursor;

--------------------------------------------------------------
DECLARE Forward_Cursor CURSOR FAST_FORWARD FOR
SELECT Email FROM People;

OPEN Forward_Cursor;
DECLARE @Email NVARCHAR(255);

FETCH NEXT FROM Forward_Cursor INTO @Email;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Sending email to ' + @Email;
    FETCH NEXT FROM Forward_Cursor INTO @Email;
END

CLOSE Forward_Cursor;
DEALLOCATE Forward_Cursor;

--------------------------------------------------------------
DECLARE Scroll_Cursor CURSOR STATIC SCROLL FOR 
SELECT StudentID, Name, Grade FROM dbo.Students
ORDER BY Grade DESC;

OPEN Scroll_Cursor;

DECLARE @StudentID4 INT, @Name4 VARCHAR(50), @Grade4 INT;

FETCH FIRST FROM Scroll_Cursor INTO @StudentID4 , @Name4, @Grade4;
PRINT 'Top Student: ' + @Name4 + ', Grade: ' + CAST(@Grade4 AS NVARCHAR(10));

FETCH LAST FROM Scroll_Cursor INTO @StudentID4 , @Name4, @Grade4;
PRINT 'Final Student: ' + @Name4 + ', Grade: ' + CAST(@Grade4 AS NVARCHAR(10));

CLOSE Scroll_Cursor;
DEALLOCATE Scroll_Cursor;