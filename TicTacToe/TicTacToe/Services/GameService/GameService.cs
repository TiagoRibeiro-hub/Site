using TicTacToe.DbActionService;
using TicTacToeClass;

namespace TicTacToe.Services;
public class GameService : IGameService
{
    private readonly IWinnerService _winnerService;
    private readonly IDbActionGameService _dbActionGameService;
    private readonly IHumanService _humanService;
    private readonly IComputerService _computerService;
    public GameService(
        IWinnerService winnerService, IDbActionGameService dbActionGameService, 
        IHumanService humanService, IComputerService computerService)
    {
        _winnerService = winnerService;
        _dbActionGameService = dbActionGameService;
        _humanService = humanService;
        _computerService = computerService;
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
            var resRegMove = _dbActionGameService.RegisterMove(game);
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

    public async Task<int> RegisterPlayers(RegisterPlayersRequest registerPlayers)
    {
        try
        {
            PlayerRequest playerRequest1 = registerPlayers.Player1;
            Human player1 = playerRequest1.PlayerAsHuman();
            await _humanService.TableScoreInitialize(player1);

            if (registerPlayers.Player2.IsComputer)
            {
                PlayerRequest playerRequest2 = registerPlayers.Player2;
                Computer computer = playerRequest2.PlayerAsComputer();
                await _computerService.TableScoreInitialize(computer);
            }
            else
            {
                PlayerRequest playerRequest2 = registerPlayers.Player2;
                Human player2 = playerRequest2.PlayerAsHuman();
                await _humanService.TableScoreInitialize(player1);
            }

            //int gameId = await _gameService.InitializeGame(player1, player2, computer);
            Task.CompletedTask.Wait();
            return 1;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

