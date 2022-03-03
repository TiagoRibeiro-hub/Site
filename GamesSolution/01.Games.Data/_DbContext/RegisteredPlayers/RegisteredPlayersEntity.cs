using _00.Data.Api.PlayerRegister;

namespace _01.Games.Data._DbContext;

public class RegisteredPlayersEntity
{
    public RegisteredPlayersEntity(string playerName, string playerEmail)
    {
        PlayerName = playerName;
        PlayerEmail = playerEmail;
    }

    public RegisteredPlayersEntity(RegisterPlayerRequest playerRequest)
    {
        PlayerName = playerRequest.Player.Name;
        PlayerEmail = playerRequest.Player.Email;
    }
    public int Id { get; private set; }
    public string PlayerName { get; set; }
    public string PlayerEmail { get; set; }
}