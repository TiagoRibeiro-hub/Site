namespace Games.Data.Api;

public class Register : Request
{
    public Register(Player player)
    {
        Player = player;
    }

    public Player Player { get; set; }
}