namespace Games.Data.Api;
#nullable disable
public class GameOptions
{
    public string GameTypeName { get; set; }
    public GameTypeOptions GetGameTypeOptions { get; set; }
}