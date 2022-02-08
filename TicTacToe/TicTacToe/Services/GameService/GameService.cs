using TicTacToe.Data;
using TicTacToe.DbActionService;
using TicTacToeClass;

namespace TicTacToe.Services;
public class GameService : IGameService
{
    private readonly IWinnerService _winnerService;
    private readonly IDbActionGameService _dbActionGameService;
    private readonly IScoresService _scoreService;

    public GameService(
        IWinnerService winnerService, IDbActionGameService dbActionGameService,
        IScoresService scoreService)
    {
        _winnerService = winnerService;
        _dbActionGameService = dbActionGameService;
        _scoreService = scoreService;
    }

    public async Task<GameResponse> InitializeGameAsync(RegisterPlayersRequest registerPlayers)
    {
        try
        {
            Game gamePlayer1 = registerPlayers.GameInit();
            gamePlayer1.Player = registerPlayers.GetPlayersFromPlayersRequestList();
            await _scoreService.TableScoreInitialize(gamePlayer1);

            GameResponse gameResponse = GameServiceFuncs.SetPossibleMoves();

            if (!registerPlayers.IsComputer)
            {
                Game gamePlayer2 = registerPlayers.GameInit();
                gamePlayer2.Player = registerPlayers.GetPlayersFromPlayersRequestList();
                await _scoreService.TableScoreInitialize(gamePlayer2);
                gameResponse.IdGame = await SetGameAsync(gamePlayer1, gamePlayer2);
            }
            else
            {
                gameResponse.IdGame = await SetGameAsync(gamePlayer1);
            }
            Task.CompletedTask.Wait();
            return gameResponse;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    private async Task<int> SetGameAsync(Game player1, Game player2 = null)
    {
        try
        {
            GameModel gameModel = GameServiceFuncs.PlayersNameProp(player1, player2);
            GameServiceFuncs.StartsFirstProp(player1, player2, gameModel);
            GameServiceFuncs.DifficultyProp(player1, gameModel);
            HashSet<Moves> listPlayerMovesInit = new();
            listPlayerMovesInit.Add(GameServiceFuncs.AddMovesInit(player1.Player.Name));
            if (player2 != null)
            {
                listPlayerMovesInit.Add(GameServiceFuncs.AddMovesInit(player2.Player.Name));
            }
            else
            {
                listPlayerMovesInit.Add(GameServiceFuncs.AddMovesInit(Computer.Name));
            }

            int gameId = await _dbActionGameService.InsertInitializeGame(gameModel, listPlayerMovesInit);
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }


    public async Task<GameResponse> GamePlayedAsync(GameRequest request)
    {
        try
        {
            request.PossibleMoves.Remove(request.MovePlayed);
            Game game = new()
            {
                GameId = request.IdGame,
                PossibleMoves = request.PossibleMoves,
            };
            game.Player.Name = request.PlayerName;
            game.Player.Moves.Move = request.MovePlayed;
            var resPlayerList = _winnerService.GetListMovesAsync(game);
            var resRegMove = _dbActionGameService.RegisterMove(game);
            game.Player.Moves.ListPlayedMoves = await resPlayerList;
            var resWinner = _winnerService.GetWinnerAsync(game);
            await resRegMove;
            Winner winner = await resWinner;
            if (winner.GameFinished)
            {
                await _scoreService.SetScoresTableFinishedGame(winner);
            }
            Task.CompletedTask.Wait();
            return winner.SetGameResponseFromWinner(game.PossibleMoves);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

