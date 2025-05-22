CREATE DATABASE DesignPatternSampleDB;
GO

USE DesignPatternSampleDB;
GO

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Department NVARCHAR(100) NOT NULL,
    HireDate DATETIME NOT NULL
);
GO
