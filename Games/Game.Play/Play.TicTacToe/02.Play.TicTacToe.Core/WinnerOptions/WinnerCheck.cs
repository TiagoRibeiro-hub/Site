using Data.Infrastructure.Data.Enums;
using Data.Infrastructure.Data.Extensions;

namespace _02.Play.TicTacToe.Core.WinnerOptions;
#nullable disable
public class WinnerCheck
{
    public Task<(string, string)> IsFinished(int possibleMovesCount)
    {
        if (possibleMovesCount <= 1)
        {
            return Task.FromResult((GameState.Finished.GameStateToStringUpper(), GameResult.Tie.GameResultToStringUpper()));
        }
        return Task.FromResult((GameState.Continue.GameStateToStringUpper(), string.Empty));
    }
    public async Task<bool> HaveWinner(List<string> listMovesPlayer, int nrCol)
    {
        var diagonal = Diagonal(listMovesPlayer, nrCol);
        var vertical = Vertical(listMovesPlayer, nrCol);
        if(await diagonal)
        {
            vertical.Dispose();
            return true;
        }
        var horizontal = Horizontal(listMovesPlayer, nrCol);
        if (await vertical)
        {
            horizontal.Dispose();
            return true;
        }
        if(await horizontal)
        {
            return true;
        }
        return false;
        
    }
    private Task<bool> Diagonal(List<string> moves, int nrCol)
    {
        int nextNr_Diagonal1 = 1;
        int nextNr_Diagonal2 = nrCol;
        int count_1 = 0, count_2 = 0;
        foreach (var move in moves)
        {
            if (move == nextNr_Diagonal1.ToString())
            {
                count_1 += 1;
                nextNr_Diagonal1 += nrCol + 1;
            }
            if (move == nextNr_Diagonal2.ToString())
            {
                count_2 += 1;
                nextNr_Diagonal2 += nrCol - 1;
            }
            if (count_1 == nrCol || count_2 == nrCol)
            {
                return Task.FromResult(true);
            }
        }
        return Task.FromResult(false);
    }
    private Task<bool> Vertical(List<string> moves, int nrCol)
    {
        List<List<string>> listPossibleInLine = new();
        for (int i = 1; i <= nrCol; i++)
        {
            List<string> list = new();
            int nextNr = i;
            for (int j = 1; j <= nrCol; j++)
            {
                list.Add(nextNr.ToString());
                nextNr += nrCol;
            }
        }
        int count = 0;
        foreach (var list in listPossibleInLine)
        {
            foreach (var item in list)
            {
                foreach (var move in moves)
                {
                    if (item == move)
                    {
                        count += 1;
                    }
                }
            }
            if (count == nrCol)
            {
                return Task.FromResult(true);
            }
        }
        return Task.FromResult(false); ;
    }
    private Task<bool> Horizontal(List<string> moves, int nrCol)
    {
        List<List<string>> listPossibleInLine = new();
        for (int i = 1; i <= nrCol; i++)
        {
            List<string> list = new();
            int nextNr = i;
            for (int j = 1; j <= nrCol; j++)
            {
                list.Add(nextNr.ToString());
                nextNr += 1;
            }
        }
        int count = 0;
        foreach (var list in listPossibleInLine)
        {
            foreach (var item in list)
            {
                foreach (var move in moves)
                {
                    if (item == move)
                    {
                        count += 1;
                    }
                }
            }
            if (count == nrCol)
            {
                return Task.FromResult(true); 
            }
        }
        return Task.FromResult(false); ;
    }
}
