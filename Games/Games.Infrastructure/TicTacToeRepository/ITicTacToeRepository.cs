using Games.Data.Api;
using Games.Data.Data;
using Games.Data.Game;

namespace Games.Infrastructure;

public interface ITicTacToeRepository
{
    Task<int> InsertAndGetIdGameAsync(GameEntity game);
    Task InsertScoresTableAsync(ScoresTableEntity scoresTableEntity);
    Task UpdateScoreTableTotalGamesAsync(TotalGamesUpdate game);
}
