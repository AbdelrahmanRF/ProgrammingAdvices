-- 1. Use the database
USE DVLD;

--- SEED DATA ---

-- 1. Seed Countries table
SET IDENTITY_INSERT Countries ON;
INSERT INTO Countries (CountryID, CountryName) VALUES
(1, 'USA'),
(2, 'Canada'),
(3, 'Jordan'),
(4, 'UK'),
(5, 'Germany'),
(6, 'France'),
(7, 'Egypt'),
(8, 'Saudi Arabia'),
(9, 'UAE'),
(10, 'Australia');
SET IDENTITY_INSERT Countries OFF;

-- 2. Seed LicenseClasses table
SET IDENTITY_INSERT LicenseClasses ON;
INSERT INTO LicenseClasses (LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees) VALUES
(1, 'Class 1 - Small Motorcycle', 'It allows the driver to drive small motorcycles, It is suitable for motorcycles with small capacity and limited power.', 18, 5, 15.00),
(2, 'Class 2 - Heavy Motorcycle License', 'Heavy Motorcycle License (Large Motorcycle USA)', 21, 5, 30.00),
(3, 'Class 3 - Ordinary driving license', 'Ordinary driving license (car License)', 18, 10, 20.00),
(4, 'Class 4 - Commercial', 'Commercial driving license (taxi/limousine)', 21, 10, 200.00),
(5, 'Class 5 - Agricultural', 'Agricultural and work vehicles used in farming or construction, (tractors / tillage machinery)', 21, 10, 50.00),
(6, 'Class 6 - Small and medium bus', 'Small and medium bus license', 21, 10, 250.00),
(7, 'Class 7 - Truck and heavy vehicle', 'Truck and heavy vehicle license', 21, 10, 300.00);
SET IDENTITY_INSERT LicenseClasses OFF;

-- 3. Seed ApplicationTypes table
SET IDENTITY_INSERT ApplicationTypes ON;
INSERT INTO ApplicationTypes (ApplicationTypeID, ApplicationTypeTitle, ApplicationFees) VALUES
(1, 'New Local Driving License Service', 15.00),
(2, 'Renew Driving License Service', 7.00),
(3, 'Replacement for a Lost Driving License', 10.00),
(4, 'Replacement for a Damaged Driving License', 5.00),
(5, 'Release Detained Driving Licsense', 15.00),
(6, 'New International License', 51.00),
(7, 'Retake Test', 5.00);
SET IDENTITY_INSERT ApplicationTypes OFF;

-- 4. Seed TestTypes table
SET IDENTITY_INSERT TestTypes ON;
INSERT INTO TestTypes (TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees) VALUES
(1, 'Vision Test', 'This assesses the applicant''s visual acuity to ensure they have sufficient vision to drive safely.', 10.00),
(2, 'Written (Theory) Test', 'This test assesses the applicant''s knowledge of traffic rules, road signs, and driving regulations. It typically consists of multiple-choice questions, and the applicant must select the correct answer(s). The written test aims to ensure that the applicant understands the rules of the road and can apply them in various driving scenarios.', 20.00),
(3, 'Practical (Street) Test', 'This test evaluates the applicant''s driving skills and ability to operate a motor vehicle safely on public roads. A licensed examiner accompanies the applicant in the vehicle and observes their driving performance.', 30.00);
SET IDENTITY_INSERT TestTypes OFF;

-- 5. Seed People table
-- Assuming one Admin/Default user and one Applicant for initial testing
SET IDENTITY_INSERT People ON;
INSERT INTO People (PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath) VALUES
(1, '1000000001', 'Admin', 'User', NULL, 'System', '1980-01-01', 0, 'Head Office', '0770000000', 'admin@dvld.gov', 1, NULL),
(2, '2000000002', 'Ahmed', 'Mohammad', 'Ali', 'Zayed', '1995-05-20', 0, 'Amman, Jordan', '0791234567', 'ahmed.zayed@example.com', 1, NULL),
(3, '3000000003', 'Fatemah', 'Khalid', NULL, 'Hussain', '1998-11-10', 1, 'Irbid, Jordan', '0787654321', 'fatemah.hussain@example.com', 1, NULL);
SET IDENTITY_INSERT People OFF;

-- 6. Seed Users table
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserID, PersonID, UserName, Password, IsActive) VALUES
(1, 1, 'admin', 'admin123', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9'),
(2, 2, 'ahmedz', 'pass123', '9b8769a4a742959a2d0298c36fb70623f2dfacda8436237df08d8dfd5b37374c');
SET IDENTITY_INSERT Users OFF;

-- 7. Seed Applications table (for initial test data)
SET IDENTITY_INSERT Applications ON;
INSERT INTO Applications (ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) VALUES
(1, 3, GETDATE(), 1, 1, GETDATE(), 15.00, 2);
SET IDENTITY_INSERT Applications OFF;

-- 8. Seed LocalDrivingLicenseApplications table
SET IDENTITY_INSERT LocalDrivingLicenseApplications ON;
INSERT INTO LocalDrivingLicenseApplications (LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID) VALUES
(1, 1, 3);
SET IDENTITY_INSERT LocalDrivingLicenseApplications OFF;

-- 9. Seed TestAppointments table (for initial test data)
SET IDENTITY_INSERT TestAppointments ON;
INSERT INTO TestAppointments (TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID) VALUES
(1, 1, 1, DATEADD(day, 7, GETDATE()), 10.00, 2, 0, NULL);
SET IDENTITY_INSERT TestAppointments OFF;

-- 10. Seed Drivers table
SET IDENTITY_INSERT Drivers ON;
INSERT INTO Drivers (DriverID, PersonID, CreatedByUserID, CreatedDate) VALUES
(1, 2, 2, GETDATE()),
(2, 3, 2, GETDATE());
SET IDENTITY_INSERT Drivers OFF;

-- 11. Seed Licenses table
SET IDENTITY_INSERT Licenses ON;
INSERT INTO Licenses (LicenseID, DriverID, LicenseClassID, IssueDate, ExpirationDate, IsActive, CreatedByUserID) VALUES
(1, 1, 3, '2025-01-01', '2035-01-01', 1, 2),
(2, 2, 3, '2025-02-01', '2035-02-01', 1, 2);
SET IDENTITY_INSERT Licenses OFF;

-- 12. Seed DetainedLicenses table
SET IDENTITY_INSERT DetainedLicenses ON;
INSERT INTO DetainedLicenses (DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) VALUES
(1, 1, '2025-06-01', 20.00, 2, 0, NULL, NULL, NULL);
SET IDENTITY_INSERT DetainedLicenses OFF;
