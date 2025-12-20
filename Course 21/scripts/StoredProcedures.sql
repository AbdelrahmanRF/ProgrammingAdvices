CREATE PROCEDURE SP_AddNewPerson
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @NewPersonID INT OUTPUT
AS
BEGIN
    IF @FirstName IS NULL OR @LastName IS NULL
        RETURN -1;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);

    SET @NewPersonID = SCOPE_IDENTITY();
END

-------------------------------------------------------------------------------
CREATE PROCEDURE SP_GetAllPeople
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM People;
END

-------------------------------------------------------------------------------
ALTER PROCEDURE SP_IsPersonExists
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;
        IF @PersonID IS NULL OR @PersonID <= 0
            RETURN 0;

        IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID) 
            RETURN 0;

       RETURN 1;
END
-------------------------------------------------------------------------------
--CREATE PROCEDURE SP_GetPersonByID
--    @PersonID INT
--AS
--BEGIN 
--    SET NOCOUNT ON;
--    BEGIN TRY
--        IF @PersonID IS NULL OR @PersonID <= 0
--            THROW 50001, 'Invalid PersonID provided.', 1

--        IF NOT EXISTS 
--        (
--            SELECT 1 FROM People WHERE PersonID = @PersonID
--        )
--            THROW 50002, 'Person not found.', 1

--        SELECT * FROM People WHERE PersonID = @PersonID;
--    END TRY
--    BEGIN CATCH
--        THROW;
--    END CATCH
--END

ALTER PROCEDURE SP_GetPersonByID
    @PersonID INT
AS
BEGIN 
    SET NOCOUNT ON;

    IF @PersonID IS NULL OR @PersonID <= 0
        RETURN -1;

    SELECT * FROM People 
    WHERE PersonID = @PersonID;

    IF @@ROWCOUNT = 0
        RETURN 0;

    RETURN 1;
END

-------------------------------------------------------------------------------
CREATE PROCEDURE SP_GetPersonInfoByID
    @PersonID INT,
    @FirstName NVARCHAR(100) OUTPUT,
	@LastName NVARCHAR(100) OUTPUT,
    @Email NVARCHAR(255) OUTPUT
AS
BEGIN 
    SET NOCOUNT ON;

    IF @PersonID IS NULL OR @PersonID <= 0
        RETURN -1;

    SELECT 
        @FirstName = FirstName,
        @LastName = LastName,
        @Email = Email
    FROM People WHERE PersonID = @PersonID;

    IF @@ROWCOUNT = 0
    RETURN 0;

    RETURN 1;
END

-------------------------------------------------------------------------------
ALTER PROCEDURE SP_UpdatePerson
    @PersonID INT,
    @FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
    @Email NVARCHAR(255)
AS
BEGIN 
    SET NOCOUNT ON;
    
    DECLARE @Exists BIT;

    -- Validate existence
    EXEC @Exists = SP_IsPersonExists @PersonID;

    IF @Exists = 0
        RETURN 0;

    BEGIN TRY
        BEGIN TRANSACTION
            UPDATE People
                SET FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email
            WHERE PersonID = @PersonID;

            COMMIT;
            RETURN 1;
    END TRY
    BEGIN CATCH 
        IF @@TRANCOUNT > 0
            ROLLBACK;

            THROW;
    END CATCH
END

-------------------------------------------------------------------------------
ALTER PROCEDURE SP_DeletePerson
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Exists BIT;

    EXEC @Exists = SP_IsPersonExists @PersonID;

    IF @Exists = 0
        RETURN 0;

    BEGIN TRY
        BEGIN TRANSACTION
            DELETE FROM People
            WHERE PersonID = @PersonID;
            
            COMMIT;
            RETURN 1;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        ROLLBACK;

        THROW;
    END CATCH
END
-------------------------------------------------------------------------------

DECLARE @PersonID INT;

EXEC SP_AddNewPerson
	@FirstName = 'Ahmad',
	@LastName = 'Abu Taha',
    @Email = null,
    @NewPersonID = @PersonID OUTPUT;

SELECT @PersonID AS AddedPersonID;

-------------------------------------------------------------------------------
EXEC SP_GetAllPeople;

-------------------------------------------------------------------------------
EXEC SP_GetPersonByID
    @PersonID = 0;

-------------------------------------------------------------------------------
DECLARE @Person1ID INT = 1;
DECLARE @Person1FirstName NVARCHAR(100);
DECLARE @Person1LastName NVARCHAR(100);
DECLARE @Person1Email NVARCHAR(255);

EXEC SP_GetPersonInfoByID
    @PersonID = @Person1ID,
    @FirstName = @Person1FirstName OUTPUT,    
    @LastName = @Person1LastName OUTPUT,
    @Email = @Person1Email OUTPUT;

SELECT @Person1ID AS PersonID, @Person1FirstName AS FirstName, @Person1LastName AS LastName, @Person1Email AS Email

-------------------------------------------------------------------------------
DECLARE @Result INT;

EXEC @Result = SP_UpdatePerson
    @PersonID = 1,
    @FirstName = 'Omar',
    @LastName = 'Salem',
    @Email = 'omar@email.com';

EXEC SP_GetAllPeople;

-------------------------------------------------------------------------------
EXEC SP_DeletePerson
    @PersonID = 1;

-------------------------------------------------------------------------------
DROP PROCEDURE SP_GetPersonInfoByID;

-------------------------------------------------------------------------------
EXEC SP_HELPTEXT 'SP_DeletePerson';