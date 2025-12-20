USE C21_DB1;

SELECT * FROM Students ORDER BY Grade DESC;

SELECT 
	*,
	ROW_NUMBER() OVER (ORDER BY Grade DESC) AS RowNumber
FROM Students ORDER BY Grade DESC;

-----------------------------------------------------------
SELECT 
	*,
	RANK() OVER (ORDER BY Grade DESC) AS GradeRank
FROM Students ORDER BY Grade DESC;

-----------------------------------------------------------
SELECT 
	*,
	DENSE_RANK() OVER (ORDER BY Grade DESC) AS GradeRank
FROM Students ORDER BY Grade DESC;

-----------------------------------------------------------
SELECT 
	*,
	DENSE_RANK() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS GradeRank
FROM Students;

-----------------------------------------------------------
SELECT 
	*,
	AVG(Grade) OVER (PARTITION BY Subject) AS GradeAverage,
	SUM(Grade) OVER (PARTITION BY Subject) AS GradeTotal
FROM Students;

-----------------------------------------------------------
SELECT
    StudentID,
    Name,
    Subject,
    Grade,
    SUM(Grade) OVER (
        PARTITION BY Subject
        ORDER BY Grade DESC
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    ) AS RunningTotal
FROM Students;

-----------------------------------------------------------
SELECT 
	StudentID,
	Name,
	LAG(Grade, 1) OVER (ORDER BY Grade DESC) AS PrevGrade,
	Grade,
	LEAD(Grade, 1) OVER (ORDER BY Grade DESC) AS NextGrade
FROM Students;

-----------------------------------------------------------
DECLARE @PageNumber INT = 1;
DECLARE @RowsPerPage INT = 3;

SELECT * FROM Students
ORDER BY StudentID
OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY;

-----------------------------------------------------------
-- keyset pagination
ALTER PROCEDURE SP_GetStudentsPage
    @LastStudentID INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (@PageSize)
        StudentID,
        Name
    FROM Students
    WHERE StudentID > @LastStudentID
    ORDER BY StudentID ASC;
END

-----------------------------------------------------------
EXEC SP_GetStudentsPage
    @LastStudentID = 0,
    @PageSize = 3