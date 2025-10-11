--USE CompanyDB;

-- Backup Database
--BACKUP DATABASE CompanyDB
--TO DISK = 'C:\DBs Backups\CompanyDB.bac';

---
--ALTER TABLE Employees
--ADD Religon varchar(50);

-- DIFFERENTIAL BACKUP
--BACKUP DATABASE CompanyDB
--TO DISK = 'C:\DBs Backups\CompanyDB.bac'
--WITH DIFFERENTIAL;

---

--DROP DATABASE CompanyDB;

--RESTORE DATABASE CompanyDB
--FROM DISK = 'C:\DBs Backups\CompanyDB.bac'
