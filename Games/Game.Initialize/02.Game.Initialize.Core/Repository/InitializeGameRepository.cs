using _00.Game.Initialize.Data._DbContext;
using _02.Game.Initialize.Core.Repository.ReadWrite;
using Data.Infrastructure.Data._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Game.Initialize.Core.Repository;
public class InitializeGameRepository : IInitializeGameRepository
{
    public InitializeGameDbContext _dbContext;
    public InitializeGameRepository(InitializeGameDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeGameRead = new InitializeGameRead<GameEntity>(dbContext);
        InitializeGameWrite = new InitializeGameWrite<GameEntity>(dbContext);
    }
    public IInitializeGameWrite<GameEntity> InitializeGameWrite { get; private set; }
    public IInitializeGameRead<GameEntity> InitializeGameRead { get; private set; }

    public async Task Complete()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}

