using _00.Data._Entities;
using _00.Data.Api.PlayerRegister;
using _01.Games.Data._DbContext;
using _02.Games.Core.Repository;
using ApiShared;

namespace _02.Games.Core.Services.RegisterPlayerPhase;

public class RegisterPlayerPhase : IRegisterPlayerPhaseService
{
    private readonly IRegisteredPlayersRepository _registeredPlayersRepository;

    public RegisterPlayerPhase(IRegisteredPlayersRepository registeredPlayersRepository)
    {
        _registeredPlayersRepository = registeredPlayersRepository;
    }

    public async Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer)
    {
        Response<RegisterPlayerResponse> response = new();
        await _registeredPlayersRepository.RegisteredPlayersWrite.InsertAsync(new RegisteredPlayersEntity(registerPlayer));
        //await InitializeScoreTable(registerPlayer.Player.Name);
        return response.Success
                    (
                        content: new RegisterPlayerResponse(playerName: true, email: true),
                        message: "Successful registration"
                    );
    }

    private async Task InitializeScoreTable(string playerName)
    {
        ScoresTableEntity scoresPlayer = new(playerName: playerName);
        // 
    }
}
