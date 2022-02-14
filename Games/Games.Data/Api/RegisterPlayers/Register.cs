using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;

public class Register
{
    public Register(Player player)
    {
        Player = player;
    }

    public Player Player { get; set; }
}