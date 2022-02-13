USE master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Chess') 
	DROP DATABASE Chess
GO
CREATE DATABASE Chess
GO
USE Chess
GO