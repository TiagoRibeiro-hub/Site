using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;
public class RegisterVsHuman : Register
{
    public RegisterVsHuman(Player player, string startFirst, Player player2) :base(player, startFirst)
    {
        Player = player;
        StartFirst = startFirst;
        Player2 = player2;
    }

    public Player Player2 { get; set; }
}
