namespace Games.Infrastructure;

public interface IWriteScoresTableRepository
{
    Task InsertScoresTableAsync(ScoresTableEntity scoresTableEntity);
    Task UpdateScoreTableTotalGamesAsync(TotalGamesUpdate game);
}
