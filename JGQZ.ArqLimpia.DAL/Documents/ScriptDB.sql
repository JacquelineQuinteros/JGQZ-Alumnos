CREATE DATABASE JGQZ
GO
USE JGQZ
GO
CREATE TABLE Students(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] varchar(150) NOT NULL,
	YearsOld int NOT NULL,
	[Address] varchar(MAX) NOT NULL,
	Email varchar(MAX) NOT NULL,
	Number varchar(8) NOT NULL,
	SecondNumber varchar(8) NOT NULL
)
GO