namespace Games.Infrastructure;

public interface IReadGameRepository
{
    Task<bool> IsAnyGameAsync(Expression<Func<GameEntity, bool>> predicate);
}