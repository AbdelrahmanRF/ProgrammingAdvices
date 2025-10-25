USE VehicleMakesDB;

SELECT * FROM VehicleDetails;

-- Problem 11: Get Total Makes that runs with GAS
SELECT Count(*) AS TotalMakesRunsGas FROM (
SELECT DISTINCT Makes.Make, FuelTypes.FuelTypeName
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
WHERE FuelTypes.FuelTypeName = 'GAS'
) R1;

-- OR
SELECT COUNT(DISTINCT Makes.Make) AS TotalMakesRunsGas
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
WHERE FuelTypes.FuelTypeName = 'GAS';

-- Problem 12: Count Vehicles by make and order them by NumberOfVehicles from high to low.
SELECT Makes.Make, Count(*) AS NumberOfVehicles
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
GROUP BY Makes.Make
ORDER BY NumberOfVehicles DESC;

-- Problem 13: Get all Makes/Count Of Vehicles that manufactures more than 20K Vehicles
SELECT Makes.Make, Count(*) AS NumberOfVehicles
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
GROUP BY Makes.Make
HAVING Count(*) > 20000
ORDER BY NumberOfVehicles DESC;

-- Problem 14: Get all Makes with make starts with 'B'
SELECT Make FROM Makes
WHERE Make LIKE 'B%';

-- Problem 15: Get all Makes with make ends with 'W'
SELECT Make FROM Makes
WHERE Make LIKE '%w';

-- Problem 16: Get all Makes that manufactures DriveTypeName = FWD
SELECT DISTINCT Makes.Make, DriveTypes.DriveTypeName
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN DriveTypes ON VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
WHERE DriveTypes.DriveTypeName = 'FWD';

-- Problem 17: Get total Makes that Mantufactures DriveTypeName=FWD
SELECT Count(DISTINCT Makes.Make) AS MakeWithFWD
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN DriveTypes ON VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
WHERE DriveTypes.DriveTypeName = 'FWD';

-- Problem 18: Get total vehicles per DriveTypeName Per Make and order them per make asc then per total Desc
SELECT Makes.Make, DriveTypes.DriveTypeName , Count(*) AS NumberOfVehicles
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN DriveTypes ON VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
GROUP BY Makes.Make, DriveTypes.DriveTypeName
ORDER BY Makes.Make ASC, NumberOfVehicles DESC;

-- Problem 19: Get total vehicles per DriveTypeName Per Make then filter only results with total > 10,000
SELECT Makes.Make, DriveTypes.DriveTypeName , Count(*) AS NumberOfVehicles
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN DriveTypes ON VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
GROUP BY Makes.Make, DriveTypes.DriveTypeName
HAVING Count(*) > 10000
ORDER BY NumberOfVehicles DESC;

--  Problem 20: Get all Vehicles that number of doors is not specified
SELECT * FROM VehicleDetails
WHERE NumDoors IS NULL