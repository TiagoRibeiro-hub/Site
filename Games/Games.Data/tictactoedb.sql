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

SELECT * FROM [TicTacToe].[dbo].[ScoresTable]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesVsComputer]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesEasy]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesIntermediate]
SELECT * FROM [TicTacToe].[dbo].[TotalGamesHard]

Select s.PlayerName, 
		e.StartSecond 'Easy', e.TotalGames 'Easy', 
		i.StartSecond 'Inter', i.TotalGames 'Inter',
		x.StartSecond 'Hard', x.TotalGames 'Hard'
From ScoresTable AS s 
	inner join TotalGamesVsComputer As h on s.Id = h.ScoreTableId
	inner join TotalGamesEasy As e on h.ScoreTableId = e.TotalGamesVsComputerId
	inner join TotalGamesIntermediate As i on h.ScoreTableId = i.TotalGamesVsComputerId
	inner join TotalGamesHard As x on h.ScoreTableId = x.TotalGamesVsComputerId
where s.PlayerName = 'tiago' 

Delete from [TicTacToe].[dbo].[ScoresTable]
where PlayerName = 'maria'