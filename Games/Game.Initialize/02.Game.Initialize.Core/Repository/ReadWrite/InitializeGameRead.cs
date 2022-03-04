using _00.Game.Initialize.Data._DbContext;
using Data.Infrastructure.Infrastructure.Repository.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Game.Initialize.Core.Repository.ReadWrite;
public class InitializeGameRead<TEntity> : ReadRepository<TEntity>, IInitializeGameRead<TEntity> where TEntity : class
{
    public InitializeGameRead(InitializeGameDbContext dbContext) : base(dbContext)
    {

    }
}

public interface IInitializeGameRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{
}
