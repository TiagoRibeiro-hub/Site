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
SELECT * FROM [TicTacToe].[dbo].[TotalGamesVsComputer]

Truncate Table [TicTacToe].[dbo].[Game]
Truncate Table [TicTacToe].[dbo].[ScoresTable]
Truncate Table [TicTacToe].[dbo].[TotalGamesVsComputer]