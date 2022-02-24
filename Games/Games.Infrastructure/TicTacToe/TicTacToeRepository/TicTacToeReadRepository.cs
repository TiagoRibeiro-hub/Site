namespace Games.Infrastructure;

public class TicTacToeReadRepository : ITicTacToeReadRepository
{
    private readonly IUnitOfWorkTicTacToe<ScoresTableEntity> _unitOfWorkScoresTable;
    private readonly IUnitOfWorkTicTacToe<GameEntity> _unitOfWorkGame;
    public TicTacToeReadRepository(
        IUnitOfWorkTicTacToe<ScoresTableEntity> unitOfWorkScoresTable, IUnitOfWorkTicTacToe<GameEntity> unitOfWorkGame)
    {
        _unitOfWorkScoresTable = unitOfWorkScoresTable;
        _unitOfWorkGame = unitOfWorkGame;
    }

    // GAME
    public async Task<bool> IsAnyGameAsync(Expression<Func<GameEntity, bool>> predicate)
    {
        try
        {
            return await _unitOfWorkGame.TicTacToeRead.IsAnyAsync(predicate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    // SCORES TABLE
    public async Task<bool> IsAnyInScoresTableAsync(Expression<Func<ScoresTableEntity, bool>> predicate)
    {
        try
        {
            return await _unitOfWorkScoresTable.TicTacToeRead.IsAnyAsync(predicate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<ScoresTableEntity, bool>> predicate, Expression<Func<ScoresTableEntity, TResult>> selector) where TResult : IConvertible
    {
        throw new NotImplementedException();
    }


}