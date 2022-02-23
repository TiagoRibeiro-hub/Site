namespace Games.Infrastructure;

public interface ITicTacToeWrite<TEntity> : IRepository<TEntity> where TEntity : class
{

}
