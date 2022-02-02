using TicTacToe.Data;
namespace TicTacToe.Service;
public class Repository : IRepository
{

    private readonly IGameService _gameService;
    private readonly ILogger<Repository> _logger;
    public Repository(IGameService gameService, ILogger<Repository> logger)
    {
        _gameService = gameService;
        _logger = logger;
    }

    private Human PlayerInfo(string name, string email)
    {
        return new Human()
        {
            Name = name,
            Email = email,
            ListPlayedMoves = new(),
        };
    }
    public Task RegisterPlayers(RegisterPlayersRequest registerPlayers)
    {
        try
        {
            Human player1 = PlayerInfo(registerPlayers.Player1, registerPlayers.Player1_Email);

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
                _gameService.TableScoreInitializeVsComputer(player1, computer);
            }
            else
            {
                player2 = PlayerInfo(registerPlayers.Player2, registerPlayers.Player2_Email);
                _gameService.TableScoreInitializeVsHuman(player1, player2);
            }

            _gameService.InitializeGame(player1, player2, computer);

            return Task.CompletedTask;
        }
        catch (Exception)
        {
            throw;
        }
    }
}


