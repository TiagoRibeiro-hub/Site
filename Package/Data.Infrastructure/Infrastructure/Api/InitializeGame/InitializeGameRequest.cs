using _00.Data.Game;
using Data.Infrastructure.Data.Game;
using Data.Infrastructure.Data.Game.Player;

namespace Data.Infrastructure.Infrastructure.Api.InitializeGame;
#nullable disable
public class InitializeGameRequest
{
    public InitializeGameRequest(
        GameOptions getGameOptions, 
        string playerName_1, string startFirst, 
        VsComputer vsComputer, VsHuman vsHuman)
    {
        GetGameOptions = getGameOptions;
        PlayerName_1 = playerName_1;
        StartFirst = startFirst;
        VsComputer = vsComputer;
        VsHuman = vsHuman;
    }

    public GameOptions GetGameOptions { get; set; }
    public string PlayerName_1 { get; set; }
    public string StartFirst { get; set; }
    public VsComputer VsComputer { get; set; }
    public VsHuman VsHuman { get; set; }
}
