namespace Games.Infrastructure;

public interface IWriteGameRepository
{
    Task<int> InsertAndGetIdGameAsync(GameEntity game);
}