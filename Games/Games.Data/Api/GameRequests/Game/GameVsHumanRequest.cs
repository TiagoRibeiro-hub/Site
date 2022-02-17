namespace Games.Data.Api;
#nullable disable
public class GameVsHumanRequest : GameRequest
{
    public Player Player { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }

}
