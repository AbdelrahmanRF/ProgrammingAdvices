USE C21_DB1;

CREATE FUNCTION dbo.GetStudentsBySubject(@Subject NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Students 
	WHERE Subject = @Subject
)

--------------------------------------------------------------------
CREATE FUNCTION dbo.GetStudentsByGradeRange
(
    @MinGrade INT,
    @MaxGrade INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT StudentID, Name, Subject, Grade
    FROM Students
    WHERE Grade BETWEEN @MinGrade AND @MaxGrade
);

--------------------------------------------------------------------
ALTER FUNCTION dbo.GetTopPerformingStudentsBySubject(@Subject NVARCHAR(50) = null)
RETURNS @Result TABLE (
	StudentID INT,
	Name NVARCHAR(50),
	Subject NVARCHAR(50),
	Grade INT
)
AS
BEGIN
	INSERT INTO @Result
	SELECT TOP 3 * FROM Students 
	WHERE Subject = @Subject OR @Subject IS NULL --Certain Subject or All
	ORDER BY Grade DESC;

	RETURN;
END

--------------------------------------------------------------------
ALTER FUNCTION dbo.GetTopStudentPerSubject()
RETURNS @Result TABLE (
    Subject NVARCHAR(50),
    StudentName NVARCHAR(50),
    Grade INT
)
AS
BEGIN
    INSERT INTO @Result
    SELECT Subject, Name, Grade
    FROM
    (
        SELECT *,
        ROW_NUMBER() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS RN
        FROM Students 
    ) S
    WHERE RN = 1

    RETURN;
END;

--------------------------------------------------------------------
CREATE FUNCTION dbo.GetTopStudentPerSubjectInline()
RETURNS TABLE
AS
RETURN
(
    SELECT Subject, Name, Grade
    FROM
    (
        SELECT *,
        ROW_NUMBER() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS RN
        FROM Students 
    ) S
    WHERE RN = 1
);
--------------------------------------------------------------------
SELECT * FROM dbo.GetStudentsBySubject('Math')
WHERE Grade >= 80

--------------------------------------------------------------------
SELECT MS.StudentID, MS.Name AS StudentName, Ms.Grade, T.Name AS TeacherName
FROM dbo.GetStudentsBySubject('Math') AS MS
JOIN Teachers AS T
ON MS.Subject = T.Subject

--------------------------------------------------------------------
SELECT AVG(Grade) AS Average
FROM dbo.GetStudentsBySubject('Math')

--------------------------------------------------------------------
SELECT *
FROM dbo.GetStudentsByGradeRange(90, 100);

--------------------------------------------------------------------
SELECT * FROM dbo.GetTopPerformingStudentsBySubject('Math');

--------------------------------------------------------------------
SELECT * FROM dbo.GetTopPerformingStudentsBySubject(DEFAULT);

--------------------------------------------------------------------
-- SELECT * FROM dbo.GetTopStudentPerSubjectInline()
SELECT * FROM dbo.GetTopStudentPerSubject()
ORDER BY Grade DESC;