namespace Games.Data.Api;
#nullable disable
public class InitializeGameRequest
{
    public string GameType { get; set; }
    public string PlayerName_1 { get; set; }
    public string StartFirst { get; set; }
    public VsComputer VsComputer { get; set; }
    public VsHuman VsHuman { get; set; }
}


public class VsComputer
{
    public bool IsComputer { get; set; }
    public string Difficulty { get; set; }
}

public class VsHuman
{
    public string PlayerName_2 { get; set; }
}