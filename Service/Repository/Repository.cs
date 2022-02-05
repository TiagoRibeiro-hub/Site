using TicTacToe.Data;
namespace TicTacToe.Service;
public class Repository : IRepository
{

    private readonly IGameService _gameService;
    private readonly IGameDbService _gameDbService;
    private readonly IWinnerService _winnerService;

    public Repository(IGameService gameService, IGameDbService gameDbService, IWinnerService winnerService)
    {
        _gameService = gameService;
        _gameDbService = gameDbService;
        _winnerService = winnerService;
    }


    public async Task<int> RegisterPlayers(RegisterPlayersRequest registerPlayers)
    {
        try
        {
            Human player1 = RepositoryFuncs.PlayerInfo(registerPlayers.Player1.Name, registerPlayers.Player1.Email, registerPlayers.Player1.StartFirst);
            Computer computer = new();
            Human player2 = new();

            if (registerPlayers.IsComputer)
            {
                computer.Name = registerPlayers.Player2.Name;
                computer.Active = registerPlayers.IsComputer;
                computer.StartFirst = registerPlayers.Player2.StartFirst;
                if (registerPlayers.Difficulty.ToLower() == Difficulty.Easy.ToString().ToLower())
                {
                    computer.Easy = true; computer.Difficulty = Difficulty.Easy.ToString();
                }
                if (registerPlayers.Difficulty.ToLower() == Difficulty.Intermediate.ToString().ToLower())
                {
                    computer.Intermediate = true; computer.Difficulty = Difficulty.Intermediate.ToString();
                }
                if (registerPlayers.Difficulty.ToLower() == Difficulty.Hard.ToString().ToLower())
                {
                    computer.Hard = true; computer.Difficulty = Difficulty.Hard.ToString();
                }
                await _gameService.TableScoreInitializeVsComputer(player1, computer);
            }
            else
            {
                await _gameService.TableScoreInitializeVsHuman(player1);
                player2 = RepositoryFuncs.PlayerInfo(registerPlayers.Player2.Name, registerPlayers.Player2.Email, registerPlayers.Player2.StartFirst);
                await _gameService.TableScoreInitializeVsHuman(player2);
            }

            int gameId = await _gameService.InitializeGame(player1, player2, computer);
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task<GameResponse> GamePlayed(GameRequest request)
    {
        try
        {
            Game game = new()
            {
                GameId = request.IdGame,
            };
            game.Player.Name = request.PlayerName;
            game.Player.Moves.IsfirstMove = request.IsFirstMove;
            game.Player.Moves.Move = request.MovePlayed;

            game.Player.Moves.ListPlayedMoves = await _winnerService.GetListMovesAsync(game);
            var resRegMove = _gameDbService.RegisterMove(game);
            var resWinner = _winnerService.GetWinnerAsync(game);

            await resRegMove;
            Winner winner = await resWinner;
            Task.CompletedTask.Wait();
            return new GameResponse()
            {
                IdGame = game.GameId,
                HaveWinner = winner.HaveWinner,
                WinnerName = winner.Name,
                State = winner.State,
                GameFinished = winner.GameFinished,
            };
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

}

