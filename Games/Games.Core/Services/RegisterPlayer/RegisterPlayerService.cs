using Games.Infrastructure;

namespace Games.Core.Services;

public class RegisterPlayerService : IRegisterPlayerService
{
    private readonly IRegisteredPlayersRepository _registeredPlayersRepository;
    private ITicTacToeRepository _ticTacToeRepository;
    public RegisterPlayerService(
        IRegisteredPlayersRepository registeredPlayersRepository,
        ITicTacToeRepository ticTacToeRepository)
    {
        _registeredPlayersRepository = registeredPlayersRepository;
        _ticTacToeRepository = ticTacToeRepository;
    }

    public async Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer)
    {
        Response<RegisterPlayerResponse> response = new();
        bool isEmailRegistered, isPlayerNameRegistered;
        isEmailRegistered = await _registeredPlayersRepository.IsExistByEmail(registerPlayer.Player.Email);
        isPlayerNameRegistered = await _registeredPlayersRepository.IsExistByPlayerName(registerPlayer.Player.Name);
        if (isPlayerNameRegistered == false && isEmailRegistered == false)
        {
            await _registeredPlayersRepository.InsertAsync(registerPlayer.SetRegisteredPlayers());
            await InitializeScoreTable(registerPlayer.Player.Name);
            return response.Success
                        (
                            content: new RegisterPlayerResponse(playerName: true, email: true),
                            message: "Registered"
                        );
        }
        if (isPlayerNameRegistered && isEmailRegistered)
        {
            return response.Success
                        (
                            content: new RegisterPlayerResponse(playerName: isPlayerNameRegistered, email: isEmailRegistered),
                            message: "Already Registered"
                        );
        }
        return response.Fail(content: new RegisterPlayerResponse(playerName: isPlayerNameRegistered, email: isEmailRegistered));
    }

    private async Task InitializeScoreTable(string playerName)
    {
        ScoresTableEntity scoresPlayer = new(playerName: playerName);
        // TicTacToe
        await _ticTacToeRepository.InsertScoresTableAsync(scoresPlayer);
    }
}
