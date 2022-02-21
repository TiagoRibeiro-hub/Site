USE master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'RegisteredPlayers') 
	DROP DATABASE RegisteredPlayers
GO
CREATE DATABASE RegisteredPlayers
GO
USE RegisteredPlayers
GO