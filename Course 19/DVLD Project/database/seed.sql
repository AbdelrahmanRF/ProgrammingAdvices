USE DVLD;
GO

-- ------------------------------
-- Users
-- ------------------------------
INSERT INTO Users (UserID, UserName, PasswordHash)
VALUES
(1, 'admin', 'admin123'), 
(2, 'staff1', 'password1'),
(3, 'staff2', 'password2');

-- ------------------------------
-- People
-- ------------------------------
INSERT INTO People (PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName)
VALUES
(1, 'J1000001', 'Ahmad', 'Mohammed', 'Ali', 'Khalid'),
(2, 'J1000002', 'Lina', 'Hassan', NULL, 'Abu'),
(3, 'J1000003', 'Omar', 'Sami', 'Ibrahim', 'Nasser');

-- ------------------------------
-- Drivers
-- ------------------------------
INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
VALUES
(1, 1, GETDATE()),
(2, 2, GETDATE());

-- ------------------------------
-- Licenses
-- ------------------------------
INSERT INTO Licenses (DriverID, LicenseClassID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
VALUES
(1, 1, '2023-01-01', '2028-01-01', 1, 1),
(2, 2, '2024-03-10', '2029-03-10', 1, 2);

-- ------------------------------
-- Applications
-- ------------------------------
INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, PaidFees, CreatedByUserID)
VALUES
(1, GETDATE(), 1, 1, 50, 1),
(2, GETDATE(), 1, 3, 50, 2);

-- ------------------------------
-- LocalDrivingLicenseApplications
-- ------------------------------
INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
VALUES
(1, 1),
(2, 2);

-- ------------------------------
-- TestTypes
-- ------------------------------
INSERT INTO TestTypes (TestTypeID, TestTypeTitle)
VALUES
(1, 'Theory Test'),
(2, 'Road Test');

-- ------------------------------
-- TestAppointments
-- ------------------------------
INSERT INTO TestAppointments (LocalDrivingLicenseApplicationID, TestTypeID, AppointmentDate, PaidFees, IsLocked)
VALUES
(1, 1, '2025-12-01', 20, 0),
(1, 2, '2025-12-05', 30, 0),
(2, 1, '2025-11-28', 20, 0);

-- ------------------------------
-- Tests
-- ------------------------------
INSERT INTO Tests (TestAppointmentID, TestResult)
VALUES
(1, 1),
(2, 0),
(3, 1);

-- ------------------------------
-- DetainedLicenses
-- ------------------------------
INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
VALUES
(1, '2025-06-15', 25, 2, 0, NULL, NULL, NULL),
(2, '2025-07-20', 50, 3, 1, '2025-08-01', 1, 2);

-- ------------------------------
-- InternationalLicenses
-- ------------------------------
INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
VALUES
(1, 1, 1, '2025-01-01', '2030-01-01', 1, 1),
(2, 2, 2, '2025-02-01', '2030-02-01', 1, 2);

GO
