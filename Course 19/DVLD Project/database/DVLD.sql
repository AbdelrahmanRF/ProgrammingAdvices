-- DVLD Database Script

-- 1. Create database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DVLD')
BEGIN
    CREATE DATABASE DVLD;
END

-- 2. Use the database
USE DVLD;

-- 3. Create Countries table
CREATE TABLE Countries (
    CountryID INT IDENTITY(1,1) PRIMARY KEY,
    CountryName NVARCHAR(50) NOT NULL
);

-- 4. Create People table
CREATE TABLE People (
    PersonID INT IDENTITY(1,1) PRIMARY KEY,
    NationalNo NVARCHAR(20) NOT NULL,
    FirstName NVARCHAR(20) NOT NULL,
    SecondName NVARCHAR(20) NOT NULL,
    ThirdName NVARCHAR(20),
    LastName NVARCHAR(20) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    Gendor TINYINT NOT NULL DEFAULT 0,
    Address NVARCHAR(500) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(50),
    NationalityCountryID INT NOT NULL,
    ImagePath NVARCHAR(250),
    FOREIGN KEY (NationalityCountryID) REFERENCES Countries(CountryID)
);

-- 5. Users table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    PersonID INT NOT NULL,
    UserName NVARCHAR(20) NOT NULL,
    Password NVARCHAR(20) NOT NULL,
    IsActive BIT NOT NULL,
    FOREIGN KEY (PersonID) REFERENCES People(PersonID)
);

-- 6. ApplicationTypes table
CREATE TABLE ApplicationTypes (
    ApplicationTypeID INT IDENTITY(1,1) PRIMARY KEY,
    ApplicationTypeTitle NVARCHAR(150) NOT NULL,
    ApplicationFees SMALLMONEY NOT NULL DEFAULT 0
);

-- 7. TestTypes table
CREATE TABLE TestTypes (
    TestTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TestTypeTitle NVARCHAR(100) NOT NULL,
    TestTypeDescription NVARCHAR(500) NOT NULL,
    TestTypeFees SMALLMONEY NOT NULL
);

-- 8. LicenseClasses table
CREATE TABLE LicenseClasses (
    LicenseClassID INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(50) NOT NULL,
    ClassDescription NVARCHAR(500) NOT NULL,
    MinimumAllowedAge TINYINT NOT NULL DEFAULT 18,
    DefaultValidityLength TINYINT NOT NULL DEFAULT 1,
    ClassFees SMALLMONEY NOT NULL DEFAULT 0
);


