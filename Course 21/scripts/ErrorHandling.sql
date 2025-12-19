USE C21_DB1;

SELECT * FROM Employees3;
SELECT * FROM ErrorLog;

BEGIN TRY
	--INSERT INTO Employees3 
	--VALUES (1, 'Omar Salem', 'Sales Manager');

	---- Duplicate record which will cause an error
	--INSERT INTO Employees3 
	-- VALUES (1, 'Ahmad Ali', 'Marketing Manager');

     -- Intentional division by zero error
     SELECT 1 / 0;
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
END CATCH


DECLARE @NewStockQty INT;

SET @NewStockQty = -5;

BEGIN TRY
    IF @NewStockQty < 0
        THROW 51000, 'Stock quantity cannot be negative.', 1

    UPDATE Products SET StockQuantity = @NewStockQty WHERE ProductID = 1;
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
END CATCH