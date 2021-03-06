CREATE DATABASE OrgStructure
GO

USE OrgStructure
GO

CREATE TABLE [Department](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Code] [nvarchar](10) NULL,
	[Name] [nvarchar](50) NULL,
	[Hierarchy] [int] NOT NULL,
	[ParentDepartmentID] [int] FOREIGN KEY REFERENCES [Department] (ID) NULL,
	[HeadEmployeeID] [int] NULL,)

CREATE TABLE [Employee](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Title] [nvarchar](10) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
	[Email] [nvarchar](255) NULL,
	[DepartmentID] [int] FOREIGN KEY REFERENCES [Department] (ID) NULL,)

ALTER TABLE [Department]
ADD FOREIGN KEY ([HeadEmployeeID]) REFERENCES [Employee]([ID])