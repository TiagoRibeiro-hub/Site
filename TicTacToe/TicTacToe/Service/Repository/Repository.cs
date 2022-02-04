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
            Human player1 = RepositoryFuncs.PlayerInfo(registerPlayers.Player1, registerPlayers.Player1_Email);
            Computer computer = new();
            Human player2 = new();

            if (registerPlayers.IsComputer)
            {
                computer.Name = registerPlayers.Player2;
                computer.ListPlayedMoves = new();
                computer.Active = registerPlayers.IsComputer;
                if (registerPlayers.Difficulty == Difficulty.Easy.ToString())
                {
                    computer.Easy = true; computer.Difficulty = Difficulty.Easy.ToString();
                }
                if (registerPlayers.Difficulty == Difficulty.Intermediate.ToString())
                {
                    computer.Intermediate = true; computer.Difficulty = Difficulty.Intermediate.ToString();
                }
                if (registerPlayers.Difficulty == Difficulty.Hard.ToString())
                {
                    computer.Hard = true; computer.Difficulty = Difficulty.Hard.ToString();
                }
                await _gameService.TableScoreInitializeVsComputer(player1, computer.Difficulty);
            }
            else
            {
                await _gameService.TableScoreInitializeVsHuman(player1);
                player2 = RepositoryFuncs.PlayerInfo(registerPlayers.Player2, registerPlayers.Player2_Email);
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
            game.Player.ListPlayedMoves = request.PlayerMoves;

            var res = _gameDbService.RegisterMove(game);
            var resWinner = _winnerService.GetWinnerAsync(game);

            await res;
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

