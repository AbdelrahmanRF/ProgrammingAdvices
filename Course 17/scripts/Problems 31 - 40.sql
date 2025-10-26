USE VehicleMakesDB;

SELECT * FROM VehicleDetails;

--  Problem 31: Get all Vehicle_Display_Name, year and add extra column to calculate the age of the car then sort the results by age desc
SELECT Vehicle_Display_Name, Year, YEAR(GetDate()) - Year AS CarAge
FROM VehicleDetails
ORDER BY CarAge DESC;

-- Problem 32: Get all Vehicle_Display_Name, year, Age for vehicles that their age between 15 and 25 years old
SELECT 
  Vehicle_Display_Name, 
  Year, 
  YEAR(GetDate()) - Year AS CarAge
FROM VehicleDetails
WHERE (YEAR(GetDate()) - Year) BETWEEN 15 AND 25
ORDER BY CarAge DESC;

-- Problem 33: Get Minimum Engine CC , Maximum Engine CC , and Average Engine CC of all Vehicles
SELECT
	MIN(Engine_CC) AS MinimumEngineCC,
	MAX(Engine_CC) AS MaximumEngineCC,
	AVG(Engine_CC) AS AverageEngineCC
FROM VehicleDetails;

-- Problem 34: Get all vehicles that have the minimum Engine_CC
SELECT v.* 
FROM VehicleDetails AS v
CROSS JOIN (
	SELECT MIN(Engine_CC) AS MinimumEngineCC FROM VehicleDetails
) t
WHERE v.Engine_CC = t.MinimumEngineCC;

-- Problem 35: Get all vehicles that have the Maximum Engine_CC
SELECT v.* 
FROM VehicleDetails AS v
CROSS JOIN (
	SELECT MAX(Engine_CC) AS MaximumEngineCC FROM VehicleDetails
) t
WHERE v.Engine_CC = t.MaximumEngineCC;

-- Problem 36: Get all vehicles that have Engin_CC below average
SELECT v.* 
FROM VehicleDetails AS v
CROSS JOIN (
	SELECT AVG(Engine_CC) AS AverageEngineCC FROM VehicleDetails
) t
WHERE v.Engine_CC < t.AverageEngineCC;

-- Problem 37: Get total vehicles that have Engin_CC above average
WITH AvgEngine AS (
	SELECT AVG(Engine_CC) AS AverageEngineCC FROM VehicleDetails
)
SELECT 
	COUNT(v.ID) AS NumberOfVehiclesAboveAverageEngineCC
	FROM VehicleDetails AS v
	CROSS JOIN AvgEngine a
	WHERE v.Engine_CC > a.AverageEngineCC;
-- OR
SELECT 
	COUNT(v.ID) AS NumberOfVehiclesAboveAverageEngineCC
FROM VehicleDetails AS v
CROSS JOIN (SELECT AVG(Engine_CC) AS AverageEngineCC FROM VehicleDetails) AS t
WHERE v.Engine_CC > t.AverageEngineCC;

-- Problem 38: Get all unique Engin_CC and sort them Desc
-- All unique values
SELECT DISTINCT Engine_CC AS UniqueEngin_CC
FROM VehicleDetails
ORDER BY Engine_CC DESC;

-- Values that appear exactly once
SELECT Engine_CC AS UniqueEngin_CC
FROM VehicleDetails
GROUP BY Engine_CC
HAVING COUNT(*) = 1
ORDER BY Engine_CC DESC;

-- Problem 39: Get the maximum 3 Engine CC
SELECT DISTINCT TOP 3 Engine_CC FROM VehicleDetails
ORDER BY Engine_CC DESC;

-- Problem 40: Get all vehicles that has one of the Max 3 Engine CC
SELECT Vehicle_Display_Name, Engine_CC from VehicleDetails 
WHERE Engine_CC IN (
SELECT DISTINCT TOP 3 Engine_CC FROM VehicleDetails
ORDER BY Engine_CC DESC
);
	
