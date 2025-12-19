SELECT * FROM Accounts;
SELECT * FROM Transactions;
SELECT * FROM ErrorLog;
 

--ALTER TABLE Accounts
--ADD CONSTRAINT CK_Accounts_Balance_NonNegative
--CHECK (Balance >= 0);

BEGIN TRANSACTION;

BEGIN TRY
    UPDATE Accounts SET Balance = Balance - 100 WHERE AccountID = 1;
    UPDATE Accounts SET Balance = Balance + 100 WHERE AccountID = 2;

    INSERT INTO Transactions (FromAccount, ToAccount, Amount, Date) VALUES (1, 2, 100, GETDATE());
    COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;
	INSERT INTO ErrorLog
    (
        ErrorNumber,
        ErrorSeverity,
        ErrorState,
        ErrorProcedure,
        ErrorLine,
        ErrorMessage
    )
    VALUES
    (
        ERROR_NUMBER(),
        ERROR_SEVERITY(),
        ERROR_STATE(),
        ERROR_PROCEDURE(),
        ERROR_LINE(),
        ERROR_MESSAGE()
    );

    THROW;
END CATCH;