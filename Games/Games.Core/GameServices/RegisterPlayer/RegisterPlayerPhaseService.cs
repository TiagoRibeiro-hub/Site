using Games.Infrastructure;

namespace Games.Core.Services;

public class RegisterPlayerPhaseService : IRegisterPlayerPhaseService
{
    private readonly IRegisteredPlayersRepository _registeredPlayersRepository;
    private readonly ITicTacToeWriteRepository _ticTacToeWriteRepository;
    public RegisterPlayerPhaseService(
        IRegisteredPlayersRepository registeredPlayersRepository,
        ITicTacToeWriteRepository ticTacToeRepository)
    {
        _registeredPlayersRepository = registeredPlayersRepository;
        _ticTacToeWriteRepository = ticTacToeRepository;
    }

    public async Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer)
    {
        Response<RegisterPlayerResponse> response = new();
        await _registeredPlayersRepository.InsertAsync(registerPlayer.SetRegisteredPlayers());
        await InitializeScoreTable(registerPlayer.Player.Name);
        return response.Success
                    (
                        content: new RegisterPlayerResponse(playerName: true, email: true),
                        message: "Successful registration"
                    );
    }

    private async Task InitializeScoreTable(string playerName)
    {
        ScoresTableEntity scoresPlayer = new(playerName: playerName);
        // TicTacToe
        await _ticTacToeWriteRepository.InsertScoresTableAsync(scoresPlayer);
    }
}
