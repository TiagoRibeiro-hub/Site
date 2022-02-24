namespace Games.Infrastructure;

public interface IReadScoresTableRepository
{
    Task<bool> IsAnyInScoresTableAsync(Expression<Func<ScoresTableEntity, bool>> predicate);
    Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<ScoresTableEntity, bool>> predicate, Expression<Func<ScoresTableEntity, TResult>> selector) where TResult : IConvertible;
}