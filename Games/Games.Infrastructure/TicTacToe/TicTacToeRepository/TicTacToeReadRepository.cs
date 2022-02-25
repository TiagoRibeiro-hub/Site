namespace Games.Infrastructure;

public class TicTacToeReadRepository : ITicTacToeReadRepository
{
    private readonly IUnitOfWorkTicTacToe<ScoresTableEntity> _unitOfWorkScoresTable;
    private readonly IUnitOfWorkTicTacToe<GameEntity> _unitOfWorkGame;
    private readonly IUnitOfWorkTicTacToe<MovesEntity> _unitOfWorkMoves;
    public TicTacToeReadRepository(
        IUnitOfWorkTicTacToe<ScoresTableEntity> unitOfWorkScoresTable, 
        IUnitOfWorkTicTacToe<GameEntity> unitOfWorkGame, 
        IUnitOfWorkTicTacToe<MovesEntity> unitOfWorkMoves)
    {
        _unitOfWorkScoresTable = unitOfWorkScoresTable;
        _unitOfWorkGame = unitOfWorkGame;
        _unitOfWorkMoves = unitOfWorkMoves;
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

    // MOVES
    public async Task<List<TResult>> GetToListAsync<TResult>(Expression<Func<MovesEntity, bool>> predicate, Expression<Func<MovesEntity, TResult>> selector) where TResult : IConvertible
    {
        try
        {
            var result = await _unitOfWorkMoves.TicTacToeRead.GetToListAsync(predicate, selector);
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}