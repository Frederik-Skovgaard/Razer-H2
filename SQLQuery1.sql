-- Use Master
USE master
GO


--Drop Database
ALTER DATABASE [Razor-Todo-Database] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE IF EXISTS [Razor-Todo-Database]
GO



-- Create Database
CREATE DATABASE [Razor-Todo-Database]
GO

-- Use Database
USE [Razor-Todo-Database]
GO



-------------------------------- Create Table -------------------------------- 

CREATE TABLE [Priority] (
[Priority_ID] INT IDENTITY(1,1) NOT NULL,
[Priority] NVARCHAR(6) NOT NULL

PRIMARY KEY (Priority_ID)
)
GO


CREATE TABLE [Contact] (
[Contact_ID] INT IDENTITY(1,1) NOT NULL,
[email] NVARCHAR(100) NOT NULL,
[phone] INT NOT NULL,

[f_Name] NVARCHAR(50) NOT NULL,
[m_Name] NVARCHAR(50) NOT NULL,
[l_Name] NVARCHAR(50) NOT NULL,

[IsDeleted] BIT NOT NULL

PRIMARY KEY (Contact_ID)
)
GO


CREATE TABLE [Todo] (
[Todo_ID] INT IDENTITY(1,1) NOT NULL,
[CreatedTime] DATETIME NOT NULL,
[TaskDescription] NVARCHAR(25) NOT NULL,
[Priority_ID] INT NOT NULL,
[IsCompleted] BIT NOT NULL,

[IsDeleted] BIT NOT NULL,
[Contact_ID] INT 

PRIMARY KEY (Todo_ID)
FOREIGN KEY (Contact_ID) REFERENCES [Contact](Contact_ID),
FOREIGN KEY (Priority_ID) REFERENCES [Priority](Priority_ID)
)
GO


--ALTER TABLE [Todo]
--NOCHECK CONSTRAINT FK__Todo__Priority_I__2F10007B
--GO

INSERT INTO Priority (Priority) VALUES('Low')
INSERT INTO Priority (Priority) VALUES('Normal')
INSERT INTO Priority (Priority) VALUES('High')
GO



-------------------------------- Stored-Procedure -------------------------------- 


------------------ Todo ------------------

-- Create Todo 
CREATE PROCEDURE [Create]
@description NVARCHAR(25),
@status BIT,
@Priority INT
AS
INSERT INTO Todo (CreatedTime, TaskDescription, Priority_ID, IsCompleted, IsDeleted)
VALUES (CURRENT_TIMESTAMP, @description, @Priority, @status, 0)
GO

-- Update Todo 
CREATE PROCEDURE [Update]
@id INT,
@description NVARCHAR(25),
@status BIT,
@priority INT
AS
	BEGIN
		UPDATE Todo 
		SET	   TaskDescription = @description, 
			   IsCompleted = @status,
			   Priority_ID = @priority
		WHERE Todo_ID = @id
	END
GO

-- Delete Todo 
CREATE PROCEDURE [Delete]
@id INT
AS
UPDATE Todo
SET IsDeleted = 1
WHERE Todo_ID = @id
GO

-- Get all Todo's
CREATE PROCEDURE [ReadAll]
AS
SELECT * FROM Todo
WHERE IsDeleted = 0
GO

-- Get by id
CREATE PROCEDURE [GetByID]
@id INT
AS
SELECT * FROM Todo
WHERE Todo_ID = @id
GO


------------------ Contacts ------------------

-- Create contact
CREATE PROCEDURE [CreateContact]
@email NVARCHAR(100),
@phone INT,

@f_Name NVARCHAR(50),
@m_Name NVARCHAR(50),
@l_Name NVARCHAR(50)
AS
INSERT INTO	Contact(email, phone, f_Name, m_Name, l_Name)
VALUES (@email, @phone, @f_Name, @m_Name, @l_Name)
GO

-- Update Contact
CREATE PROCEDURE [UpdateContact]
@id INT,
@email NVARCHAR(100),
@phone INT,

@f_Name NVARCHAR(50),
@m_Name NVARCHAR(50),
@l_Name NVARCHAR(50)
AS

UPDATE Contact
SET email = @email,
phone = @phone,
f_Name = @f_Name,
m_Name = @m_Name,
l_Name = @l_Name
WHERE Contact_ID = @id
GO

-- Delete Contact
CREATE PROCEDURE [DeleteContact]
@id INT
AS

UPDATE Contact
SET IsDeleted = 1
WHERE Contact_ID = @id
GO

-- Get all Contact's
CREATE PROCEDURE [GetAllContacts]
AS
SELECT * FROM Contact
WHERE IsDeleted = 0
GO

-- Get Contact by id
CREATE PROCEDURE [GetByIdContact]
@id INT
AS
SELECT * FROM Contact
WHERE Contact_ID = @id
GO