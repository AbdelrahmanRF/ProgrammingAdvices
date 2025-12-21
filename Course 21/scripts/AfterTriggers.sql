USE C21_DB1;

SELECT * FROM Students;
SELECT * FROM StudentInsertLog;
SELECT * FROM StudentUpdateLog;
SELECT * FROM StudentDeleteLog;

---------------------------------------------------------------------
ALTER TRIGGER trg_LogNewStudent ON Students
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO StudentInsertLog (StudentID, Name, Subject, Grade)
	SELECT StudentID, Name, Subject, Grade FROM INSERTED;
END

---------------------------------------------------------------------
ALTER TRIGGER trg_LogUpdateStudent ON Students
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	IF UPDATE(Grade)
		INSERT INTO StudentUpdateLog (StudentID, OldGrade, NewGrade)
		SELECT I.StudentID, D.Grade AS OldGrade , I.Grade AS NewGrade
		FROM INSERTED I 
		JOIN DELETED D ON I.StudentID = D.StudentID;
END

---------------------------------------------------------------------
CREATE TRIGGER trg_LogDeleteStudent ON Students
AFTER DELETE
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO StudentDeleteLog (StudentID, Name, Subject, Grade) 
	SELECT StudentID, Name, Subject, Grade FROM DELETED
END

---------------------------------------------------------------------
INSERT INTO Students (StudentID, Name, Subject, Grade)
VALUES (11, 'Rami', 'Math', 91);

---------------------------------------------------------------------
Update Students
SET Grade = 95
WHERE StudentID = 11;

---------------------------------------------------------------------
DELETE Students
WHERE StudentID = 11;