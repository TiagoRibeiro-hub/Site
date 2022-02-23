namespace Games.Infrastructure;
public interface IUnitOfWorkTicTacToe<TEntity> : IDisposable  where TEntity : class
{
    ITicTacToeWrite<TEntity> TicTacToeWrite { get; }
    ITicTacToeRead<TEntity> TicTacToeRead { get; }
    Task Complete();
}