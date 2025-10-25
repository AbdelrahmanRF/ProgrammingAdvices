USE VehicleMakesDB;

SELECT * FROM VehicleDetails;

--  Problem 21: Get Total Vehicles that number of doors is not specified
SELECT Count(*) TotalWithNoSpecifiedDoors FROM VehicleDetails
WHERE NumDoors IS NULL;

-- Problem 22: Get percentage of vehicles that has no doors specified
SELECT (
	CAST((SELECT Count(*) AS TotalWithNoSpecifiedDoors FROM VehicleDetails
	WHERE NumDoors IS NULL) AS FLOAT)  
	
	/ (SELECT Count(*) AS TotalVehicles FROM VehicleDetails) 

) AS PercOfNoSpecifiedDoors

-- Another solution:
SELECT
CAST(t.TotalWithNoSpecifiedDoors AS FLOAT) / (t.TotalVehicles) AS PercOfNoSpecifiedDoors
FROM
(
	SELECT Count(*) AS TotalVehicles,
	SUM(CASE WHEN NumDoors IS NULL THEN 1 ELSE 0 END) AS TotalWithNoSpecifiedDoors
	FROM VehicleDetails
) t;

-- Problem 23: Get MakeID , Make, SubModelName for all vehicles that have SubModelName 'Elite'
SELECT Makes.MakeID, Makes.Make, SubModels.SubModelName
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN SubModels ON VehicleDetails.SubModelID = SubModels.SubModelID
WHERE SubModels.SubModelName = 'Elite';

-- Problem 24: Get all vehicles that have Engines > 3 Liters and have only 2 doors
SELECT * FROM VehicleDetails
WHERE Engine_Liter_Display > 3 AND NumDoors = 2;

-- Problem 25: Get make and vehicles that the engine contains 'OHV' and have Cylinders = 4
SELECT Makes.Make, VehicleDetails.*
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
WHERE VehicleDetails.Engine LIKE '%OHV%' AND Engine_Cylinders = 4;

-- Problem 26: Get all vehicles that their body is 'Sport Utility' and Year > 2020
SELECT Bodies.BodyName, VehicleDetails.*
FROM VehicleDetails
JOIN Bodies ON VehicleDetails.BodyID = Bodies.BodyID
WHERE Bodies.BodyName = 'Sport Utility' AND VehicleDetails.Year > 2020;

-- Problem 27: Get all vehicles that their Body is 'Coupe' or 'Hatchback' or 'Sedan' 
SELECT Bodies.BodyName, VehicleDetails.*
FROM VehicleDetails
JOIN Bodies ON VehicleDetails.BodyID = Bodies.BodyID
WHERE Bodies.BodyName IN ('Coupe', 'Hatchback', 'Sedan');

-- Problem 28: Get all vehicles that their body is 'Coupe' or 'Hatchback' or 'Sedan' and manufactured in year 2008 or 2020 or 2021
SELECT Bodies.BodyName, VehicleDetails.*
FROM VehicleDetails
JOIN Bodies ON VehicleDetails.BodyID = Bodies.BodyID
WHERE Bodies.BodyName IN ('Coupe', 'Hatchback', 'Sedan') AND VehicleDetails.Year IN (2008, 2020, 2021);

-- Problem 29: Return found=1 if there is any vehicle made in year 1950
SELECT found = 1 
WHERE EXISTS
(
	SELECT TOP 1 R = 'R'
	FROM VehicleDetails
	WHERE Year = 1950
);

-- OR
SELECT found =
CASE
	WHEN EXISTS (SELECT 1 FROM VehicleDetails WHERE Year = 1950) THEN 1
	ELSE 0
END;

-- Problem 30: Get all Vehicle_Display_Name, NumDoors and add extra column to describe number of doors by words, and if door is null display 'Not Set'
SELECT Vehicle_Display_Name, NumDoors, 
NumDoorsByWords = 
	CASE
		WHEN NumDoors = 0 THEN 'Zero doors'
		WHEN NumDoors = 2 THEN 'Two doors'
		WHEN NumDoors = 3 THEN 'Three doors'
		WHEN NumDoors = 4 THEN 'Four doors'
		WHEN NumDoors = 5 THEN 'Five doors'
		WHEN NumDoors = 6 THEN 'Six doors'
		WHEN NumDoors = 8 THEN 'Eight doors'
		WHEN NumDoors IS NULL THEN 'Not Set'
		ELSE 'Unknown'
	END
FROM VehicleDetails;
