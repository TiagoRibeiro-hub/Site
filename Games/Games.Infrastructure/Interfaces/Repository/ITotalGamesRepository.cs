namespace Games.Infrastructure;

public interface ITotalGamesRepository
{
    Task UpdateTotalGamesEasyAsync(TotalGamesUpdate game);
    Task UpdateTotalGamesIntermediateAsync(TotalGamesUpdate game);
    Task UpdateTotalGamesHardAsync(TotalGamesUpdate game);
    Task UpdateTotalGamesVsHumanAsync(TotalGamesUpdate game);

}
