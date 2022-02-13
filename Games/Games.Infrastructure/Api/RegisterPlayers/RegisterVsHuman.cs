using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;
public class RegisterVsHuman
{
    public RegisterVsHuman(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
    }

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
}
