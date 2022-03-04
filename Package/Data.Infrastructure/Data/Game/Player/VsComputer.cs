namespace Data.Infrastructure.Data.Game.Player;

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

public static class Computer
{
    public const string Name = "The Machine";
}