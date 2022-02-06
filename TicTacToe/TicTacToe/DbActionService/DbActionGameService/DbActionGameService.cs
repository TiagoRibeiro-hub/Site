using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToeClass;

namespace TicTacToe.DbActionService;
public class DbActionGameService : IDbActionGameService
{
    private readonly TicTacToeDbContext _db;
    private readonly IDbActionService _dbActionService;
    public DbActionGameService(TicTacToeDbContext db, IDbActionService dbActionService)
    {
        _db = db;
        _dbActionService = dbActionService;
    }

    public async Task<bool> IsRegisterByPlayerName(string playerName)
    {
        try
        {
            bool isReg = await _db.ScoresTable.AnyAsync(x => x.PlayerName == playerName);
            if (isReg)
            {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task<int> GetScoresTableIdByPlayerNameAsync(string playerName)
    {
        try
        {
            var res = await _db.ScoresTable.Select(x => new
            {
                x.Id,
                x.PlayerName
            }).Where(x => x.PlayerName == playerName).FirstOrDefaultAsync();

            if (res is null)
            {
                throw new Exception();
            }

            return res.Id;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<ScoresTableModel> GetScoresTableByPlayerNameAsync(string playerName)
    {
        try
        {
            var scoresTable = await _db.ScoresTable.FirstOrDefaultAsync(x => x.PlayerName == playerName);
            if (scoresTable is null)
            {
                throw new Exception();
            }
            return scoresTable;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<(string, string)> GetPlayersGameByGameIdAsync(int gameId)
    {
        try
        {
            var players = await _db.Games.Select(x => new
            {
                x.Id,
                x.Player1_Name,
                x.Player2_Name
            }).Where(x => x.Id == gameId).FirstOrDefaultAsync();

            if (players is null)
            {
                throw new Exception();
            }

            return (players.Player1_Name, players.Player2_Name);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public Task<HashSet<TotalGameVsHumanTable>> GetTotalGameVsHumanTable(Winner winner)
    {
        try
        {
            var players = from scores in _db.ScoresTable
                          join vsHuman in _db.TotalGamesVsHuman on scores.Id equals vsHuman.ScoreTableId
                          where scores.PlayerName == winner.PlayerName1 || scores.PlayerName == winner.PlayerName2
                          select new
                          {
                              scores.PlayerName,
                              vsHuman.ScoreTableId,
                              vsHuman.Victories,
                              vsHuman.Losses,
                              vsHuman.Ties
                          };

            if (players is null)
            {
                throw new Exception();
            }

            HashSet<TotalGameVsHumanTable> playersList = new();
            foreach (var item in players)
            {
                TotalGameVsHumanTable p = new()
                {
                    ScoreTableId = item.ScoreTableId,
                    PlayerName = item.PlayerName,
                    Victories = item.Victories,
                    Losses = item.Losses,
                    Ties = item.Ties,
                };
                if(winner.GameState == GameState.Tie)
                {
                    p.Ties += 1;
                }
                else
                {
                    if (winner.WinnerName == item.PlayerName)
                    {
                        p.Victories += 1;
                    }
                    if (winner.LoserName == item.PlayerName)
                    {
                        p.Losses += 1;
                    }
                }         
                playersList.Add(p);
            }

            return Task.FromResult(playersList);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }


    public async Task InsertScoresTableAsync(ScoresTableModel scoreTable)
    {
        try
        {
            await _dbActionService.InsertAsync(scoreTable);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task<int> InsertInitializeGame(GameModel game, HashSet<Moves> listPlayerMovesInit)
    {
        try
        {
            await _dbActionService.InsertAsync(game);
            var gameId = await _db.Games.Select(x => new
            {
                x.Id,
                x.Player1_Name,
                x.Player2_Name
            }).Where(x => x.Player1_Name == game.Player1_Name && x.Player2_Name == game.Player2_Name).MaxAsync(x => x.Id);

            MovesModel movesModelPlayer1 = new();
            MovesModel movesModelPlayer2 = new();
            int count = 0;
            foreach (var moves in listPlayerMovesInit)
            {
                moves.GameId = gameId;
                if (count == 0)
                {
                    movesModelPlayer1 = moves.SetMovesModelFromMoves();
                }
                else
                {
                    movesModelPlayer2 = moves.SetMovesModelFromMoves();
                }
                count += 1;
            }
            await _dbActionService.InsertRangeAsync(movesModelPlayer1, movesModelPlayer2);
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task RegisterMove(Game game)
    {
        try
        {
            var isAny = await _db.Moves.AnyAsync(x => x.Id == game.GameId);
            int lastMove = 0;
            if (isAny)
            {
                lastMove = await _db.Moves.Select(x => new
                {
                    x.Id,
                    x.PlayerName,
                    x.MoveNumber
                }).Where(x => x.Id == game.GameId && x.PlayerName == game.Player.Name).MaxAsync(x => x.MoveNumber);
            }
            MovesModel movesPlayer = game.SetMovesModelFromGame(lastMove);
            await _dbActionService.InsertAsync(movesPlayer);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        };
    }
}
