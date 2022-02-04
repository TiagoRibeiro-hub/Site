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

    private static Human PlayerInfo(string name, string email)
    {
        return new Human()
        {
            Name = name,
            Email = email,
            ListPlayedMoves = new(),
        };
    }
    public async Task RegisterPlayers(RegisterPlayersRequest registerPlayers)
    {
        try
        {
            Human player1 = PlayerInfo(registerPlayers.Player1, registerPlayers.Player1_Email);
            Computer computer = new(); 
            Human player2 = new();

            if (registerPlayers.ComputerIsActive)
            {
                computer.Name = registerPlayers.Player2;
                computer.ListPlayedMoves = new();
                computer.Active = registerPlayers.ComputerIsActive;
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
                player2 = PlayerInfo(registerPlayers.Player2, registerPlayers.Player2_Email);
                await _gameService.TableScoreInitializeVsHuman(player2);
            }

            await _gameService.InitializeGame(player1, player2, computer);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}


