namespace Games.Data.Api;
public class RegisterVsHuman : Register
{
    public RegisterVsHuman(Player player, Player player2) :base(player)
    {
        Player = player;
        Player2 = player2;
    }

    public Player Player2 { get; set; }
}
