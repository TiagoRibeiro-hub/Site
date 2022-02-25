namespace Games.Infrastructure;

public interface IReadScoresTableRepository
{
    Task<bool> IsAnyInScoresTableAsync(Expression<Func<ScoresTableEntity, bool>> predicate);
}