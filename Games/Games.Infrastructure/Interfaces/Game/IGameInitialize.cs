namespace Games.Infrastructure;
public interface IGameInitialize
{
    Task<int> InsertAndGetIdGameAsync(GameEntity entity);
    Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest scoresTableEntity);
    Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns);
    Task<List<string>> PlayMove(PlayRequest request);
    Task<PlayResponse> GetWinner(PlayRequest request, List<string> playerMoves);
}
