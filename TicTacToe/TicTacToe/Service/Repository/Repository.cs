using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.Service;
internal class Repository : IRepository
{
    private readonly IDbSaves _dbSaves;

    public Repository(IDbSaves dbSaves)
    {
        _dbSaves = dbSaves;
    }

    public async Task<Response> RegisterPlayers(RegisterPlayersRequest registerPlayers)
    {
        Human player1 = new()
        {
            Name = registerPlayers.Player1,
            ListPlayedMoves = new(),
            Email = registerPlayers.Player1_Email
        };

        Computer computer = new(); Human player2 = new();
        if (registerPlayers.ComputerIsActive)
        {
            computer.Name = registerPlayers.Player2;
            computer.ListPlayedMoves = new();
            computer.Active = registerPlayers.ComputerIsActive;
            if (registerPlayers.Difficulty == Difficulty.Easy.ToString())
            {
                computer.Easy = true;
            }
            if (registerPlayers.Difficulty == Difficulty.Intermediate.ToString())
            {
                computer.Intermediate = true;
            }
            if (registerPlayers.Difficulty == Difficulty.Hard.ToString())
            {
                computer.Hard = true;
            }
        }
        else
        {
            player2.Name = registerPlayers.Player2;
            player2.ListPlayedMoves = new();
            player2.Email = registerPlayers.Player2_Email;
        }

        _ = _dbSaves.InitializeGame(player1, player2, computer);

        HashSet<int> possibleMoves = new();
        for (int i = 0; i < 9; i++)
        {
            possibleMoves.Add(i);
        }

        return new Response()
        {
            Player1 = player1.Name,
            Player2 = player2.Name,
            PossibleMoves = possibleMoves,
            Player1Moves = player1.ListPlayedMoves,
            Player2Moves = player2.ListPlayedMoves,
            Difficulty = registerPlayers.Difficulty
        };
    }
}

