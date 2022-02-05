USE master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'TicTacToe') 
	DROP DATABASE TicTacToe
GO
CREATE DATABASE TicTacToe
GO
USE TicTacToe
GO

SELECT * FROM [TicTacToe].[dbo].[Game]
SELECT * FROM [TicTacToe].[dbo].[Moves]
SELECT * FROM [TicTacToe].[dbo].[ScoresTable]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesVsHuman]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesVsComputer]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesEasy]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesIntermediate]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesHard]

