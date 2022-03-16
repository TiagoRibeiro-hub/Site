using _01.Play.TicTacToe.Infrastructure;
using _02.Play.TicTacToe.Core.GameOptions;
using _02.Play.TicTacToe.Core.Repository;
using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Data.Game.Player;
using System.Linq.Expressions;

namespace _02.Play.TicTacToe.Core.Services;
public interface IComputerService
{
    Task<PlayTicTacToeRecord> SetEasyPlay(PlayTicTacToeRecord playTicTacToeRecord);
    Task<PlayTicTacToeRecord> SetIntermediatePlay(PlayTicTacToeRecord playTicTacToeRecord);
    Task<PlayTicTacToeRecord> SetHardPlay(PlayTicTacToeRecord playTicTacToeRecord);
}

public class ComputerService : IComputerService
{
    private static int GetRandomMove(List<int> possibleMoves)
    {
        var random = new Random();
        int index = random.Next(possibleMoves.Count);
        return possibleMoves[index];
    }
    public async Task<PlayTicTacToeRecord> SetEasyPlay(PlayTicTacToeRecord playTicTacToeRecord)
    {
        int middleSquare = (int)(playTicTacToeRecord.TicTacToeNumberColumns / 2 + 0.5);
        int totalSquares = playTicTacToeRecord.TicTacToeNumberColumns * playTicTacToeRecord.TicTacToeNumberColumns;
        if (playTicTacToeRecord.PossibleMoves.Count == totalSquares)
        {
            playTicTacToeRecord.Movements.MoveTo = middleSquare.ToString();
        }

        List<int> listPossibleMoves = new();
        foreach (var item in playTicTacToeRecord.PossibleMoves)
        {
            listPossibleMoves.Add(int.Parse(item.Value));
        }
        //
        if (playTicTacToeRecord.PossibleMoves.Count == totalSquares - 1)
        {
            if (listPossibleMoves.Contains(middleSquare))
            {
                playTicTacToeRecord.Movements.MoveTo = middleSquare.ToString();
            }
            else
            {
                playTicTacToeRecord.Movements.MoveTo = GetRandomMove(listPossibleMoves).ToString();
            }
        }
        //
        if (playTicTacToeRecord.PossibleMoves.Count <= totalSquares - 2)
        {
            playTicTacToeRecord.Movements.MoveTo = GetRandomMove(listPossibleMoves).ToString();
        }

        return playTicTacToeRecord;
    }

    public Task<PlayTicTacToeRecord> SetHardPlay(PlayTicTacToeRecord playTicTacToeRecord)
    {
        throw new NotImplementedException();
    }

    public Task<PlayTicTacToeRecord> SetIntermediatePlay(PlayTicTacToeRecord playTicTacToeRecord)
    {
        throw new NotImplementedException();
    }

}
