using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ComputerService : IComputerService
{
    private readonly IDbActionScoreTableService _dbActionScoreTableService;
    public readonly IDbActionService _dbActionService;
    public ComputerService(IDbActionScoreTableService dbActionScoreTableService, IDbActionService dbActionService)
    {
        _dbActionScoreTableService = dbActionScoreTableService;
        _dbActionService = dbActionService;
    }

    public async Task<object> GetTotalGamesScoreTableIdAsync<TEntity>(TEntity entity, int scoreTableId) where TEntity : class
    {
        try
        {
            object result = new();
            result = await _dbActionScoreTableService.GetTotalGamesScoreTableIdAsync(entity, scoreTableId);
            if(result is null)
            {
                throw new Exception();
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task UpdateTotalGamesVsComputerAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            await _dbActionService.UpdateAsync(entity);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}

