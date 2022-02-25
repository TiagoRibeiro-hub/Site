namespace Games.Infrastructure;

public interface IWriteMovesRepository
{
    Task InsertMovesAsync(MovesEntity movesEntity);
}