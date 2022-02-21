namespace Games.Data.Api;

public class RegisterPlayerResponse
{
    public RegisterPlayerResponse()
    {

    }
    public RegisterPlayerResponse(bool playerName, bool email)
    {
        PlayerName = playerName;
        Email = email;
    }

    public bool PlayerName { get; set; }
    public bool Email { get; set; }
}