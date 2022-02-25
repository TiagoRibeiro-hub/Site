namespace Games.Infrastructure;

public interface IReadMovesRepository
{
    Task<List<TResult>> GetToListAsync<TResult>(Expression<Func<MovesEntity, bool>> predicate, Expression<Func<MovesEntity, TResult>> selector) where TResult : IConvertible;
}
