namespace Games.Data.Api;

public class VsComputer
{
    public VsComputer(bool isComputer, string difficulty)
    {
        IsComputer = isComputer;
        Difficulty = difficulty;
    }

    public bool IsComputer { get; set; }
    public string Difficulty { get; set; }
}
