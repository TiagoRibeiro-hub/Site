using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;

public class Register
{
    public Register(Player player, string startFirst)
    {
        Player = player;
        StartFirst = startFirst;
    }

    public Player Player { get; set; }
    public string StartFirst { get; set; }
}