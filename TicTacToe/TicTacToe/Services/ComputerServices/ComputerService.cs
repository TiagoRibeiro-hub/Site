using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ComputerService : IComputerService
{
    public readonly IDbActionService _dbActionService;
    public ComputerService(IDbActionService dbActionService)
    {
        _dbActionService = dbActionService;
    }

    public Task<int> GetEasyPlayedMoveAsync(List<int> possibleMoves)
    {
        try
        {
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public Task<int> GetIntermediatePlayedMoveAsync(List<int> possibleMoves)
    {
        try
        {
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public Task<int> GetHardPlayedMoveAsync(List<int> possibleMoves)
    {
        try
        {
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

}

