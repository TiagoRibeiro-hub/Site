using Games.Infrastructure;

namespace Games.Core.Services;

public interface IGameInitializeService
{
    Task<int> InsertAndGetIdGameAsync(GameEntity entity);
    Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest scoresTableEntity);
    Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns);
}

public interface ITicTacToeService : IGameInitializeService
{

}

public class TicTacToeService : ITicTacToeService
{
    private readonly ITicTacToeRepository _ticTacToeRepository;
    public TicTacToeService(
        ITicTacToeRepository ticTacToeRepository)
    {
        _ticTacToeRepository = ticTacToeRepository;
    }
    public async Task<int> InsertAndGetIdGameAsync(GameEntity entity)
    {
        return await _ticTacToeRepository.InsertAndGetIdGameAsync(entity);
    }

    public async Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest scoresTableEntity)
    {
        //await _ticTacToeRepository.UpdateScoreTableTotalGamesAsync(scoresTableEntity);
    }
    public Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns)
    {
        int max = TicTacToeNumberColumns * TicTacToeNumberColumns + 1;
        Dictionary<string, string> result = new();
        for (int i = 1; i < max; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }


}