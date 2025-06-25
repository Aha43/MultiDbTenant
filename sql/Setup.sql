-- Drop if exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Tenant1')
BEGIN
    ALTER DATABASE Tenant1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Tenant1;
END

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Tenant2')
BEGIN
    ALTER DATABASE Tenant2 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Tenant2;
END
code 
CREATE DATABASE Tenant1;
GO

CREATE DATABASE Tenant2;
GO

USE Tenant1;

CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);
GO

INSERT INTO Product (Name, Description)
VALUES 
    ('Sample Product A', 'This is a product in Tenant1'),
    ('Sample Product B', 'Another product in Tenant1');
GO

USE Tenant2;

CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);
GO

INSERT INTO Product (Name, Description)
VALUES 
    ('Sample Product A', 'This is a product in Tenant2'),
    ('Sample Product B', 'Another product in Tenant2');
GO
