namespace Games.Data.Api;
#nullable disable
public class InitializeGameRequest
{
    public GameOptions GameType { get; set; } 
    public string PlayerName_1 { get; set; }
    public string StartFirst { get; set; }
    public VsComputer VsComputer { get; set; }
    public VsHuman VsHuman { get; set; }
}

public class VsHuman
{
    public string PlayerName_2 { get; set; }
}
