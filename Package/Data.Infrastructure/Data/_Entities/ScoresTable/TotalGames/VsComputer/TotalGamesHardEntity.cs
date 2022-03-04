namespace Data.Infrastructure.Data._Entities;
#nullable disable
public class TotalGamesHardEntity
{
    public TotalGamesHardEntity()
    {

    }
    public TotalGamesHardEntity(
        int startFirst, int startSecond, int totalGames,
        int victories, int losses, int ties,
        int totalGamesVsComputerId)
    {
        StartFirst = startFirst;
        StartSecond = startSecond;
        TotalGames = totalGames;
        Victories = victories;
        Losses = losses;
        Ties = ties;
        TotalGamesVsComputerId = totalGamesVsComputerId;
    }

    public int Id { get; private set; }
    public int StartFirst { get; set; } = 0;
    public int StartSecond { get; set; } = 0;
    public int TotalGames { get; set; } = 0;
    public int Victories { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int Ties { get; set; } = 0;
    public TotalGamesVsComputerEntity TotalGamesVsComputer { get; set; }
    public int TotalGamesVsComputerId { get; set; }
}