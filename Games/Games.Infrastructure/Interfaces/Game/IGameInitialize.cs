namespace Games.Infrastructure;
public interface IGameInitialize
{
    Task<int> InsertAndGetIdGameAsync(GameEntity entity);
    Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest scoresTableEntity);
    Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns);
}
