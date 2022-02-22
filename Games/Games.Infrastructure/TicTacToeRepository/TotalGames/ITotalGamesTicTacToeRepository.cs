using Games.Data.Api;

namespace Games.Infrastructure;

public interface ITotalGamesTicTacToeRepository
{
    Task UpdateTotalGamesAsync(InitializeGameRequest game, int scoreTableId, string playerName);
}