namespace Games.Data.Data;

public class RegisteredPlayersEntity
{
    public RegisteredPlayersEntity(string playerName, string playerEmail)
    {
        PlayerName = playerName;
        PlayerEmail = playerEmail;
    }

    public int Id { get; private set; }
    public string PlayerName { get; set; }
    public string PlayerEmail { get; set; }
}