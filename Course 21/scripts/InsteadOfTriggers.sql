USE C21_DB1;

SELECT * FROM Students;
SELECT * FROM PersonalInfo;
SELECT * FROM AcademicInfo;
SELECT * FROM StudentView;

---------------------------------------------------------------------
ALTER TRIGGER trg_InsteadOfDeleteStudent ON Students
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON

	UPDATE Students
		SET IsActive = 0
	FROM Students S
	JOIN DELETED D ON S.StudentID = D.StudentID
END

---------------------------------------------------------------------
CREATE TRIGGER trg_UpdateStudentView ON StudentView
INSTEAD OF UPDATE
AS
BEGIN
	SET NOCOUNT ON

	UPDATE PersonalInfo
		SET Name = I.Name,
		Address = I.Address
	FROM PersonalInfo P
	JOIN INSERTED I ON P.StudentID = I.StudentID;

	UPDATE AcademicInfo
		SET Course = I.Course,
		Grade = I.Grade
	FROM AcademicInfo A
	JOIN INSERTED I ON A.StudentID = I.StudentID;

END

---------------------------------------------------------------------
CREATE TRIGGER trg_InsertStudentView ON StudentView
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO PersonalInfo (StudentID, Name, Address)
	SELECT StudentID, Name, Address FROM INSERTED;

	INSERT INTO AcademicInfo (StudentID, Course, Grade)
	SELECT StudentID, Course, Grade FROM INSERTED;

END

---------------------------------------------------------------------
DELETE FROM Students
WHERE StudentID = 10;

---------------------------------------------------------------------
UPDATE StudentView
SET Name = 'Johnathan Doe', Course = 'Biology', Grade = 92
WHERE StudentID = 1;

---------------------------------------------------------------------
INSERT INTO StudentView (StudentID, Name, Address, Course, Grade)
VALUES (3, 'Alice Johnson', '789 Pine Rd', 'Physics', 88);