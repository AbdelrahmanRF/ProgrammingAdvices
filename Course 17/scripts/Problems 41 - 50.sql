USE VehicleMakesDB;

SELECT * FROM VehicleDetails;

--  Problem 41: Get all Makes that manufactures one of the Max 3 Engine CC
SELECT m.Make
FROM VehicleDetails AS v 
JOIN Makes AS m ON v.MakeID = m.MakeID
WHERE v.Engine_CC IN (SELECT DISTINCT TOP 3 Engine_CC FROM VehicleDetails ORDER BY Engine_CC DESC)
GROUP BY m.Make
ORDER BY m.Make

-- Or
WITH Top3CarsEnginCC AS (
	SELECT DISTINCT TOP 3 Engine_CC FROM VehicleDetails
	ORDER BY Engine_CC DESC
)
SELECT DISTINCT m.Make
FROM VehicleDetails AS v 
JOIN Makes AS m ON v.MakeID = m.MakeID
JOIN Top3CarsEnginCC ON v.Engine_CC = Top3CarsEnginCC.Engine_CC
ORDER BY m.Make

-- Problem 42: Get a table of unique Engine_CC and calculate tax per Engine CC
SELECT DISTINCT Engine_CC,
		CASE
		WHEN Engine_CC between 0 and 1000 THEN 100
		 WHEN Engine_CC between 1001 and 2000 THEN 200
		 WHEN Engine_CC between 2001 and 4000 THEN 300
		 WHEN Engine_CC between 4001 and 6000 THEN 400
		 WHEN Engine_CC between 6001 and 8000 THEN 500
		 WHEN Engine_CC > 8000 THEN 600	
		ELSE 0
	END AS Tax
FROM VehicleDetails
ORDER BY Engine_CC;

-- Problem 43: Get Make and Total Number Of Doors Manufactured Per Make
SELECT m.Make, SUM(ISNULL(v.NumDoors, 0)) AS TotalNumberOfDoors
FROM VehicleDetails AS v 
JOIN Makes AS m ON v.MakeID = m.MakeID
GROUP BY m.Make
ORDER BY TotalNumberOfDoors DESC;

-- Problem 44: Get Total Number Of Doors Manufactured by 'Ford'
SELECT m.Make, SUM(v.NumDoors) AS TotalNumberOfDoors
FROM VehicleDetails AS v 
JOIN Makes AS m ON v.MakeID = m.MakeID
WHERE m.Make = 'Ford'
GROUP BY m.Make
ORDER BY TotalNumberOfDoors DESC;

-- Problem 45: Get Number of Models Per Make
SELECT Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
ORDER BY NumberOfModels DESC;

-- Problem 46: Get the highest 3 manufacturers that make the highest number of models
SELECT TOP 3 Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
ORDER BY NumberOfModels DESC;

-- Problem 47: Get the highest number of models manufactured
SELECT MAX(NumberOfModels) AS MaxNumberOfModels FROM (
SELECT Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
) R1;

-- Problem 48: Get the highest Manufacturers manufactured the highest number of models
SELECT Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes
JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
HAVING COUNT(*) = (
    SELECT MAX(NumberOfModels) 
    FROM (
        SELECT MakeID, COUNT(*) AS NumberOfModels
        FROM MakeModels
        GROUP BY MakeID
    ) R1
);

-- Or
SELECT TOP 1 WITH TIES Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes
JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
ORDER BY NumberOfModels DESC;

-- Problem 49: Get the Lowest Manufacturers manufactured the lowest number of models
SELECT Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes
JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
HAVING COUNT(*) = (
    SELECT MIN(NumberOfModels) 
    FROM (
        SELECT MakeID, COUNT(*) AS NumberOfModels
        FROM MakeModels
        GROUP BY MakeID
    ) R1
);

-- Or
SELECT TOP 1 WITH TIES Makes.Make, COUNT(*) AS NumberOfModels
FROM Makes
JOIN MakeModels ON Makes.MakeID = MakeModels.MakeID
GROUP BY Makes.Make
ORDER BY NumberOfModels;

-- Problem 50: Get all Fuel Types , each time the result should be showed in random order
SELECT * FROM FuelTypes
ORDER BY NEWID();