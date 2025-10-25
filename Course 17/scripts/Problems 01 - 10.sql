USE VehicleMakesDB;

SELECT * FROM VehicleDetails;
SELECT * FROM VehicleMasterDetails;

-- Problem 01: Create Master View
CREATE VIEW VehicleMasterDetails AS
SELECT VehicleDetails.ID, VehicleDetails.MakeID, Makes.Make, 
VehicleDetails.SubModelID, SubModels.SubModelName, VehicleDetails.BodyID,
Bodies.BodyName, VehicleDetails.Vehicle_Display_Name, VehicleDetails.Year,
VehicleDetails.DriveTypeID, DriveTypes.DriveTypeName, VehicleDetails.Engine,
VehicleDetails.Engine_CC, VehicleDetails.Engine_Cylinders, VehicleDetails.Engine_Liter_Display,
VehicleDetails.FuelTypeID, FuelTypes.FuelTypeName, VehicleDetails.NumDoors
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN SubModels ON VehicleDetails.SubModelID = SubModels.SubModelID
JOIN Bodies ON VehicleDetails.BodyID = Bodies.BodyID
JOIN DriveTypes ON VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
JOIN FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID;

-- Problem 02: Get all vehicles made between 1950 and 2000
SELECT * FROM VehicleDetails
WHERE Year BETWEEN 1950 AND 2000;

-- Problem 03 : Get number vehicles made between 1950 and 2000
SELECT NumberOfVehicles = Count(*) FROM VehicleDetails
WHERE Year BETWEEN 1950 AND 2000;

-- Problem 04 : Get number vehicles made between 1950 and 2000 per make and order them by Number Of Vehicles Descending
SELECT Makes.Make, NumberOfVehicles =  Count(*) FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID

WHERE Year BETWEEN 1950 AND 2000
GROUP BY Makes.Make
ORDER BY NumberOfVehicles DESC;

-- Problem 05 : Get All Makes that have manufactured more than 12000 Vehicles in years 1950 to 2000

SELECT Makes.Make, NumberOfVehicles =  Count(*) FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID

WHERE Year BETWEEN 1950 AND 2000
GROUP BY Makes.Make
HAVING Count(*) > 12000
ORDER BY NumberOfVehicles DESC

-- Problem 06: Get number of vehicles made between 1950 and 2000 per make and add total vehicles column beside


SELECT Makes.Make, NumberOfVehicles =  Count(*), TotalVehicles = (SELECT Count(*) FROM VehicleDetails)
FROM VehicleDetails JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID

WHERE Year BETWEEN 1950 AND 2000
GROUP BY Makes.Make
ORDER BY NumberOfVehicles DESC


-- Problem 07: Get number of vehicles made between 1950 and 2000 per make and add total vehicles column beside it, then calculate it's percentage
SELECT * , Perc = CAST(NumberOfVehicles AS FLOAT) / TotalVehicles FROM (
SELECT Makes.Make, NumberOfVehicles =  Count(*), TotalVehicles = (SELECT Count(*) FROM VehicleDetails)
FROM VehicleDetails JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID

WHERE Year BETWEEN 1950 AND 2000
GROUP BY Makes.Make
) R1
ORDER BY R1.NumberOfVehicles DESC

-- Optimized version (with CROSS JOIN)
SELECT 
    m.Make,
    COUNT(*) AS NumberOfVehicles,
    t.TotalVehicles,
    CAST(COUNT(*) AS FLOAT) / t.TotalVehicles AS Perc
FROM VehicleDetails AS v
CROSS JOIN (SELECT COUNT(*) AS TotalVehicles FROM VehicleDetails) AS t
JOIN Makes AS m ON v.MakeID = m.MakeID
WHERE v.Year BETWEEN 1950 AND 2000
GROUP BY m.Make, t.TotalVehicles
ORDER BY NumberOfVehicles DESC;

-- Problem 8: Get Make, FuelTypeName and Number of Vehicles per FuelType per Make
SELECT Makes.Make, FuelTypes.FuelTypeName,COUNT(*) AS NumberOfVehicles  
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
WHERE VehicleDetails.Year BETWEEN 1950 AND 2000
GROUP BY Makes.Make, FuelTypes.FuelTypeName
ORDER BY Makes.Make;

-- Problem 9: Get all vehicles that runs with GAS
SELECT VehicleDetails.*, FuelTypes.FuelTypeName
FROM VehicleDetails
JOIN FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
WHERE FuelTypes.FuelTypeName = 'GAS';

-- Problem 10: Get all Makes that runs with GAS
SELECT DISTINCT Makes.Make, FuelTypes.FuelTypeName
FROM VehicleDetails
JOIN Makes ON VehicleDetails.MakeID = Makes.MakeID
JOIN FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
WHERE FuelTypes.FuelTypeName = 'GAS'
