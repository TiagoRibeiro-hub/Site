using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;
public class RegisterVsComputer : Register
{
    public RegisterVsComputer(Player player, string startFirst, bool isComputer, string difficulty) : base(player, startFirst)
    {
        Player = player;
        StartFirst = startFirst;
        IsComputer = isComputer;
        Difficulty = difficulty;
    }

    
    public bool IsComputer { get; private set; } = true;
    public string Difficulty { get; set; }
}
