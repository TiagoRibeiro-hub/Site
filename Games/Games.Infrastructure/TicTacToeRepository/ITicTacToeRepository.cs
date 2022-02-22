using Games.Data.Api;
using Games.Data.Data;

namespace Games.Infrastructure;

public interface ITicTacToeRepository
{
    Task<int> InsertAndGetIdGameAsync(GameEntity game);
    Task InsertScoresTableAsync(ScoresTableEntity scoresTableEntity);
    Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest game);
}