-- 9. Applications table
CREATE TABLE Applications (
    ApplicationID INT IDENTITY(1,1) PRIMARY KEY,
    ApplicantPersonID INT NOT NULL,
    ApplicationDate DATETIME NOT NULL,
    ApplicationTypeID INT NOT NULL,
    ApplicationStatus TINYINT NOT NULL DEFAULT 1,
    LastStatusDate DATETIME NOT NULL,
    PaidFees SMALLMONEY NOT NULL,
    CreatedByUserID INT NOT NULL,
    FOREIGN KEY (ApplicantPersonID) REFERENCES People(PersonID),
    FOREIGN KEY (ApplicationTypeID) REFERENCES ApplicationTypes(ApplicationTypeID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);

-- 10. LocalDrivingLicenseApplications table
CREATE TABLE LocalDrivingLicenseApplications (
    LocalDrivingLicenseApplicationID INT IDENTITY(1,1) PRIMARY KEY,
    ApplicationID INT NOT NULL,
    LicenseClassID INT NOT NULL,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (LicenseClassID) REFERENCES LicenseClasses(LicenseClassID)
);

-- 11. TestAppointments table
CREATE TABLE TestAppointments (
    TestAppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    TestTypeID INT NOT NULL,
    LocalDrivingLicenseApplicationID INT NOT NULL,
    AppointmentDate SMALLDATETIME NOT NULL,
    PaidFees SMALLMONEY NOT NULL,
    CreatedByUserID INT NOT NULL,
    IsLocked BIT NOT NULL DEFAULT 0,
    RetakeTestApplicationID INT,
    FOREIGN KEY (TestTypeID) REFERENCES TestTypes(TestTypeID),
    FOREIGN KEY (LocalDrivingLicenseApplicationID) REFERENCES LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID),
    FOREIGN KEY (RetakeTestApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);

-- 12. Tests table
CREATE TABLE Tests (
    TestID INT IDENTITY(1,1) PRIMARY KEY,
    TestAppointmentID INT NOT NULL,
    TestResult BIT NOT NULL,
    Notes NVARCHAR(500),
    CreatedByUserID INT NOT NULL,
    FOREIGN KEY (TestAppointmentID) REFERENCES TestAppointments(TestAppointmentID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);

-- 13. Drivers table
CREATE TABLE Drivers (
    DriverID INT IDENTITY(1,1) PRIMARY KEY,
    PersonID INT NOT NULL,
    CreatedByUserID INT NOT NULL,
    CreatedDate SMALLDATETIME NOT NULL,
    FOREIGN KEY (PersonID) REFERENCES People(PersonID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);

-- 14. Licenses table
CREATE TABLE Licenses (
    LicenseID INT IDENTITY(1,1) PRIMARY KEY,
    ApplicationID INT NOT NULL,
    DriverID INT NOT NULL,
    LicenseClass INT NOT NULL,
    IssueDate DATETIME NOT NULL,
    ExpirationDate DATETIME NOT NULL,
    Notes NVARCHAR(500),
    PaidFees SMALLMONEY NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IssueReason TINYINT NOT NULL DEFAULT 1,
    CreatedByUserID INT NOT NULL,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (DriverID) REFERENCES Drivers(DriverID),
    FOREIGN KEY (LicenseClass) REFERENCES LicenseClasses(LicenseClassID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);

-- 15. InternationalLicenses table
CREATE TABLE InternationalLicenses (
    InternationalLicenseID INT IDENTITY(1,1) PRIMARY KEY,
    ApplicationID INT NOT NULL,
    DriverID INT NOT NULL,
    IssuedUsingLocalLicenseID INT NOT NULL,
    IssueDate SMALLDATETIME NOT NULL,
    ExpirationDate SMALLDATETIME NOT NULL,
    IsActive BIT NOT NULL,
    CreatedByUserID INT NOT NULL,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (DriverID) REFERENCES Drivers(DriverID),
    FOREIGN KEY (IssuedUsingLocalLicenseID) REFERENCES Licenses(LicenseID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);

-- 16. DetainedLicenses table
CREATE TABLE DetainedLicenses (
    DetainID INT IDENTITY(1,1) PRIMARY KEY,
    LicenseID INT NOT NULL,
    DetainDate SMALLDATETIME NOT NULL,
    FineFees SMALLMONEY NOT NULL,
    CreatedByUserID INT NOT NULL,
    IsReleased BIT NOT NULL DEFAULT 0,
    ReleaseDate SMALLDATETIME NULL,
    ReleasedByUserID INT NULL,
    ReleaseApplicationID INT NULL,
    FOREIGN KEY (LicenseID) REFERENCES Licenses(LicenseID),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID),
    FOREIGN KEY (ReleasedByUserID) REFERENCES Users(UserID),
    FOREIGN KEY (ReleaseApplicationID) REFERENCES Applications(ApplicationID)
);

-- 17. vwLDLAppsSummary view
CREATE VIEW vwLDLAppsSummary AS
SELECT 
    L.LocalDrivingLicenseApplicationID, 
    C.ClassName, 
    P.NationalNo,
    P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,
    A.ApplicationDate,
    SUM(CASE WHEN T.TestResult = 1 THEN 1 ELSE 0 END) AS [Passed Tests],
    CASE
        WHEN A.ApplicationStatus = 1 THEN 'New'
        WHEN A.ApplicationStatus = 2 THEN 'Cancelled'
        WHEN A.ApplicationStatus = 3 THEN 'Completed'
        ELSE 'Unknown'
    END AS Status
FROM LocalDrivingLicenseApplications AS L
JOIN LicenseClasses AS C ON L.LicenseClassID = C.LicenseClassID
JOIN Applications AS A ON L.ApplicationID = A.ApplicationID
JOIN People AS P ON A.ApplicantPersonID = P.PersonID
LEFT JOIN TestAppointments AS TA ON L.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
LEFT JOIN Tests AS T ON T.TestAppointmentID = TA.TestAppointmentID
GROUP BY 
    L.LocalDrivingLicenseApplicationID,
    C.ClassName,
    P.NationalNo,
    P.FirstName,
    P.SecondName,
    P.ThirdName,
    P.LastName,
    A.ApplicationDate,
    A.ApplicationStatus;

-- 18. LocalDrivingLicenseFullApplications_View view
CREATE VIEW LocalDrivingLicenseFullApplications_View AS
SELECT
    A.ApplicationID,
    A.ApplicantPersonID,
    A.ApplicationDate,
    A.ApplicationTypeID,
    A.ApplicationStatus,
    A.LastStatusDate,
    A.PaidFees,
    A.CreatedByUserID,
    L.LocalDrivingLicenseApplicationID,
    L.LicenseClassID
FROM Applications AS A
INNER JOIN LocalDrivingLicenseApplications AS L
    ON A.ApplicationID = L.ApplicationID;

-- 19. TestAppointments_View view
CREATE VIEW TestAppointments_View AS
SELECT
    TA.TestAppointmentID,
    TA.LocalDrivingLicenseApplicationID,
    TT.TestTypeTitle,
    LC.ClassName,
    TA.AppointmentDate,
    TA.PaidFees,
    P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,
    TA.IsLocked
FROM TestAppointments AS TA
INNER JOIN TestTypes AS TT
    ON TA.TestTypeID = TT.TestTypeID
INNER JOIN LocalDrivingLicenseApplications AS LDA
    ON TA.LocalDrivingLicenseApplicationID = LDA.LocalDrivingLicenseApplicationID
INNER JOIN Applications AS A
    ON LDA.ApplicationID = A.ApplicationID
INNER JOIN People AS P
    ON A.ApplicantPersonID = P.PersonID
INNER JOIN LicenseClasses AS LC
    ON LDA.LicenseClassID = LC.LicenseClassID;

-- 20. Drivers_View view
CREATE VIEW Drivers_View AS
SELECT
    D.DriverID,
    D.PersonID,
    P.NationalNo,
    P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,
    D.CreatedDate,
    (
        SELECT COUNT(LicenseID)
        FROM Licenses
        WHERE IsActive = 1 AND DriverID = D.DriverID
    ) AS NumberOfActiveLicenses
FROM Drivers AS D
INNER JOIN People AS P
    ON D.PersonID = P.PersonID;

-- 21. DetainedLicenses_View view
CREATE VIEW DetainedLicenses_View AS
SELECT
    DL.DetainID,
    DL.LicenseID,
    DL.DetainDate,
    DL.IsReleased,
    DL.FineFees,
    DL.ReleaseDate,
    P.NationalNo,
    P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,
    DL.ReleaseApplicationID
FROM DetainedLicenses AS DL
INNER JOIN Licenses AS L
    ON DL.LicenseID = L.LicenseID
INNER JOIN Drivers AS D
    ON L.DriverID = D.DriverID
INNER JOIN People AS P
    ON D.PersonID = P.PersonID;

-- End of DVLD database script