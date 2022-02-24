namespace Games.Infrastructure;

public class TicTacToeReadRepository : ITicTacToeReadRepository
{
    private readonly IUnitOfWorkTicTacToe<ScoresTableEntity> _unitOfWorkScoresTable;

    public TicTacToeReadRepository(IUnitOfWorkTicTacToe<ScoresTableEntity> unitOfWorkScoresTable)
    {
        _unitOfWorkScoresTable = unitOfWorkScoresTable;
    }
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
}