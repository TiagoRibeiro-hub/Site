namespace Games.Infrastructure;

public interface IWriteRepository
{
    Task<int> InsertAndGetIdGameAsync(GameEntity game);
    Task InsertScoresTableAsync(ScoresTableEntity scoresTableEntity);
    Task UpdateScoreTableTotalGamesAsync(TotalGamesUpdate game);
}