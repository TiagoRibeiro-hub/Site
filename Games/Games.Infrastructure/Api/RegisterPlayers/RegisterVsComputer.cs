using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;
public class RegisterVsComputer
{
    public RegisterVsComputer(Player player, bool isComputer, string difficulty)
    {
        Player = player;
        IsComputer = isComputer;
        Difficulty = difficulty;
    }

    public Player Player { get; set; }
    public bool IsComputer { get; private set; } = true;
    public string Difficulty { get; set; }
}