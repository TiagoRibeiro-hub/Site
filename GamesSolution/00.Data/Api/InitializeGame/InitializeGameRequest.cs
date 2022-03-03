using _00.Data.Game;
using _00.Data.Game.Player;

namespace _00.Data.Api.InitializeGame;
#nullable disable
public class InitializeGameRequest
{
    public GameOptions GetGameOptions { get; set; }
    public string PlayerName_1 { get; set; }
    public string StartFirst { get; set; }
    public VsComputer VsComputer { get; set; }
    public VsHuman VsHuman { get; set; }
}
